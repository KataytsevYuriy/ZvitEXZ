using AutoCAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.AcadModels;

namespace ZvitEXZ.Methods.AcadMethods
{
    internal class Drivepotencial
    {
        public void Drive(List<ListPotencials> listPotencials, AcadApplication acadApplication)
        {
            foreach (ListPotencials p in listPotencials)
            {
                if (p.Potencials.Count > 1)
                {
                    double[,] pot = new double[p.Potencials.Count, 3];
                    int i = 0;
                    foreach (Potencial potencial in p.Potencials)
                    {
                        pot[i, 0] = potencial.Km;
                        pot[i, 1] = potencial.U;
                        pot[i, 2] = 0;
                        i++;
                    }
                    acadApplication.ActiveDocument.ModelSpace.AddPolyline(pot);
                }

            }
        }
    }
}
