using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllPovregdenyasGNT
    {
        List<PovregdenyaGNT> povregdenyaGNT;
        public List<PovregdenyaGNT> Get(List<Povregdenya> povregdenyas, List<NeObstegeno> neObstegenos, double pipeKmStart, double pipeKmEnd, out double bal)
        {
            bal = 0;
            povregdenyaGNT = new List<PovregdenyaGNT>();
            int i = 1;
            double kmStart = pipeKmStart, kmEnd = pipeKmStart + ProjectConstants.DylyankaGNT;
            do
            {
                double povregdLenght = 0;
                foreach (Povregdenya povregd in povregdenyas)
                {
                    if (povregd.KmEnd <= kmStart) continue;
                    if (povregd.KmStart >= kmEnd) break;
                    double start = povregd.KmStart <= kmStart ? kmStart : povregd.KmStart;
                    double end = povregd.KmEnd > kmEnd ? kmEnd : povregd.KmEnd;
                    povregdLenght += end - start;
                }
                if (kmEnd > pipeKmEnd) kmEnd = pipeKmEnd;
                povregdenyaGNT.Add(new PovregdenyaGNT(i, kmStart, kmEnd, povregdLenght, povregdLenght == 0 ? 4 : 1));
                kmStart = kmEnd;
                kmEnd = kmEnd + ProjectConstants.DylyankaGNT;
                i++;
            }
            while (kmStart < pipeKmEnd);
            foreach (PovregdenyaGNT povregd in povregdenyaGNT)
            {
                if (neObstegenos.Any(ne => ne.KmStart <= povregd.KmStart && ne.KmEnd >= povregd.KmEnd)) povregd.Bal = 0;
            }
            List<PovregdenyaGNT> p = povregdenyaGNT.Where(el => el.Bal == 1 || el.Bal == 4).ToList();
            bal = Math.Round((double)p.Sum(b => b.Bal) / p.Count(), 1);
            return povregdenyaGNT;
        }
    }
}
