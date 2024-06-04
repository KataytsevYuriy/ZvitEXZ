using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class KorAktyvnist
    {
        public float KmStart { get; set; }
        public float KmEnd { get; set; }
        public KorAktyvnistTypes KorAktyvnistType { get; set; }
    }
    public enum KorAktyvnistTypes
    {
        undefined, low, medium, hight
    }
}
