using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;

namespace ZvitEXZ.Methods.Calculations
{
    internal class TrimGradient
    {
        public List<AcadZamer> Trim(List<AcadZamer> data, out List<AcadZamer> trimmed)
        {
            List<AcadZamer> res = new List<AcadZamer>();
            trimmed = new List<AcadZamer>();
            if (data.Count == 0) return res;
            double lastKm = -1, lastVal = 0;
            double maxKm = data.First().Km, maxVal = 0;
            double trimValue = AcadConstants.UgradMax;
            Crossing crossing = new Crossing(trimValue, false);
            foreach (AcadZamer zamer in data)
            {
                if (zamer.Value == null) continue;
                if (maxVal < 0 && zamer.Km - lastKm > AcadConstants.AcadMaxDrawingStep)
                {
                    trimmed.Add(new AcadZamer(maxKm, maxVal));
                    maxVal = 0;
                    lastKm = -1;
                }
                if (lastKm == -1 || (lastVal >= trimValue && zamer.Value >= trimValue))
                {
                    lastKm = zamer.Km;
                    lastVal = (double)zamer.Value;
                    if (zamer.Value < trimValue)
                    {
                        maxKm = zamer.Km;
                        maxVal = (double)zamer.Value;
                        res.Add(new AcadZamer(maxKm, trimValue));
                    }
                    else { res.Add(zamer); }
                    continue;
                }
                if (lastVal < trimValue && zamer.Value < trimValue)
                {
                    lastKm = zamer.Km;
                    lastVal = (double)zamer.Value;
                    res.Add(new AcadZamer(lastKm, trimValue));
                    if (maxVal > zamer.Value)
                    {
                        maxKm = zamer.Km;
                        maxVal = (double)zamer.Value;
                    }
                    continue;
                }
                if (lastVal >= trimValue && zamer.Value < trimValue)  //стало повреждением
                {
                    double km = crossing.GetCrossing(lastVal, lastKm, (double)zamer.Value, zamer.Km);
                    res.Add(new AcadZamer(km, trimValue));
                    res.Add(new AcadZamer(zamer.Km, trimValue));
                    lastKm = zamer.Km;
                    lastVal = (double)zamer.Value;
                    maxKm = zamer.Km;
                    maxVal = (double)zamer.Value;
                    continue;
                }
                if (lastVal < trimValue && zamer.Value >= trimValue)  //ушло повреждение
                {
                    double km = crossing.GetCrossing(lastVal, lastKm, (double)zamer.Value, zamer.Km);
                    res.Add(new AcadZamer(km, trimValue));
                    res.Add(new AcadZamer(zamer.Km, trimValue));
                    trimmed.Add(new AcadZamer(maxKm, maxVal));
                    lastKm = zamer.Km;
                    lastVal = (double)zamer.Value;
                    maxVal = 0;
                }
            }
            if (maxVal < 0) trimmed.Add(new AcadZamer(maxKm, maxVal));
            return res;
        }
    }
}
