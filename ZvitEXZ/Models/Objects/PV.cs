using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Objects
{
    public class PV : Zamer
    {
        public string PVType { get; set; }
        public string PVDiamert { get; set; }
        public string ProvodPotencial1 { get; set; }
        public string ProvodType1 { get; set; }
        public string ProvodDyamert1 { get; set; }
        public string ProvodTypePidklichenya1 { get; set; }
        public string ProvodPotencial2 { get; set; }
        public string ProvodType2 { get; set; }
        public string ProvodDaymetr2 { get; set; }
        public string ProvodTypePidklichenya2 { get; set; }
        public string ProvodPotencial3 { get; set; }
        public string ProvodType3 { get; set; }
        public string ProvodDyametr3 { get; set; }
        public string ProvodTypePidklichenya3 { get; set; }
        public bool IsBroken { get; set; }
        public string NumberSvyazky { get; set; }
        public PV(object[] data) : base(data)
        {
            Name = Constants.PVName;
            if (data[26] == null)
            {
                PVType = "";
            }
            else
            {
                PVType = data[26].ToString();
            }
            if (data[27] == null)
            {
                PVDiamert = "";
            }
            else
            {
                PVDiamert = data[27].ToString();
            }
            if (data[30] == null)   //провод - 1
            {
                ProvodPotencial1 = "";
            }
            else
            {
                ProvodPotencial1 = data[30].ToString();
            }
            if (data[32] == null)
            {
                ProvodType1 = "";
            }
            else
            {
                ProvodType1 = data[32].ToString();
            }
            if (data[33] == null)
            {
                ProvodDyamert1 = "";
            }
            else
            {
                ProvodDyamert1 = data[33].ToString();
            }
            if (data[34] == null)
            {
                ProvodTypePidklichenya1 = "";
            }
            else
            {
                ProvodTypePidklichenya1 = data[34].ToString();
            }
            if (data[35] == null)   //провод - 2
            {
                ProvodPotencial2 = "";
            }
            else
            {
                ProvodPotencial2 = data[35].ToString();
            }
            if (data[36] == null)
            {
                ProvodType2 = "";
            }
            else
            {
                ProvodType2 = data[36].ToString();
            }
            if (data[37] == null)
            {
                ProvodDaymetr2 = "";
            }
            else
            {
                ProvodDaymetr2 = data[37].ToString();
            }
            if (data[38] == null)
            {
                ProvodTypePidklichenya2 = "";
            }
            else
            {
                ProvodTypePidklichenya2 = data[38].ToString();
            }
            if (data[39] == null)   //провод - 3
            {
                ProvodPotencial3 = "";
            }
            else
            {
                ProvodPotencial3 = data[39].ToString();
            }
            if (data[40] == null)
            {
                ProvodType3 = "";
            }
            else
            {
                ProvodType3 = data[40].ToString();
            }
            if (data[41] == null)
            {
                ProvodDyametr3 = "";
            }
            else
            {
                ProvodDyametr3 = data[41].ToString();
            }
            if (data[42] == null)
            {
                ProvodTypePidklichenya3 = "";
            }
            else
            {
                ProvodTypePidklichenya3 = data[42].ToString();
            }
            if (data[227] == null)
            {
                IsBroken = false;
            }
            else
            {
                IsBroken = true;
            }
            if (data[248] == null)
            {
                NumberSvyazky = "";
            }
            else
            {
                NumberSvyazky = data[248].ToString();
            }
        }
    }
}
