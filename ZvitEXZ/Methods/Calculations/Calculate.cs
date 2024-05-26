using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Methods.File;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    public class Calculate
    {
        List<Nezahyst> nezahysts;
        List<KorNebezpechny> korNebezpechny;
        List<Povregdenya> povregdenyas;
        List<RoadKozhuh> roadKozhuhs;
        public void CalculateAll(List<Zamer> zamers, ExcelDictionary dictionary)
        {
            SetMestnost setMestnost = new SetMestnost();
            zamers = setMestnost.Set(zamers);
            PipeName PipeName = new PipeName();
            string pipeName = PipeName.GetPipeName(dictionary);
            SaveToFiles fileSaver = new SaveToFiles(dictionary.SourceFileName, pipeName);
            //Незахист
            GetNezahyst getNezahyst = new GetNezahyst();
            nezahysts = getNezahyst.CalculateNezah(zamers);
            fileSaver.SaveNezahyst(nezahysts);
            //Корнебезепечні
            GetKorNeb getKorNeb = new GetKorNeb(zamers, nezahysts);
            korNebezpechny = getKorNeb.Calculate();
            fileSaver.SaveKornebezpechny(korNebezpechny);
            //ПВ
            GetAllPV getAllPV = new GetAllPV();
            fileSaver.SavePV(getAllPV.Get(zamers));

            //Zvedena
            ConvertZamersToZvedena convertZamersToZvedena = new ConvertZamersToZvedena(zamers, korNebezpechny);
            string[,] zvedenaString = convertZamersToZvedena.Convert();
            fileSaver.SaveZvedena(zvedenaString);

            //UKZ
            GetAllUkz getAllUkz = new GetAllUkz();
            fileSaver.SaveUKZ(getAllUkz.Get(zamers));

            //Povregdenya
            GetAllPovregdenya getAllPovregdenya = new GetAllPovregdenya(dictionary.GradFirstLine, dictionary.GradSecondLine);
            povregdenyas = getAllPovregdenya.Get(zamers, korNebezpechny);
            fileSaver.SavePovregd(povregdenyas);

            //UPZ
            GetAllUpz getAllUpz = new GetAllUpz();
            List<UPZ> uPZs = getAllUpz.Get(zamers);
            fileSaver.SaveUPZ(uPZs);

            //Переходы с кожухом
            GetAllRoadKozhuhs getAllRoadKozhuhs = new GetAllRoadKozhuhs();
            roadKozhuhs = getAllRoadKozhuhs.Get(zamers);
            fileSaver.SaveVymirKozhuh(roadKozhuhs);

            //стан на переходах
            fileSaver.SaveStanNaPerehode(roadKozhuhs);

            Logs.AddLog("Таблицы построены");

        }
    }
}
