using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class DrawHruntActivities
    {
        public void AddHruntActivities(ref AcadDoc acadDoc, CalculateCoordinateX X, double kmStart, double kmEnd, List<HruntAktivity> hruntAktivities)
        {
            foreach (HruntAktivity hruntAktivity in hruntAktivities)
            {
                if (kmStart > hruntAktivity.KmFinish) continue;
                if (kmEnd < hruntAktivity.KmStart) break;
                double start = kmStart > hruntAktivity.KmStart ? kmStart : hruntAktivity.KmStart;
                double end = kmEnd > hruntAktivity.KmFinish ? hruntAktivity.KmFinish : kmEnd;
                acadDoc.DrawingSteps.Add(new DrawBlock(GetBlockName(hruntAktivity.HruntAktivityType), X.Calkulate(start), AcadConstants.HruntActivityStartY,
                    X.Calkulate(end) - X.Calkulate(start)));
            }
        }
        private string GetBlockName(HruntAktivityTypes aktivityType)
        {
            switch (aktivityType)
            {
                case HruntAktivityTypes.low: return AcadConstants.ZalivkaGreen;
                case HruntAktivityTypes.medium: return AcadConstants.ZalivkaYellow;
                case HruntAktivityTypes.hight: return AcadConstants.ZalivkaRed;
                default: return "";
            }
        }
        public void DrawGraph(ref AcadDoc acadDoc, DrawPotencial potencailDrawer, CalculationYSettings hlubynasSettings, List<Zamer> zamers,
            double kmStart, double kmEnd, CalculateCoordinateX X, CalculateCoordinateY Y, List<NeObstegeno> neObstegenos)
        {
            List<AcadZamer> acadZamers = GetRhrZamers(zamers, kmStart, kmEnd);
            neObstegenos = neObstegenos.Where(no => no.KmEnd > kmStart && no.KmStart < kmEnd).ToList();
            List<List<AcadZamer>> trimmedZamers = TrimNeobstegeno(acadZamers, neObstegenos);
            potencailDrawer.SelectLayer(ref acadDoc, AcadConstants.LayerRhr);
            foreach (List<AcadZamer> pline in trimmedZamers)
            {
                potencailDrawer.AddPotencial(ref acadDoc, pline, X, Y, false);
            }
            potencailDrawer.AddShkala(ref acadDoc, hlubynasSettings, new List<double> { 10, 20, 50, 100 });
            potencailDrawer.AddLineMinZah(ref acadDoc, Y, 20, AcadConstants.LayerRhr20);
            potencailDrawer.AddLineMinZah(ref acadDoc, Y, 50, AcadConstants.LayerRhr50);
        }
        private List<AcadZamer> GetRhrZamers(List<Zamer> zamers, double kmStart, double kmEnd)
        {
            List<AcadZamer> data = zamers.Where(el => el.Rhr != null).Select(r => new AcadZamer(r.Km, r.Rhr)).ToList();
            List<AcadZamer> res = new List<AcadZamer>();
            CalculateValueByKm calculateValueByKm = new CalculateValueByKm();
            AcadZamer lastZamer = null;
            foreach (AcadZamer zamer in data)
            {
                if (lastZamer == null && zamer.Km >= kmStart && zamer.Km <= kmEnd)
                {
                    res.Add(zamer);
                }
                else if (zamer.Km == kmStart)
                {
                    res.Add(zamer);
                }
                else if (zamer.Km > kmStart && zamer.Km < kmEnd)
                {
                    if (lastZamer.Km < kmStart)
                    {
                        double val = calculateValueByKm.Calcculate(lastZamer.Km, lastZamer.Value, zamer.Km, zamer.Value, kmStart);
                        res.Add(new AcadZamer(kmStart, val));
                    }
                    res.Add(zamer);

                }
                else if (zamer.Km == kmEnd)
                {
                    res.Add(zamer);
                    break;
                }
                else if (zamer.Km > kmEnd)
                {
                    double val = calculateValueByKm.Calcculate(lastZamer.Km, lastZamer.Value, zamer.Km, zamer.Value, kmEnd);
                    res.Add(new AcadZamer(kmEnd, val));
                    break;
                }
                lastZamer = zamer;
            }
            return res;
        }
        private List<List<AcadZamer>> TrimNeobstegeno(List<AcadZamer> data, List<NeObstegeno> neObstegenos)
        {
            List<List<AcadZamer>> res = new List<List<AcadZamer>>();
            if (neObstegenos.Count < 2) return res;
            List<AcadZamer> dilyanka = new List<AcadZamer>();
            AcadZamer lastZamer = null;
            CalculateValueByKm calculateValueByKm = new CalculateValueByKm();
            foreach (AcadZamer zamer in data)
            {
                if (lastZamer != null)
                {
                    foreach (NeObstegeno neObstegeno in neObstegenos)
                    {
                        if (neObstegeno.KmStart < lastZamer.Km) continue;
                        if (neObstegeno.KmStart >= zamer.Km) break;
                        TrimHrunt(lastZamer, zamer, neObstegeno, calculateValueByKm, out AcadZamer trimmedBefor, out lastZamer);
                        if (trimmedBefor != null) dilyanka.Add(trimmedBefor);
                        if (dilyanka.Count > 1) res.Add(dilyanka);
                        dilyanka = new List<AcadZamer>();
                        if (lastZamer == null)
                        {
                            break;
                        }
                        else
                        {
                            dilyanka.Add(lastZamer);
                        }
                    }
                }
                dilyanka.Add(zamer);
                lastZamer = zamer;
            }
            if (dilyanka.Count > 1) res.Add(dilyanka);
            return res;
        }
        private void TrimHrunt(AcadZamer start, AcadZamer end, NeObstegeno neObstegeno, CalculateValueByKm calculateValueByKm,
            out AcadZamer trimmedBefor, out AcadZamer trimmedAfter)
        {
            if (start.Km == neObstegeno.KmStart)
            {
                trimmedBefor = null;
            }
            else
            {
                trimmedBefor = new AcadZamer(neObstegeno.KmStart, calculateValueByKm.Calcculate(start.Km, start.Value, end.Km, end.Value, neObstegeno.KmStart));
            }
            if (end.Km == neObstegeno.KmEnd)
            {
                trimmedAfter = null;
            }
            else
            {
                trimmedAfter = new AcadZamer(neObstegeno.KmEnd, calculateValueByKm.Calcculate(start.Km, start.Value, end.Km, end.Value, neObstegeno.KmEnd));
            }
        }
    }
}
