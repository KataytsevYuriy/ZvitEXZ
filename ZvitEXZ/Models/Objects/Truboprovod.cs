using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Truboprovod : Zamer
    {
        public string TruboprovodName { get; set; }
        public string TruboprovodType { get; set; }
        public bool IsKorneb { get; set; }
        public bool IsVrezkaToAnoterTruboprovid { get; set; }
        public Truboprovod(object[] data) : base(data)
        {
            Name = ProjectConstants.TruboprovodName;

            if (data[69] == null)
            {
                TruboprovodName = "";
                Logs.AddError($"км {data[1]} укажите название трубопровода");
            }
            else
            {
                TruboprovodName = data[69].ToString();
            }

            if (data[70] == null)
            {
                TruboprovodType = "";
                Logs.AddError($"км {data[1]} укажите тип трубопровода");
            }
            else
            {
                TruboprovodType = data[70].ToString();
            }

            if (data[72] == null)
            {
                IsKorneb = true;
            }
            else
            {
                IsKorneb = false;
            }

            if (data[219] == null)
            {
                IsVrezkaToAnoterTruboprovid = false;
            }
            else
            {
                IsVrezkaToAnoterTruboprovid = true;
            }

        }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(TruboprovodName))
            {
                if (!String.IsNullOrEmpty(TruboprovodType))
                {
                    return $"{TruboprovodType} {TruboprovodName}";
                }
                else
                {
                    return $"{Name} {TruboprovodName}";
                }
            }
            return ProjectConstants.TruboprovodName;
        }
    }
}
