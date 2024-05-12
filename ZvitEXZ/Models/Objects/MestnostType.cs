using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Objects
{
    public enum MestnostType
    {
        IndefinedType,
        CX, CXStart, CXEnd,
        PosBPros, PosBProsStart, PosBProsEnd,
        PosSPros, PosSProsStart, PosSProsEnd,
        LesBPros, LesBProsStart, LesBProsEnd,
        LesSPros, LesSProsStart, LesSProsEnd,
        Lug, LugStart, LugEnd,
        Zarosly, ZaroslyStart, ZaroslyEnd,
        ZabolHrunt, ZabolHruntStart, ZabolHruntEnd,
        Pustyr, PustyrStart, PustyrEnd,
        Sad, SadStart, SadEnd,
        BalkaStart, BalkaEnd,
        Error
    }
    public class MestnostToString
    {
        public string String(MestnostType mestnost)
        {
            switch (mestnost)
            {
                case MestnostType.CX: return Constants.MestnostCX;
                case MestnostType.PosBPros: return Constants.MestnostPosBPros;
                case MestnostType.PosSPros: return Constants.MestnostPosSPros;
                case MestnostType.LesBPros: return Constants.MestnostLesBPros;
                case MestnostType.LesSPros: return Constants.MestnostLesSPros;
                case MestnostType.Lug: return Constants.MestnostLug;
                case MestnostType.Zarosly: return Constants.MestnostZarosly;
                case MestnostType.ZabolHrunt: return Constants.MestnostPustyr;
                case MestnostType.Sad: return Constants.MestnostSad;
                default: return "";
            }
        }
    }
}
