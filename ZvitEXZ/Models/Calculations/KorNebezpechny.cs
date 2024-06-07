using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class KorNebezpechny : Dylyanka
    {
        public string Description { get; set; }
        public KorNebezpechny(double kmStart, double kmEnd, string description) : base(kmStart, kmEnd)
        {
            Description = description;
        }
        public override Dylyanka Trim(Dylyanka dylyanka, ref Dylyanka ostatok)
        {
            Dylyanka result;
            KorNebezpechny korNeb = dylyanka as KorNebezpechny;
            if (KmStart < korNeb.KmStart && KmEnd > korNeb.KmStart)
            {
                result = new KorNebezpechny(ostatok.KmStart, dylyanka.KmStart, korNeb.Description);
            }
            else
            {
                result = null;
            }
            if (ostatok.KmStart < dylyanka.KmEnd && ostatok.KmEnd > dylyanka.KmEnd)
            {
                ostatok = new KorNebezpechny(dylyanka.KmEnd, KmEnd,korNeb.Description);
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
