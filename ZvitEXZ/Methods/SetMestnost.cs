using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods
{
    public class SetMestnost
    {
        public List<Zamer> Set(List<Zamer> data)
        {
            MestnostType mestnostFlag = MestnostType.IndefinedType;
            bool balkaFlag = false;
            foreach (Zamer zamer in data)
            {
                if (zamer.Mestnost == MestnostType.BalkaStart)
                {
                    zamer.IsBalka = true;
                    balkaFlag = true;
                }
                else if (zamer.Mestnost == MestnostType.BalkaEnd)
                {
                    zamer.IsBalka = true;
                    balkaFlag = false;
                }
                else if (balkaFlag)
                {
                    zamer.IsBalka = true;
                }
                switch (zamer.Mestnost)
                {
                    case 0:
                        zamer.Mestnost = mestnostFlag;
                        break;
                    case (MestnostType)2:
                        zamer.Mestnost = MestnostType.CX;
                        mestnostFlag = MestnostType.CX;
                        break;
                    case (MestnostType)3:
                        zamer.Mestnost = MestnostType.CX;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)5:
                        zamer.Mestnost = MestnostType.PosBPros;
                        mestnostFlag = MestnostType.PosBPros;
                        break;
                    case (MestnostType)6:
                        zamer.Mestnost = MestnostType.PosBPros;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)8:
                        zamer.Mestnost = MestnostType.PosSPros;
                        mestnostFlag = MestnostType.PosSPros;
                        break;
                    case (MestnostType)9:
                        zamer.Mestnost = MestnostType.PosSPros;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)11:
                        zamer.Mestnost = MestnostType.LesBPros;
                        mestnostFlag = MestnostType.LesBPros;
                        break;
                    case (MestnostType)12:
                        zamer.Mestnost = MestnostType.LesBPros;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)14:
                        zamer.Mestnost = MestnostType.LesSPros;
                        mestnostFlag = MestnostType.LesSPros;
                        break;
                    case (MestnostType)15:
                        zamer.Mestnost = MestnostType.LesSPros;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)17:
                        zamer.Mestnost = MestnostType.Lug;
                        mestnostFlag = MestnostType.Lug;
                        break;
                    case (MestnostType)18:
                        zamer.Mestnost = MestnostType.Lug;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)20:
                        zamer.Mestnost = MestnostType.Zarosly;
                        mestnostFlag = MestnostType.Zarosly;
                        break;
                    case (MestnostType)21:
                        zamer.Mestnost = MestnostType.Zarosly;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)23:
                        zamer.Mestnost = MestnostType.ZabolHrunt;
                        mestnostFlag = MestnostType.ZabolHrunt;
                        break;
                    case (MestnostType)24:
                        zamer.Mestnost = MestnostType.ZabolHrunt;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)26:
                        zamer.Mestnost = MestnostType.Pustyr;
                        mestnostFlag = MestnostType.Pustyr;
                        break;
                    case (MestnostType)27:
                        zamer.Mestnost = MestnostType.Pustyr;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    case (MestnostType)29:
                        zamer.Mestnost = MestnostType.Sad;
                        mestnostFlag = MestnostType.Sad;
                        break;
                    case (MestnostType)30:
                        zamer.Mestnost = MestnostType.Sad;
                        mestnostFlag = MestnostType.IndefinedType;
                        break;
                    default:
                        zamer.Mestnost = mestnostFlag;
                        break;
                }
            }
            return data;
        }
    }
}
