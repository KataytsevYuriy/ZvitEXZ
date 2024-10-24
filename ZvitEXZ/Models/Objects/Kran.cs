﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Kran : Zamer
    {
        public string KranNumber { get; set; }
        public double? UKrana { get; set; }
        public Kran(object[] data) : base(data)
        {
            Name = ProjectConstants.KranName;
            if (data[75] == null)
            {
                KranNumber = "";
                Logs.AddError($"км {Km} вкажіть номер крана");
            }
            else
            {
                KranNumber = data[75].ToString().Replace(".", ",");
            }
            if (data[76] == null)
            {
                UKrana = null;
                Logs.AddError($"км {Km} вкажіть потенціал крана");
            }
            else
            {
                try
                {
                    UKrana = ParseData.DoubleNullable(data[76]);
                }
                catch
                {
                    UKrana = null;
                    Logs.AddError($"км {Km} вкажіть потенціал крана");
                }
            }
            if (UKrana != null && Utz != null)
            {
                if(Math.Abs( (double)UKrana -(double)Utz)>0.011) 
                    Logs.AddError($"км {Km} захисний потенціал не дорівнює потенціалу крана");
            }
            IsOrientir = true;
        }
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(KranNumber)) return $"{ProjectConstants.KranName} №{KranNumber}";
            return ProjectConstants.KranName;
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjKran;
        }
        public override string GetCadSignature()
        {
            return ToString();
        }
    }
}
