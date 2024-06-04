using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class UPZ : Zamer
    {
        public string BuildingDate { get; set; }
        public string ProtectorType { get; set; }
        public string ProtectorBuilder { get; set; }
        public string ProtectorCount { get; set; }
        public string DistanceToPipe { get; set; }
        public string HasPV { get; set; }
        public string ConnectionThruPV { get; set; }
        public string ProvodToPipe { get; set; }
        public string ProvodToProtector { get; set; }
        public string IUPZKozhuh { get; set; }
        public string UUPZGround { get; set; }
        public string KozuhGroundWithUPZ { get; set; }
        public string KozuhGroundWithoutUPZ { get; set; }
        public string HasContact { get; set; }


        public UPZ(object[] data) : base(data)
        {
            Name = ProjectConstants.UPZName;
            if (data[228] == null)
            {
                BuildingDate = "";
            }
            else
            {
                BuildingDate = data[228].ToString();
            }

            if (data[229] == null)
            {
                ProtectorType = "";
            }
            else
            {
                ProtectorType = data[229].ToString();
            }

            if (data[230] == null)
            {
                ProtectorBuilder = "";
            }
            else
            {
                ProtectorBuilder = data[230].ToString();
            }

            if (data[231] == null)
            {
                ProtectorCount = "";
            }
            else
            {
                ProtectorCount = data[231].ToString();
            }

            if (data[232] == null)
            {
                DistanceToPipe = "";
            }
            else
            {
                DistanceToPipe = data[232].ToString();
            }

            if (data[233] == null)
            {
                HasPV = "";
            }
            else
            {
                HasPV = data[233].ToString();
            }

            if (data[234] == null)
            {
                ConnectionThruPV = "";
            }
            else
            {
                ConnectionThruPV = data[234].ToString();
            }

            if (data[235] == null)
            {
                ProvodToProtector = "";
            }
            else
            {
                ProvodToProtector = data[235].ToString();
            }

            if (data[236] == null)
            {
                ProvodToPipe = "";
            }
            else
            {
                ProvodToPipe = data[236].ToString();
            }

            if (data[237] == null)
            {
                IUPZKozhuh = "";
            }
            else
            {
                IUPZKozhuh = data[237].ToString();
            }

            if (data[238] == null)
            {
                UUPZGround = "";
            }
            else
            {
                UUPZGround = data[238].ToString();
            }

            if (data[239] == null)
            {
                KozuhGroundWithoutUPZ = "";
            }
            else
            {
                KozuhGroundWithoutUPZ = data[239].ToString();
            }

            if (data[240] == null)
            {
                KozuhGroundWithUPZ = "";
            }
            else
            {
                KozuhGroundWithUPZ = data[240].ToString();
            }


            if (data[248] == null)
            {
                NumberSvyazky = 0;
            }
            else
            {
                try
                {
                    NumberSvyazky = (int)Parse.ParseFloat(data[248].ToString());
                }
                catch
                {
                    NumberSvyazky = 0;
                    Logs.AddError($"км {data[1]} неверный номерсвязки на УПЗ");
                }
            }

        }
        public override string ToString()
        {
            return ProjectConstants.UPZName;
        }
    }
}
