using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods
{
    internal static class ParseData
    {
        public static string String(object obj)
        {
            if (obj == null) return "";
            return obj.ToString();
        }
        public static ProvodTypePidklichenyas ProvodTypePidklichenya(object obj)
        {
            if (obj == null) return ProvodTypePidklichenyas.undefined;
            switch (obj.ToString())
            {
                case "трубопровід": return ProvodTypePidklichenyas.pipe;
                case "потенціал \"труба-земля\" в точці дренажа": return ProvodTypePidklichenyas.pointDrenazh;
                case "захисний кожух": return ProvodTypePidklichenyas.kozhuh;
                case "УПЗ-земля": return ProvodTypePidklichenyas.upz;
                case "стор. комунік": return ProvodTypePidklichenyas.storKommunication;
                default: return ProvodTypePidklichenyas.undefined;

            }
        }
        public static int Integer(object obj)
        {
            if (obj == null) return 0;
            return int.Parse(obj.ToString().Trim());
        }
        public static double? DoubleNullable(object obj)
        {
            if (obj == null) return null;
            return double.Parse(obj.ToString().Replace(",", ".").Trim());
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
        public static StartEnd StartAndEnd(object obj)
        {
            if (obj == null) return StartEnd.undefined;
            switch (obj.ToString())
            {
                case "початок": return StartEnd.start;
                case "кінець": return StartEnd.end;
                default: return StartEnd.undefined;
            }
        }
    }
}
