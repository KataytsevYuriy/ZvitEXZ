using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class PV : Zamer
    {
        public string PVType { get; set; }
        public string PVDiamert { get; set; }
        public double? ProvodPotencial1 { get; set; }
        public string ProvodType1 { get; set; }
        public string ProvodDyamert1 { get; set; }
        public ProvodTypePidklichenyas ProvodTypePidklichenya1 { get; set; }
        public double? ProvodPotencial2 { get; set; }
        public string ProvodType2 { get; set; }
        public string ProvodDaymetr2 { get; set; }
        public ProvodTypePidklichenyas ProvodTypePidklichenya2 { get; set; }
        public double? ProvodPotencial3 { get; set; }
        public string ProvodType3 { get; set; }
        public string ProvodDyametr3 { get; set; }
        public ProvodTypePidklichenyas ProvodTypePidklichenya3 { get; set; }
        public bool IsBroken { get; set; }
        public string Description { get; set; }
        public PV(object[] data) : base(data)
        {
            Name = ProjectConstants.PVName;
            PVType = ParseData.String(data[26]);
            PVDiamert = ParseData.String(data[27]);
            try
            {
                ProvodPotencial1 = ParseData.DoubleNullable(data[30]);//провод - 1
                ProvodType1 = ParseData.String(data[32]);
                ProvodDyamert1 = ParseData.String(data[33]);
                ProvodTypePidklichenya1 = ParseData.ProvodTypePidklichenya(data[34]);
                ProvodPotencial2 = ParseData.DoubleNullable(data[35]); //провод - 2
                ProvodType2 = ParseData.String(data[36]);
                ProvodDaymetr2 = ParseData.String(data[37]);
                ProvodTypePidklichenya2 = ParseData.ProvodTypePidklichenya(data[38]);
                ProvodPotencial3 = ParseData.DoubleNullable(data[39]);  //провод - 3
                ProvodType3 = ParseData.String(data[40]);
                ProvodDyametr3 = ParseData.String(data[41]);
                ProvodTypePidklichenya3 = ParseData.ProvodTypePidklichenya(data[42]);
            }
            catch
            {
                ProvodTypePidklichenya1 = ProvodTypePidklichenyas.undefined;
                ProvodTypePidklichenya2 = ProvodTypePidklichenyas.undefined;
                ProvodTypePidklichenya2 = ProvodTypePidklichenyas.undefined;
                Logs.AddError($"км {data[1]} перевірте потенціал на проводах");
            }
            if (data[227] == null)
            {
                IsBroken = false;
            }
            else
            {
                IsBroken = true;
            }
            try
            {
                NumberSvyazky = ParseData.Integer(data[248]);
            }
            catch
            {
                NumberSvyazky = 0;
                Logs.AddError($"км {data[1]} перевірте номер привязки");
            }
            IsOrientir = true;
        }
        public PV(double km, string gpsN, string gpsE, double? utz, string description) : base(km, gpsN, gpsE)
        {
            ProvodPotencial1 = utz;
            Description = description;
            ProvodTypePidklichenya1 = ProvodTypePidklichenyas.undefined;
            ProvodTypePidklichenya2 = ProvodTypePidklichenyas.undefined;
            ProvodTypePidklichenya2 = ProvodTypePidklichenyas.undefined;
        }
        public string GetTypepidkluchennya(int provodNumber)
        {
            switch (provodNumber)
            {
                case 1: return GetProvodType(ProvodTypePidklichenya1);
                case 2: return GetProvodType(ProvodTypePidklichenya2);
                case 3: return GetProvodType(ProvodTypePidklichenya3);
                default: return "";
            }
        }
        private string GetProvodType(ProvodTypePidklichenyas type)
        {
            switch (type)
            {
                case ProvodTypePidklichenyas.pipe: return "трубопровід";
                case ProvodTypePidklichenyas.pointDrenazh: return "потенціал труба - земля в точці дренажа";
                case ProvodTypePidklichenyas.kozhuh: return "захисний кожух";
                case ProvodTypePidklichenyas.upz: return "УПЗ-земля";
                case ProvodTypePidklichenyas.storKommunication: return "стороння комунікація";
                default: return "";
            }
        }
        public override string ToString()
        {
            return Name;
        }
        public override string GetCadType()
        {
            if (IsBroken) return AcadConstants.ObjPVNwork;
            return AcadConstants.ObjPV;
        }
    }
}
