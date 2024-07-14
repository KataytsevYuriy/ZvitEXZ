using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class DrawMestnost
    {
        AcadDoc acadDoc;
        CalculateCoordinateX X;
        MestnostToString mestnost;

        public void AddMestnost(ref AcadDoc acadDoc, List<Zamer> zamers, CalculateCoordinateX X)
        {
            this.acadDoc = acadDoc;
            this.X = X;
            mestnost = new MestnostToString();
            MestnostType lastMestnost = MestnostType.IndefinedType;
            double lastkm = -1;
            acadDoc.DrawingSteps.Add(new DrawLayer(AcadConstants.LayerText));
            foreach (Zamer zamer in zamers)
            {
                if (lastMestnost == zamer.Mestnost && zamer.Km - lastkm >= AcadConstants.RepeatObjectsEvery)
                {
                    if (zamer.Mestnost != MestnostType.CX && zamer.Mestnost!=MestnostType.Pustyr)
                    {
                        Draw(zamer.Mestnost, zamer.Km);
                        lastkm = zamer.Km;
                        lastMestnost = zamer.Mestnost;
                    }
                }
                else if (lastMestnost != zamer.Mestnost)
                {
                    Draw(zamer.Mestnost, zamer.Km);
                    lastkm = zamer.Km;
                    lastMestnost = zamer.Mestnost;
                }
                if(zamer.Balka==MestnostType.BalkaStart || zamer.Balka == MestnostType.BalkaEnd)
                {
                    Draw(zamer.Balka, zamer.Km);

                }
            }
        }
        private void Draw(MestnostType mestnostType, double km)
        {
            if (mestnostType == MestnostType.Pustyr) return;            // do not draw Pustyr
            if (mestnostType != MestnostType.IndefinedType)
                acadDoc.DrawingSteps.Add(new DrawBlock(mestnost.CadName(mestnostType), X.Calkulate(km), AcadConstants.PipeStartY));
        }
    }
}
