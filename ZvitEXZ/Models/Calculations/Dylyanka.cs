using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class Dylyanka
    {
        public double KmStart { get; set; }
        public double KmEnd { get; set; }
        public Dylyanka(double kmStart, double kmEnd)
        {
            KmStart = Math.Round(kmStart, 3);
            KmEnd = Math.Round(kmEnd, 3);
        }
        public List<Dylyanka> TrimBylist(List<Dylyanka> trimmer)
        {
            List<Dylyanka> result = new List<Dylyanka>();
            Dylyanka rested = this;
            foreach (Dylyanka trim in trimmer)
            {
                if (rested.KmStart > trim.KmEnd) continue;
                if (rested.KmEnd < trim.KmStart) break;
                Dylyanka trimed = Trim(trim, ref rested);
                if (trimed != null && trimed.KmStart < trimed.KmEnd) result.Add(trimed);
                if (rested == null) break;
            }
            if (rested != null) result.Add(rested);
            return result;
        }
        public virtual Dylyanka Trim(Dylyanka dylyanka, ref Dylyanka ostatok)
        {
            Dylyanka result;
            if (KmStart < dylyanka.KmStart && KmEnd > dylyanka.KmStart)
            {
                result = new Dylyanka(ostatok.KmStart, dylyanka.KmStart);
            }
            else
            {
                result = null;
            }
            if (ostatok.KmStart < dylyanka.KmEnd && ostatok.KmEnd > dylyanka.KmEnd)
            {
                ostatok = new Dylyanka(dylyanka.KmEnd, KmEnd);
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
