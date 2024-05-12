using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods
{
    public static class Parse
    {
        public static float ParseFloat(object data)
        {
            return float.Parse(CorrectString(data.ToString()));
        }
        private static string CorrectString(string data)
        {
            return data.Replace(",", ".").Trim();
        }
        public static MestnostType Mestnost(object data)
        {
            if (data == null) return MestnostType.IndefinedType;
            switch (data.ToString())
            {
                case "С/Х  нач": return MestnostType.CXStart;
                case "с/х  кон": return MestnostType.CXEnd;
                case "Посадка нач": return MestnostType.PosBProsStart;
                case "посадка кон": return MestnostType.PosBProsEnd;
                case "Лес прос нач": return MestnostType.LesSProsStart;
                case "лес прос кон": return MestnostType.LesSProsEnd;
                case "Луг нач": return MestnostType.LugStart;
                case "луг кон": return MestnostType.LugEnd;
                case "Заросли нач": return MestnostType.ZaroslyStart;
                case "заросли кон": return MestnostType.ZaroslyEnd;
                case "Забол грунт нач": return MestnostType.ZabolHruntStart;
                case "забол грунт кон": return MestnostType.ZabolHruntEnd;
                case "Пустырь нач": return MestnostType.PustyrStart;
                case "пустырь кон": return MestnostType.PustyrEnd;
                case "Сад нач": return MestnostType.SadStart;
                case "сад кон": return MestnostType.SadEnd;
                case "Балка начало": return MestnostType.BalkaStart;
                case "балка кон": return MestnostType.BalkaEnd;
                default: return MestnostType.Error;
            };
        }
    }
}
