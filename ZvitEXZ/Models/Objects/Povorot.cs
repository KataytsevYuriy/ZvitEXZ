using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Povorot : Zamer
    {
        public Napravlenye NapravlenyePovorota { get; set; }
        public int Ugol { get; set; }
        public Povorot(object[] data) : base(data)
        {
            Name = ProjectConstants.PovorotName;
            if (data[65] == null)
            {
                NapravlenyePovorota = Napravlenye.undefined;
                Logs.AddError($"км {data[1]} задайте направление поворота");
            }
            else
            {
                switch (data[65])
                {
                    case "ліво": NapravlenyePovorota = Napravlenye.left; break;
                    case "право": NapravlenyePovorota = Napravlenye.right; break;
                    default:
                        NapravlenyePovorota = Napravlenye.undefined;
                        Logs.AddError($"км {data[1]} задайте направление поворота");
                        break;
                }
            }
            if (data[66] != null)
            {
                try
                {
                    Ugol = (int)Parse.ParseDouble(data[66]);
                }
                catch
                {
                    Ugol = 0;
                    Logs.AddError($"км {data[1]} неверно задан угол поворота");
                }
            }
            else
            {
                Ugol = 0;
                Logs.AddError($"км {data[1]} задайте угол поворота");
            }
        }
        public override string ToString()
        {
            string res = Name;
            if (NapravlenyePovorota == Napravlenye.undefined) { return res; }
            if (NapravlenyePovorota == Napravlenye.right)
            {
                res = $"{res} {ProjectConstants.TurnRightName}";
            }
            else
            {
                res = $"{res} {ProjectConstants.TurnLeftName}";
            }
            if (Ugol == 0) return res;
            return $"{res} {Ugol}°";
        }
        public override string GetCadType()
        {
            if (NapravlenyePovorota == Napravlenye.right) return AcadConstants.ObjPovoroRight;
            return AcadConstants.ObjPovorotLeft;
        }
        public override string GetCadSignature()
        {
            if (Ugol == 0) return base.GetCadSignature();
            return $"{Ugol}°";
        }
    }
}
