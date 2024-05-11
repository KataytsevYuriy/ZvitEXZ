using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models
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
}
