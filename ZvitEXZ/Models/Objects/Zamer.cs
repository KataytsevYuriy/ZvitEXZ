﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Zamer
    {
        public double Km { get; set; }
        public double? Utz { get; set; }
        public double? Ugrad { get; set; }
        public double? Upol { get; set; }
        public string GpsN { get; set; }
        public string GpsE { get; set; }
        public string Gps { get; set; }
        public double? Rhr { get; set; }
        public double? Hlub { get; set; }
        public MestnostType Mestnost { get; set; }
        public MestnostType Balka { get; set; }
        public bool IsBalka { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int NumberSvyazky { get; set; }
        public double? Ph { get; set; }
        public string ErrorMessageStart { get; set; }
        public bool IsOrientir { get; set; }
        public Zamer(object[] data)
        {
            if (data[1] == null)
            {
                throw new ArgumentNullException("пусте значення КМ");
            }
            try
            {
                Km = Parse.ParseDouble(data[1]);
            }
            catch
            {
                throw new ArgumentNullException("невірне значення КМ " + data[1].ToString());
            }
            ErrorMessageStart = $"км {ConvertToString.DoubleToString(Km)}";
            try
            {
                Utz = ParseData.DoubleNullable(data[3]);
                if (Math.Abs((double)Utz) > 3.5) Logs.AddError($"км {Km} повинен бути > -3,5В и <3,5В");
            }
            catch
            {
                Utz = null;
            }

            try
            {
                Ugrad = ParseData.DoubleNullable(data[4]);
            }
            catch
            {
                Ugrad = null;
            }
            if (Utz == null ^ Ugrad == null)
            {
                Logs.AddAlarm($"км {data[1]} введен лише захисний або лише градіент");
                Logs.AddAlarm($"Потенціали ВИДАЛЕНІ");
                Utz = null;
                Ugrad = null;
            }

            try
            {
                Upol = ParseData.DoubleNullable(data[5]);
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
                Rhr = ParseData.DoubleNullable(data[11]);
            }
            catch
            {
                Rhr = null;
            }

            try
            {
                Hlub = ParseData.DoubleNullable(data[12]);
            }
            catch
            {
                Hlub = null;
            }
            if (data[305] == null) { Ph = null; }
            else
            {
                try
                {
                    Ph = ParseData.DoubleNullable(data[305]);
                }
                catch
                {
                    Ph = null;
                    Logs.AddError($"км {ConvertToString.DoubleToString(Km)} введено невірное значення Ph");
                }
            }
            Mestnost = ParseData.Mestnost(data[13]);
            if (Mestnost == MestnostType.BalkaStart || Mestnost == MestnostType.BalkaEnd) { Balka = Mestnost; }
            else { Balka = MestnostType.IndefinedType; }
            IsBalka = false;
            Name = "";
            Note = ParseData.String(data[303]);
            IsOrientir = false;
        }
        public Zamer(double km, string gpsN, string gpsE)
        {
            Km = km;
            GpsN = gpsN;
            GpsE = gpsE;
        }
        public override string ToString()
        {
            return "";
        }
        public virtual string GetCadType()
        {
            return "";
        }
        public virtual string GetCadSignature()
        {
            return "";
        }
    }
}
