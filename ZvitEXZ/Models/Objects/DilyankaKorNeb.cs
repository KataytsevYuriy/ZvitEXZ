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
            Name = ProjectConstants.DilyankaKorNebName;

            Border = ParseData.StartAndEnd(data[116]);
            if (Border == StartEnd.undefined)
            {
                Logs.AddError($"км {data[1]} укажіть межу кор-неб ділянки");
            }
            if (data[117] == null)
            {
                Reazon = CharacterCorneb.undefined;
                Logs.AddError($"км {data[1]} укажіть причину кор-неб ділянки");
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
                Logs.AddError($"км {data[1]} невірно вказана причина кор-неб ділянки");
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public enum CharacterCorneb { undefined, temperature, prommaydanchik, korridor, nebezpBludy }
    }
}
