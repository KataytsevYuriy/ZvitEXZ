using System;
using System.Collections.Generic;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ListShurvesTiArray
    {
        public string[,] Convert(List<Shurf> shurves)
        {
            if (shurves.Count == 0) return new string[0, 0];
            string[,] res = new string[shurves.Count, 50];
            int i = 0;
            foreach (Shurf shurf in shurves)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = ConvertToString.FloatToString(shurf.Km);
                res[i, 2] = ConvertToString.FloatToString(shurf.Hlub);
                res[i, 3] = shurf.ShurfLength.Replace(".", ",");
                res[i, 4] = shurf.IsolationSquare.Replace(".", ",");
                res[i, 5] = shurf.IsolationGettingSquare.Replace(".", ",");
                res[i, 6] = shurf.MestnostCharacteristics;
                res[i, 7] = ConvertToString.FloatToString(shurf.Rhr);
                res[i, 8] = shurf.LitologHrunt;
                res[i, 9] = shurf.StanHruntu;
                res[i, 10] = shurf.NumbersObhortky;
                res[i, 11] = shurf.TypeOfObhortka;
                res[i, 12] = shurf.StanOfObhortka;
                res[i, 13] = shurf.PrylypannyaOfObhortka;
                res[i, 14] = shurf.IsMehPoshkodzhenObhortka;
                res[i, 15] = shurf.IzolationType1;
                res[i, 16] = shurf.IzolationType2;
                res[i, 17] = shurf.StanPoverhnyUp;
                res[i, 18] = shurf.StanPoverhnyDown;
                res[i, 19] = shurf.StanPoverhnyRight;
                res[i, 20] = shurf.StanPoverhnyLeft;
                res[i, 21] = shurf.IzolationStructure;
                res[i, 22] = shurf.Thin1SharUp.Replace(".", ",");
                res[i, 23] = shurf.Thin1SharDown.Replace(".", ",");
                res[i, 24] = shurf.Thin1SharRight.Replace(".", ",");
                res[i, 25] = shurf.Thin1SharLeft.Replace(".", ",");
                res[i, 26] = shurf.Thin2SharUp.Replace(".", ",");
                res[i, 27] = shurf.Thin2SharDown.Replace(".", ",");
                res[i, 28] = shurf.Thin2SharRight.Replace(".", ",");
                res[i, 29] = shurf.Thin2SharLeft.Replace(".", ",");
                res[i, 30] = shurf.IsHruntovka;
                res[i, 31] = shurf.Adheziya;
                res[i, 32] = shurf.Vologa;
                res[i, 33] = shurf.PipeTemperature.Replace(".", ",");
                res[i, 34] = shurf.StanPoverhnyPipe;
                res[i, 35] = shurf.SquareMetalPipe.Replace(".", ",");
                res[i, 36] = shurf.IsKorozyaExist;
                res[i, 37] = shurf.CharacterKorozii;
                res[i, 38] = shurf.KavernLength.Replace(".", ",");
                res[i, 39] = shurf.KavernHeight.Replace(".", ",");
                res[i, 40] = shurf.KavernPosition;
                res[i, 41] = shurf.UtzBeforShurf.Replace(".", ",");
                res[i, 42] = shurf.UtzAfterShurf.Replace(".", ",");
                res[i, 43] = shurf.UtzInShurf.Replace(".", ",");
                res[i, 44] = shurf.ShurfMadeOrganization;
                res[i, 45] = shurf.ShurfMadeUser;
                res[i, 46] = shurf.PredstavnykZakazchyka;
                res[i, 47] = shurf.DateOglyadu;
                res[i, 48] = shurf.PhotoPoverhny;
                res[i, 49] = String.IsNullOrEmpty(shurf.AktNumber) ? "" : $"Акт №{shurf.AktNumber}";
                i++;
            }
            return res;
        }
    }
}
