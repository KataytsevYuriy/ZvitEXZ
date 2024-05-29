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
        List<Flanets> flantsy;
        public void CalculateAll(List<Zamer> zamers, ExcelDictionary dictionary, Checked checkeD)
        {
            SetMestnost setMestnost = new SetMestnost();
            zamers = setMestnost.Set(zamers);
            PipeName PipeName = new PipeName();
            string pipeName = PipeName.GetPipeName(dictionary);
            SaveToFiles fileSaver = new SaveToFiles(dictionary.SourceFileName, pipeName);
            Progress.SetOperationCount(checkeD.CountTrue);
            Progress.AddStep();

            //Незахист
            if (checkeD.IsNezahyst || checkeD.IsKorneb || checkeD.IsPovregd || checkeD.IsPovregdGNT ||
                checkeD.IsZvedena || checkeD.IsPovregd || checkeD.IsPovregdGNT)
            {
                GetNezahyst getNezahyst = new GetNezahyst();
                nezahysts = getNezahyst.CalculateNezah(zamers);
            }
            if (checkeD.IsNezahyst)
            {
                fileSaver.SaveNezahyst(nezahysts);
                Progress.AddStep();
                Done.Nezahyst();
            }

            //Корнебезепечні
            if (checkeD.IsNezahyst || checkeD.IsKorneb || checkeD.IsPovregd || checkeD.IsPovregdGNT)
            {

                GetKorNeb getKorNeb = new GetKorNeb(zamers, nezahysts);
                korNebezpechny = getKorNeb.Calculate();
            }
            if (checkeD.IsNezahyst)
            {
                fileSaver.SaveKornebezpechny(korNebezpechny);
                Progress.AddStep();
                Done.Korneb();
            }

            //ПВ
            if (checkeD.IsPv)
            {
                GetAllPV getAllPV = new GetAllPV();
                fileSaver.SavePV(getAllPV.Get(zamers));
                Progress.AddStep();
                Done.PV();
            }

            //Zvedena
            if (checkeD.IsZvedena)
            {
                ConvertZamersToZvedena convertZamersToZvedena = new ConvertZamersToZvedena(zamers, korNebezpechny);
                string[,] zvedenaString = convertZamersToZvedena.Convert();
                fileSaver.SaveZvedena(zvedenaString);
                Progress.AddStep();
                Done.Zvedena();
            }

            //UKZ
            if (checkeD.IsUkz)
            {
                GetAllUkz getAllUkz = new GetAllUkz();
                fileSaver.SaveUKZ(getAllUkz.Get(zamers));
                Progress.AddStep();
                Done.Ukz();
            }

            //Povregdenya
            if (checkeD.IsPovregd)
            {
                GetAllPovregdenya getAllPovregdenya = new GetAllPovregdenya(dictionary.GradFirstLine, dictionary.GradSecondLine);
                povregdenyas = getAllPovregdenya.Get(zamers, korNebezpechny);
                fileSaver.SavePovregd(povregdenyas);
                Progress.AddStep();
                Done.Povregd();
            }

            //UPZ
            if (checkeD.IsUpz)
            {
                GetAllUpz getAllUpz = new GetAllUpz();
                List<UPZ> uPZs = getAllUpz.Get(zamers);
                fileSaver.SaveUPZ(uPZs);
                Progress.AddStep();
                Done.Upz();
            }

            //Переходы с кожухом
            if (checkeD.IsPerehody)
            {
                GetAllRoadKozhuhs getAllRoadKozhuhs = new GetAllRoadKozhuhs();
                roadKozhuhs = getAllRoadKozhuhs.Get(zamers);
                fileSaver.SaveVymirKozhuh(roadKozhuhs);
                Progress.AddStep();
                //стан на переходах
                fileSaver.SaveStanNaPerehode(roadKozhuhs);
                Progress.AddStep();
                Done.Perehody();
            }

            // Flantsy
            if (checkeD.IsFlantsy)
            {
                GetAllFlanets getAllFlantsy = new GetAllFlanets();
                flantsy = getAllFlantsy.GetElektroIsolative(zamers);
                fileSaver.SaveFlantsy(flantsy);
                Progress.AddStep();
                Done.Flantsy();
            }

            Logs.AddLog("Таблицы построены");
            Progress.Finish();
        }
    }
}
