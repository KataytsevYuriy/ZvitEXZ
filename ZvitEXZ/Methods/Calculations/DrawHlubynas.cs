using Aspose.Cells.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.Calculations
{
    internal class DrawHlubynas
    {
        List<List<AcadZamer>> normHlubynas;
        List<List<AcadZamer>> nenormHlubynas;
        List<List<AcadZamer>> dstuHlubynas;
        List<List<Hlubyna>> hlDstu;
        List<List<Hlubyna>> hlNorm;
        List<List<Hlubyna>> hlNNorm;
        public DrawHlubynas()
        {
            normHlubynas = new List<List<AcadZamer>>();
            nenormHlubynas = new List<List<AcadZamer>>();
            dstuHlubynas = new List<List<AcadZamer>>();
            hlDstu = new List<List<Hlubyna>>();
            hlNorm = new List<List<Hlubyna>>();
            hlNNorm = new List<List<Hlubyna>>();
        }
        public void AddHlubynas(ref AcadDoc acadDoc, DrawPotencial potencailDrawer, CalculationYSettings hlubynasSettings, List<Hlubyna> hlubynas,
            double kmStart, double kmEnd, CalculateCoordinateX X, CalculateCoordinateY Y, List<NeObstegeno> neObstegenos)
        {
            GetLists(hlubynas, kmStart, kmEnd, neObstegenos);
            potencailDrawer.SelectLayer(ref acadDoc, AcadConstants.LayerDstuHlubyna);
            foreach (List<AcadZamer> ds in dstuHlubynas)
            {
                if (ds.Count > 1)
                    potencailDrawer.AddPotencial(ref acadDoc, ds, X, Y, false);
            }
            potencailDrawer.SelectLayer(ref acadDoc, AcadConstants.LayerNotNormHlubyna);
            foreach (List<AcadZamer> nn in nenormHlubynas)
            {
                if (nn.Count > 1)
                    potencailDrawer.AddPotencial(ref acadDoc, nn, X, Y);
            }
            potencailDrawer.SelectLayer(ref acadDoc, AcadConstants.LayerNormHlubyna);
            foreach (List<AcadZamer> norm in normHlubynas)
            {
                if (norm.Count > 1)
                    potencailDrawer.AddPotencial(ref acadDoc, norm, X, Y);
            }
            potencailDrawer.AddShkala(ref acadDoc, hlubynasSettings);
        }
        private void GetLists(List<Hlubyna> hlubynas, double kmStart, double kmEnd, List<NeObstegeno> neObstegenos, bool ignoreNeobstegenoInDstuHlubyna = true)
        {
            CalculatePointOfLinesCrossing crossing = new CalculatePointOfLinesCrossing();
            List<NeObstegeno> neObstDoc = neObstegenos.Where(no => no.KmStart < kmEnd && no.KmEnd > kmStart).ToList();
            List<AcadZamer> hlub = new List<AcadZamer>();
            Hlubyna lastHlub = null;
            foreach (Hlubyna el in hlubynas)
            {
                if (el.Km < kmStart) continue;
                if (el.Km > kmEnd) break;
                if (hlub.Count > 0 && neObstDoc.Any(no => no.KmStart >= lastHlub.Km && no.KmEnd <= el.Km))
                {
                    if (lastHlub.IsNormHlubyna) { normHlubynas.Add(hlub); }
                    else { nenormHlubynas.Add(hlub); }
                    hlub = new List<AcadZamer>();
                    hlub.Add(new AcadZamer(el.Km, el.HlubynaInterpolated));
                    lastHlub = el;
                }
                else if (hlub.Count == 0)
                {
                    hlub.Add(new AcadZamer(el.Km, el.HlubynaInterpolated));
                    lastHlub = el;
                }
                else if (lastHlub.IsNormHlubyna == el.IsNormHlubyna)
                {
                    hlub.Add(new AcadZamer(el.Km, el.HlubynaInterpolated));
                    lastHlub = el;
                }
                else if (lastHlub.IsNormHlubyna != el.IsNormHlubyna)
                {
                    crossing.Calculate(lastHlub.Km, el.Km, lastHlub.HlubynaInterpolated, el.HlubynaInterpolated,
                        lastHlub.MinHlubynaDSTU, el.MinHlubynaDSTU, out double km, out double val);
                    hlub.Add(new AcadZamer(km, val));
                    if (lastHlub.IsNormHlubyna) { normHlubynas.Add(hlub); }
                    else { nenormHlubynas.Add(hlub); }
                    hlub = new List<AcadZamer>();
                    hlub.Add(new AcadZamer(km, val));
                    hlub.Add(new AcadZamer(el.Km, el.HlubynaInterpolated));
                    lastHlub = el;
                }
            }
            if (hlub.Count > 0)
                if (lastHlub.IsNormHlubyna) { normHlubynas.Add(hlub); }
                else
                {
                    nenormHlubynas.Add(hlub);
                }
            dstuHlubynas = new List<List<AcadZamer>>();
            List<AcadZamer> dstu = new List<AcadZamer>();

            foreach (Hlubyna el in hlubynas)
            {
                if (el.Km < kmStart) continue;
                if (el.Km > kmEnd) break;
                dstu.Add(new AcadZamer(el.Km, el.MinHlubynaDSTU));
            }
            dstuHlubynas.Add(dstu);
        }
    }
}
