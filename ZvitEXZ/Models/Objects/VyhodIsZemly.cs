using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class VyhodIsZemly : Zamer
    {
        public PerehodTypes PerehodType { get; set; }
        public Flanets Flanets { get; set; }
        public string OpysPereshkody { get; set; }
        public string RezultOglyduPokrytta { get; set; }
        public string RezultOglyduPokryttaZemlyaPovitria { get; set; }
        public string PidcylKozhuh { get; set; }
        public float? UkozgOff { get; set; }
        public string Kontakt { get; set; }

        public VyhodIsZemly(object[] data) : base(data)
        {
            Name = ProjectConstants.VyhodIsZemlyName;
            string flanetsPlace = "";
            if (data[109] == null)
            {
                PerehodType = PerehodTypes.undefined;
            }
            else if (data[109].ToString() == "початок")
            {
                PerehodType = PerehodTypes.start;
                flanetsPlace = "на початку переходу";
            }
            else
            {
                PerehodType = PerehodTypes.finish;
                flanetsPlace = "в кінці переходу";
            }
            Flanets = new Flanets(Km, $"{Name} км {ConvertToString.FloatToString(Km)}", "-", data[209], data[210],
                data[110], data[111], data[123], flanetsPlace, data[211], data[224]);
            if (data[249] == null) { OpysPereshkody = ""; }
            else { OpysPereshkody = data[249].ToString(); }
            if (data[250] == null) { RezultOglyduPokrytta = ""; }
            else { RezultOglyduPokrytta = data[250].ToString(); }
            if (data[251] == null) { RezultOglyduPokryttaZemlyaPovitria = ""; }
            else { RezultOglyduPokryttaZemlyaPovitria = data[251].ToString(); }
            if (data[252] == null) { PidcylKozhuh = ""; }
            else { PidcylKozhuh = data[252].ToString(); }
            if (data[254] == null) { UkozgOff = null; }
            else { UkozgOff = ParseData.FloatNullable(data[254]); }
            if (data[255] == null) { Kontakt = ""; }
            else { Kontakt = data[255].ToString(); }
        }
        public override string ToString()
        {
            if (PerehodType == PerehodTypes.start) return $"{Name} початок";
            if (PerehodType == PerehodTypes.finish) return $"{Name} кінець";
            return Name;
        }
    }
    public enum PerehodTypes { undefined, start, finish }
}
