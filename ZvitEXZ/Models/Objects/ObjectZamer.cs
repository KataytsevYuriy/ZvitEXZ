﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZvitEXZ.Methods;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Objects
{
    internal class ObjectZamer : Zamer
    {
        public string ObjectName { get; set; }
        public double? Uobject { get; set; }
        public ObjectZamer(object[] data) : base(data)
        {
            Name = ProjectConstants.ObjectName;

            if (data[221] == null)
            {
                ObjectName = "";
                Logs.AddError($"км {data[1]} вкажіть назвау об'екта");
            }
            else
            {
                ObjectName = data[221].ToString();
            }

            try
            {
                Uobject = ParseData.DoubleNullable(data[76]);
            }
            catch
            {
                Uobject = null;
                Logs.AddError($"км {data[1]} Невірний потенціал об'екта");
            }
            IsOrientir=true;
        }
        public override string ToString()
        {
            return String.IsNullOrEmpty(ObjectName) ? Name : ObjectName;
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjObjecstZamer;
        }
        public override string GetCadSignature()
        {
            if (!string.IsNullOrEmpty(ObjectName))
                return $"{Name} {ObjectName}";
            return base.GetCadSignature();
        }
    }
}
