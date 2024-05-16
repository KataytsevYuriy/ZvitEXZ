using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class DilyankaKorNeb : Zamer
    {
        public StartEnd Border { get; set; }
        public CharacterCorneb Reazon { get; set; }
        public DilyankaKorNeb(object[] data) : base(data)
        {
            Name = Constants.DilyankaKorNebName;

            if (data[116] == null)
            {
                Border = StartEnd.undefined;
                Logs.AddError($"км {data[1]} укажите границу кор-неб участка");
            }
            else if (data[116].ToString() == "початок")
            {
                Border = StartEnd.start;
            }
            else if (data[116].ToString() == "кінець")
            {
                Border = StartEnd.end;
            }
            else
            {
                Border = StartEnd.undefined;
                Logs.AddError($"км {data[1]} неверно указана граница кор-неб участка");
            }

            if (data[117] == null)
            {
                Reazon = CharacterCorneb.undefined;
                Logs.AddError($"км {data[1]} укажите причину кор-неб участка");
            }
            else if (data[117].ToString() == "t газа > 40°")
            {
                Reazon = CharacterCorneb.temperature;
            }
            else if (data[117].ToString() == "територія проммайданчика")
            {
                Reazon = CharacterCorneb.prommaydanchik;
            }
            else if (data[117].ToString() == "техн. коридор")
            {
                Reazon = CharacterCorneb.korridor;
            }
            else if (data[117].ToString() == "блук.стр. Небезп. дії")
            {
                Reazon = CharacterCorneb.nebezpBludy;
            }
            else
            {
                Reazon = CharacterCorneb.undefined;
                Logs.AddError($"км {data[1]} неверно указана причина кор-неб участка");
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public enum CharacterCorneb { undefined, temperature, prommaydanchik, korridor, nebezpBludy }
    }
}
