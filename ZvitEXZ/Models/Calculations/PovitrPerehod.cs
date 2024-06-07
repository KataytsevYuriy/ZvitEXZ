using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.Calculations
{
    public class PovitrPerehod
    {
        public int KmStart { get; set; }
        public int KmFinish { get; set; }
        public string OpysPereshkody { get; set; }
        public string RezultOglyduPokrytta { get; set; }
        public string RezultOglyduPokryttaZemlyaPovitria { get; set; }
        public string PidcylKozhuh { get; set; }
        public double? UtzOn { get; set; }
        public double? UkozgOff { get; set; }
        public string Kontakt { get; set; }
        public PovitrPerehod(int kmStart, int kmFinish, string opysPereshkody, string rezultOglyduPokrytta, string rezultOglyduPokryttaZemlyaPovitria,
           string pidcylKozhuh, double? utzOn, double? ukozgOff, string kontakt)
        {
            KmStart = kmStart;
            KmFinish = kmFinish;
            OpysPereshkody = opysPereshkody;
            RezultOglyduPokrytta = rezultOglyduPokrytta;
            RezultOglyduPokryttaZemlyaPovitria = rezultOglyduPokryttaZemlyaPovitria;
            PidcylKozhuh = pidcylKozhuh;
            UtzOn = utzOn;
            UkozgOff = ukozgOff;
            Kontakt = kontakt;
        }
        public PovitrPerehod(VyhodIsZemly vyhodStart, VyhodIsZemly vyhodFinish)
        {
            if (vyhodStart.Km < vyhodFinish.Km)
            {
                KmStart = (int)Math.Round(vyhodStart.Km * 1000);
                KmFinish = (int)Math.Round(vyhodFinish.Km * 1000);
                OpysPereshkody = String.IsNullOrWhiteSpace(vyhodStart.OpysPereshkody) ? vyhodFinish.OpysPereshkody : vyhodStart.OpysPereshkody;
                RezultOglyduPokrytta = String.IsNullOrWhiteSpace(vyhodStart.RezultOglyduPokrytta) ? vyhodFinish.RezultOglyduPokrytta : vyhodStart.RezultOglyduPokrytta;
                RezultOglyduPokryttaZemlyaPovitria = String.IsNullOrWhiteSpace(vyhodStart.RezultOglyduPokryttaZemlyaPovitria) ? vyhodFinish.RezultOglyduPokryttaZemlyaPovitria : vyhodStart.RezultOglyduPokryttaZemlyaPovitria;
                PidcylKozhuh = String.IsNullOrWhiteSpace(vyhodStart.PidcylKozhuh) ? vyhodFinish.PidcylKozhuh : vyhodStart.PidcylKozhuh;
                UtzOn = vyhodStart.Utz ?? vyhodFinish.Utz;
                UkozgOff = vyhodStart.UkozgOff ?? vyhodFinish.UkozgOff;
                Kontakt = String.IsNullOrWhiteSpace(vyhodStart.Kontakt) ? vyhodFinish.Kontakt : vyhodStart.Kontakt;
            }
        }
    }
}
