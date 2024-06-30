using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Methods.File.Converters;

namespace ZvitEXZ.Methods.File
{
    public class ConvertListToFile
    {
        public object[,] ConvertPV(List<PV> data)
        {
            ConvertPvToArray convertPv = new ConvertPvToArray();
            return convertPv.Convert(data);
        }
        public string[,] ConvertKorneb(List<KorNebezpechny> kornebs)
        {
            ConvertKornebToArray convert = new ConvertKornebToArray();
            return convert.Convert(kornebs);
        }
        public object[,] ConvertNezah(List<Nezahyst> data)
        {
            ConvertNezahToArray convert = new ConvertNezahToArray();
            return convert.Convert(data);
        }
        public object[,] ConvertUKZ(List<Zamer> data)
        {
            ConvertUKZToArray convert = new ConvertUKZToArray();
            return convert.Convert(data);
        }
        public object[,] ConvertPovregd(List<Povregdenya> data)
        {
            ConvertPovregdToAtrray convert = new ConvertPovregdToAtrray();
            return convert.Convert(data);
        }
        public object[,] ConvertUpz(List<UPZ> data)
        {
            ConvertUPZToArray convert = new ConvertUPZToArray();
            return convert.Convert(data);
        }
        public object[,] ConvertVymirKozhuh(List<RoadKozhuh> roadKozhuhs)
        {
            ConvertVymirKozhuhToArray convert = new ConvertVymirKozhuhToArray();
            return convert.Convert(roadKozhuhs);
        }
        public object[,] ConvertStanNaPerehode(List<RoadKozhuh> data)
        {
            ConvertRoadKozhuhToArray convertTo = new ConvertRoadKozhuhToArray();
            return convertTo.Convert(data);
        }
        public string[,] ConvertFlantsy(List<Flanets> flantsy)
        {
            ConvertFlanetsToArray converter = new ConvertFlanetsToArray();
            return converter.Convert(flantsy);
        }
        public string[,] ConvertPovitrPerehody(List<PovitrPerehod> povitrPerehody)
        {
            ConvertPovitrPerehToArray converter = new ConvertPovitrPerehToArray();
            return converter.Convert(povitrPerehody);
        }
        public string[,] ConvertShurfy(List<Shurf> shurves)
        {
            ConvertShurvesToArray converter = new ConvertShurvesToArray();
            return converter.Convert(shurves);
        }
        public string[,] ConvertNenormHlubyna(List<NenormHlubyna> nenormHlubyna)
        {
            ConvertNeonrmHlubToArray converter = new ConvertNeonrmHlubToArray();
            return converter.Convert(nenormHlubyna);
        }
        public string[,] ConvertStatistics(Statistics statistics)
        {
            StatisticToArray converter = new StatisticToArray();
            return converter.Convert(statistics);
        }
        public object[,] ConvertPovregdGNT(List<PovregdenyaGNT> povregdGNT)
        {
            ConvertPovregdGNTToArray converter = new ConvertPovregdGNTToArray();
            return converter.Convert(povregdGNT);
        }
        public object[,] ConvertZvedena(List<Zamer> zamers, List<KorNebezpechny> korNebezpechnies, List<Povregdenya> povregdenyas)
        {
            ConvertZamersToZvedena converter = new ConvertZamersToZvedena(zamers, korNebezpechnies, povregdenyas);
            return converter.Convert();
        }
    }
}
