using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllForest
    {
        public List<Forest> Get(List<Zamer> zamers)
        {
            List<Forest> dylyankas = new List<Forest>();
            double kmStart = -1;
            double kmLast = -1;
            bool needToClean = false;
            bool isForest = false;
            MestnostType mestnost = MestnostType.IndefinedType;
            MestnostToString mestnostToString = new MestnostToString();
            foreach (Zamer zamer in zamers)
            {
                if (IsMestnostForest(zamer.Mestnost, out bool toClean))
                {
                    if (kmStart == -1)
                    {
                        kmStart = zamer.Km;
                        mestnost = zamer.Mestnost;
                        needToClean = toClean;
                        isForest = true;
                    }
                    else if (mestnost != zamer.Mestnost)
                    {
                        dylyankas.Add(new Forest(kmStart, zamer.Km, needToClean));
                        kmStart = zamer.Km;
                        mestnost = zamer.Mestnost;
                        needToClean = toClean;
                        isForest = true;
                    }
                }
                else if (isForest)
                {
                    dylyankas.Add(new Forest(kmStart, kmLast, needToClean));
                    kmStart = -1;
                    isForest = false;
                }
                if (zamer.Name == ProjectConstants.ZaroslyName)
                {
                    Zarosly zarosly = zamer as Zarosly;
                    if (zarosly.Length > 0) dylyankas.Add(new Forest(zarosly.Km, zarosly.Km + (double)zarosly.Length / 1000, true));
                }
                kmLast = zamer.Km;
            }
            if (kmStart != -1) dylyankas.Add(new Forest(kmStart, kmLast, needToClean));
            dylyankas = Trim(dylyankas);
            dylyankas=Split(dylyankas);
            return dylyankas;
        }
        private bool IsMestnostForest(MestnostType mestnost, out bool toClean)
        {
            toClean = false;
            if (mestnost == MestnostType.PosBPros) return true;
            if (mestnost == MestnostType.PosSPros) return true;
            if (mestnost == MestnostType.LesBPros) return true;
            if (mestnost == MestnostType.LesSPros) return true;
            if (mestnost == MestnostType.Zarosly)
            {
                toClean = true;
                return true;
            }
            return false;
        }
        private List<Forest> Trim(List<Forest> forests)
        {
            List<Forest> res = new List<Forest>();
            forests = forests.OrderBy(el => el.KmStart).ToList();
            Forest currentForest = null;
            double kmStart = -1;
            foreach (Forest forest in forests)
            {
                if (currentForest == null)
                {
                    currentForest = forest;
                    kmStart = forest.KmStart;
                }
                else if (currentForest.KmEnd <= forest.KmStart)
                {
                    res.Add(currentForest);
                    currentForest = forest;
                }
                else
                {
                    if (currentForest.KmStart < forest.KmStart)
                    {
                        res.Add(new Forest(currentForest.KmStart, forest.KmStart, currentForest.ToClean));
                    }
                    if (currentForest.KmEnd == forest.KmEnd)
                    {
                        res.Add(new Forest(forest.KmStart, forest.KmEnd, currentForest.ToClean || forest.ToClean));
                        currentForest = null;
                    }
                    else if (currentForest.KmEnd < forest.KmEnd)
                    {
                        res.Add(new Forest(forest.KmStart, currentForest.KmEnd, currentForest.ToClean || forest.ToClean));
                        currentForest = new Forest(currentForest.KmEnd, forest.KmEnd, forest.ToClean);
                    }
                    else
                    {
                        res.Add(new Forest(forest.KmStart, forest.KmEnd, currentForest.ToClean || forest.ToClean));
                        currentForest.KmStart = forest.KmEnd;
                    }
                }
            }
            if (currentForest != null)
            {
                res.Add(currentForest);
            }
            return res;
        }
        private List<Forest> Split(List<Forest> forests)
        {
            List<Forest> res = new List<Forest>();
            Forest currentForest = null;
            foreach (Forest forest in forests)
            {
                if (currentForest == null)
                {
                    currentForest = forest;
                }
                else if (currentForest.KmEnd == forest.KmStart && currentForest.ToClean == forest.ToClean)
                {
                    currentForest.KmEnd = forest.KmEnd;
                }
                else
                {
                    res.Add(currentForest);
                    currentForest = forest;
                }
            }
            if (currentForest != null) res.Add(currentForest);
            return res;
        }
    }
}
