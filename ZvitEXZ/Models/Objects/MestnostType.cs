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
        RiverPoyma, RiverPoymaStart,RiverPoymaEnd,
        BalkaStart, BalkaEnd,
        Error
    }
    public class MestnostToString
    {
        public string String(MestnostType mestnost)
        {
            switch (mestnost)
            {
                case MestnostType.CX: return ProjectConstants.MestnostCX;
                case MestnostType.PosBPros: return ProjectConstants.MestnostPosBPros;
                case MestnostType.PosSPros: return ProjectConstants.MestnostPosSPros;
                case MestnostType.LesBPros: return ProjectConstants.MestnostLesBPros;
                case MestnostType.LesSPros: return ProjectConstants.MestnostLesSPros;
                case MestnostType.Lug: return ProjectConstants.MestnostLug;
                case MestnostType.Zarosly: return ProjectConstants.MestnostZarosly;
                case MestnostType.ZabolHrunt: return ProjectConstants.MestnostZabolHrunt;
                case MestnostType.Sad: return ProjectConstants.MestnostSad;
                case MestnostType.RiverPoyma: return ProjectConstants.MestnostPoyma;
                default: return "";
            }
        }
    public string CadName(MestnostType mestnost)
        {
            switch (mestnost)
            {
                case MestnostType.CX: return AcadConstants.MestnostCX;
                case MestnostType.PosBPros: return AcadConstants.MestnostPosBPros;
                case MestnostType.PosSPros: return AcadConstants.MestnostPosSPros;
                case MestnostType.LesBPros: return AcadConstants.MestnostLesBPros;
                case MestnostType.LesSPros: return AcadConstants.MestnostLesSPros;
                case MestnostType.Lug: return AcadConstants.MestnostLug;
                case MestnostType.Zarosly: return AcadConstants.MestnostZarosly;
                case MestnostType.ZabolHrunt: return AcadConstants.MestnostZabolHrunt;
                case MestnostType.Sad: return AcadConstants.MestnostSad;
                case MestnostType.BalkaStart: return AcadConstants.MestnostBalkaStart;
                case MestnostType.BalkaEnd: return AcadConstants.MestnostBalkaEnd;
                //case MestnostType.RiverPoyma: return AcadConstants.MestnostBalkaEnd;
                default: return "";
            }
        }
    }
}
