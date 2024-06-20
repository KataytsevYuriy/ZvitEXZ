using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class PovregdenyaGNT : Dylyanka
    {
        public int Number { get; set; }
        public double PovregdLenght { get; set; }
        public int Bal { get; set; }
        public PovregdenyaGNT(int number, double kmStart, double kmEnd, double povregdLenght, int bal) : base(kmStart, kmEnd)
        {
            Number = number;
            PovregdLenght = povregdLenght;
            Bal = bal;
        }
    }
}
