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
        public int NumberSvyazky { get; set; }

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
            try
            {
                Utz = ParseData.FloatNullable(data[3]);
            }
            catch
            {
                Utz = null;
            }

            try
            {
                Ugrad = ParseData.FloatNullable(data[4]);
            }
            catch
            {
                Ugrad = null;
            }
            if (Utz == null ^ Ugrad == null)
            {
                Logs.AddAlarm($"км {data[1]} введен только защитный либо только градиент");
                Logs.AddAlarm($"Потенциалы УДАЛЕНЫ");
                Utz = null;
                Ugrad = null;

            }

            try
            {
                Upol = ParseData.FloatNullable(data[5]);
            }
            catch
            {
                Upol = null;
            }
            GpsN = ParseData.String(data[7]);
            GpsE = ParseData.String(data[8]);
            Gps = ParseData.String(data[10]);
            try
            {
                Rhr = ParseData.FloatNullable(data[11]);
            }
            catch
            {
                Rhr = null;
            }

            try
            {
                Hlub = ParseData.FloatNullable(data[12]);
            }
            catch
            {
                Hlub = null;
            }
            Mestnost = ParseData.Mestnost(data[13]);
            IsBalka = false;
            Name = "";
            Note = ParseData.String(data[303]);
        }
        public override string ToString()
        {
            return "";
        }
    }
}
