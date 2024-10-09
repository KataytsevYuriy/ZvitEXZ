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
        public List<Dylyanka> TrimBylist(List<NeObstegeno> trimmer)
        {
            List<Dylyanka> result = new List<Dylyanka>();
            Dylyanka rested = this;
            foreach (NeObstegeno trim in trimmer)
            {
                if (rested.KmStart > trim.KmEnd) continue;
                if (rested.KmEnd < trim.KmStart) break;
                Dylyanka trimed = Trim(trim, ref rested);
                if (trimed != null && trimed.KmStart < trimed.KmEnd)
                {
                    result.Add(trimed);
                    trimed = null;
                }
                if (rested == null) break;
            }
            if (rested != null)
            {
                result.Add(rested);
                rested = null;
            }
            return result;
        }
        public virtual Dylyanka Trim(Dylyanka trimer, ref Dylyanka ostatok)
        {
            Dylyanka result;
            if (KmStart < trimer.KmStart && KmEnd > trimer.KmStart)
            {
                result = new Dylyanka(ostatok.KmStart, trimer.KmStart);
            }
            else
            {
                result = null;
            }
            if (ostatok.KmStart < trimer.KmEnd && ostatok.KmEnd > trimer.KmEnd)
            {
                ostatok = new Dylyanka(trimer.KmEnd, KmEnd);
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
