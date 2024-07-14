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

            List<NeObstegeno> neObstDoc = neObstegenos.Where(no => no.KmStart < kmEnd && no.KmEnd > kmStart).ToList();
            List<List<Hlubyna>> data = new List<List<Hlubyna>>();
            List<Hlubyna> hlub = new List<Hlubyna>();

            foreach (Hlubyna el in hlubynas)
            {
                if (el.Km < kmStart) continue;
                if (el.Km > kmEnd) break;
                if (el.HlubynaInterpolated > AcadConstants.HlubTrimmed) el.HlubynaInterpolated = AcadConstants.HlubTrimmed;
                if (neObstDoc.Any(n => el.Km > n.KmStart && el.Km < n.KmEnd)) continue;
                if (neObstDoc.Any(k => k.KmStart == el.Km))
                {
                    if (hlub.Count > 1) data.Add(hlub);
                    hlub = new List<Hlubyna>();
                }
                else
                {
                    hlub.Add(el);
                }
            }
            if (hlub.Count > 1) data.Add(hlub);
            foreach (List<Hlubyna> elData in data)
            {
                MergeHlubynas(elData);
            }
            foreach (List<Hlubyna> hlD in hlDstu)
            {
                dstuHlubynas.Add(hlD.Select(h => new AcadZamer(h.Km, h.MinHlubynaDSTU)).ToList());
            }
            foreach (List<Hlubyna> hlN in hlNorm)
            {
                normHlubynas.Add(hlN.Select(h => new AcadZamer(h.Km, h.HlubynaInterpolated)).ToList());
            }
            foreach (List<Hlubyna> hlN in hlNNorm)
            {
                nenormHlubynas.Add(hlN.Select(h => new AcadZamer(h.Km, h.HlubynaInterpolated)).ToList());
            }
            if (ignoreNeobstegenoInDstuHlubyna)
            {
                dstuHlubynas = new List<List<AcadZamer>>();
                List<AcadZamer> dstu = new List<AcadZamer>();
                Hlubyna lastZamer = null;
                foreach (Hlubyna el in hlubynas)
                {
                    if (el.Km < kmStart) continue;
                    if (el.Km > kmEnd) break;
                    if (lastZamer == null)
                    {
                        dstu.Add(new AcadZamer(kmStart, el.MinHlubynaDSTU));
                    }
                    else if (lastZamer.MinHlubynaDSTU != el.MinHlubynaDSTU)
                    {
                        dstu.Add(new AcadZamer(el.Km, lastZamer.MinHlubynaDSTU));
                        dstu.Add(new AcadZamer(el.Km, el.MinHlubynaDSTU));
                    }
                    lastZamer = el;
                }
                dstu.Add(new AcadZamer(kmEnd, lastZamer.MinHlubynaDSTU));
                dstuHlubynas.Add(dstu);
            }

        }
        private void MergeHlubynas(List<Hlubyna> hlubynas)
        {

            List<Hlubyna> dstu = new List<Hlubyna>();
            List<Hlubyna> norm = new List<Hlubyna>();
            List<Hlubyna> nNorm = new List<Hlubyna>();
            Hlubyna lastHl = hlubynas.FirstOrDefault();
            foreach (Hlubyna hl in hlubynas)
            {
                dstu.Add(hl);
                if (lastHl.IsNormHlubyna && hl.IsNormHlubyna)
                {
                    norm.Add(hl);
                }
                else if (!lastHl.IsNormHlubyna && !hl.IsNormHlubyna)
                {
                    nNorm.Add(hl);
                }
                else if (lastHl.IsNormHlubyna && !hl.IsNormHlubyna)
                {
                    nNorm.Add(lastHl);
                    nNorm.Add(hl);
                    if (norm.Count > 1) hlNorm.Add(norm);
                    norm = new List<Hlubyna>();
                }
                else if (!lastHl.IsNormHlubyna && hl.IsNormHlubyna)
                {
                    norm.Add(hl);
                    nNorm.Add(hl);
                    if (nNorm.Count > 1) hlNNorm.Add(nNorm);
                    nNorm = new List<Hlubyna>();
                }
                lastHl = hl;
            }
            if (dstu.Count > 0) hlDstu.Add(dstu);
            if (norm.Count > 0) hlNorm.Add(norm);
            if (nNorm.Count > 0) hlNNorm.Add(nNorm);
        }
    }
}
