using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ListPovitrPerehToMassive
    {
        public string[,] Convert(List<PovitrPerehod> perehods)
        {
            if (perehods.Count == 0) return new string[0, 0];
            string[,] res = new string[perehods.Count, 11];
            int i = 0;
            foreach (PovitrPerehod perehod in perehods)
            {
                res[i, 0] = perehod.KmStart.ToString();
                res[i, 1] = perehod.KmFinish.ToString();
                res[i, 2] = (perehod.KmFinish - perehod.KmStart).ToString();
                res[i, 3] = perehod.OpysPereshkody;
                res[i, 4] = perehod.RezultOglyduPokrytta;
                res[i, 5] = perehod.RezultOglyduPokryttaZemlyaPovitria;
                res[i, 6] = perehod.PidcylKozhuh;
                res[i, 7] = ConvertToString.FloatToString(perehod.UtzOn);
                res[i, 8] = ConvertToString.FloatToString(perehod.UkozgOff);
                res[i, 9] = perehod.Kontakt;
                res[i, 10] = "";
                i++;
            }
            return res;
        }
    }
}