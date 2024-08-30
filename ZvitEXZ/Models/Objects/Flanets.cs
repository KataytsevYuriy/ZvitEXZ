using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Flanets
    {
        public string ObjectName { get; set; }
        public string BuildingDate { get; set; }
        public double? UbeforeOn { get; set; }
        public double? UafterOn { get; set; }
        public double? UbeforeOff { get; set; }
        public double? UafterOff { get; set; }
        public double? Irezistor { get; set; }
        public FlanetsTypes FlanetsType { get; set; }
        public string FlanetsPlace { get; set; }
        public string MontageType { get; set; }
        public FlanestAtistation AtestationVimiryv { get; set; }
        public Flanets(double km, string objectName, string buildingDate, object ubeforeOn, object uafterOn, object ubeforeOff, object uafterOff, object flanetsType,
            string flanetsPlace, object atestationVimiryv, object montageType)
        {
            ObjectName = objectName;
            BuildingDate = buildingDate;
            try
            {
                UbeforeOn = ParseData.DoubleNullable(ubeforeOn);
            }
            catch
            {
                UbeforeOn = null;
            }
            try
            {
                UafterOn = ParseData.DoubleNullable(uafterOn);
            }
            catch
            {
                UafterOn = null;
            }
            try
            {
                UbeforeOff = ParseData.DoubleNullable(ubeforeOff);
            }
            catch
            {
                UbeforeOff = null;
            }
            try
            {
                UafterOff = ParseData.DoubleNullable(uafterOff);
            }
            catch
            {
                UafterOff = null;
            }
            Irezistor = null;
            if (flanetsType == null) { FlanetsType = FlanetsTypes.undefined; }
            else if (flanetsType.ToString() == "ізолюючий") { FlanetsType = FlanetsTypes.isolative; }
            else if (flanetsType.ToString() == "ізолююча муфта") { FlanetsType = FlanetsTypes.mufta; }
            else if (flanetsType.ToString() == "не ізолюючий") { FlanetsType = FlanetsTypes.noIsolative; }
            else if (flanetsType.ToString() == "відсутній") { FlanetsType = FlanetsTypes.isEmpty; }
            else
            {
                FlanetsType = FlanetsTypes.undefined;
                Logs.AddError($"км {km} невірно вказаний тип фланця");
            }
            FlanetsPlace = flanetsPlace;
            if (atestationVimiryv == null) { AtestationVimiryv = FlanestAtistation.undefined; }
            else if (atestationVimiryv.ToString() == "так") { AtestationVimiryv = FlanestAtistation.yes; }
            else if (atestationVimiryv.ToString() == "ні") { AtestationVimiryv = FlanestAtistation.no; }
            else { AtestationVimiryv = FlanestAtistation.undefined; }
            if (montageType == null) { MontageType = ""; }
            else { MontageType = montageType.ToString(); }
        }
        public string GetAtestation()
        {
            if (AtestationVimiryv == FlanestAtistation.yes) return "так";
            if (AtestationVimiryv == FlanestAtistation.no) return "ні";
            return "";
        }
    }
}
