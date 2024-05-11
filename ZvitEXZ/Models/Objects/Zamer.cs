using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Zamer
    {
        public float Km { get; set; }
        public float? Utz { get; set; }
        public float? Ugrad { get; set; }
        public float? Upol { get; set; }
        public string GpsN { get; set; }
        public string GpsE { get; set; }
        public string Gps { get; set; }
        public float? Rhr { get; set; }
        public float? Hlub { get; set; }
        public MestnostType Mestnost { get; set; }
        public bool IsBalka { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Zamer(object[] data)
        {
            if (data[1] == null) throw new ArgumentNullException("пустое значение КМ");
            try
            {
                Km = Parse.ParseFloat(data[1]);
            }
            catch
            {
                throw new ArgumentNullException("не верное значение КМ " + data[1].ToString());
            }
            if (data[3] == null) { Utz = null; }
            else
            {
                try
                {
                    Utz = Parse.ParseFloat(data[3]);
                }
                catch
                {
                    Utz = null;
                }
            }
            if (data[4] == null) { Ugrad = null; }
            else
            {
                try
                {
                    Ugrad = Parse.ParseFloat(data[4]);
                }
                catch
                {
                    Ugrad = null;
                }
            }
            if (data[5] == null) { Upol = null; }
            else
            {
                try
                {
                    Upol = Parse.ParseFloat(data[5]);
                }
                catch
                {
                    Upol = null;
                }
            }
            if (data[7] == null) { GpsN = ""; }
            else
            {
                GpsN = data[7].ToString();
            }
            if (data[8] == null) { GpsE = ""; }
            else
            {
                GpsE = data[8].ToString();
            }
            if (data[10] == null) { Gps = ""; }
            else
            {
                Gps = data[10].ToString();
            }
            if (data[11] == null) { Rhr = null; }
            else
            {
                try
                {
                    Rhr = Parse.ParseFloat(data[11]);
                }
                catch
                {
                    Rhr = null;
                }
            }
            if (data[12] == null) { Hlub = null; }
            else
            {
                try
                {
                    Hlub = Parse.ParseFloat(data[12]);
                }
                catch
                {
                    Hlub = null;
                }
            }
            Mestnost = Parse.Mestnost(data[13]);
            IsBalka = false;
            Name = "";
            if (data[303] == null)
            {
                Note = "";
            }
            else
            {
                Note = data[303].ToString();
            }
        }
    }
}
