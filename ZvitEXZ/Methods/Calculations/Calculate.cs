using System.Collections.Generic;
using ZvitEXZ.Methods.File;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Methods.File.Converters;

namespace ZvitEXZ.Methods.Calculations
{
    public class Calculate
    {
        List<Nezahyst> nezahysts;
        List<KorNebezpechny> korNebezpechny;
        List<Povregdenya> povregdenyas;
        List<RoadKozhuh> roadKozhuhs;
        List<Flanets> flantsy;
        List<NeObstegeno> neObstegenos;
        List<Dylyanka> neObstegenoDylyanka;
        List<PovitrPerehod> povitrPerehods;
        List<Zamer> zamers;
        List<PV> pVs;
        List<Shurf> shurves;
        List<HruntAktivity> hruntAktivities;
        CalculationDone calculated;
        ExcelDictionary excelDictionary;
        public Calculate()
        {
            calculated = new CalculationDone();
        }
        public void CalculateAll(List<Zamer> Zamers, ExcelDictionary dictionary, Checked checkeD)
        {
            SetMestnost setMestnost = new SetMestnost();
            zamers = setMestnost.Set(Zamers);
            excelDictionary = dictionary;
            PipeName PipeName = new PipeName();
            string pipeName = PipeName.GetPipeName(dictionary);
            SaveToFiles fileSaver = new SaveToFiles(dictionary.SourceFileName, pipeName);
            Progress.SetOperationCount(checkeD.CountTrue);
            Progress.AddStep();

            //Незахист
            if (checkeD.IsNezahyst)
            {
                if (!calculated.Nezahyst) CalculateNezah();
                fileSaver.SaveNezahyst(nezahysts);
                Progress.AddStep();
                Done.Nezahyst();
            }

            //Корнебезепечні
            if (checkeD.IsKorneb)
            {
                if (!calculated.Korneb) CalculateKorneb();
                fileSaver.SaveKornebezpechny(korNebezpechny);
                Progress.AddStep();
                Done.Korneb();
            }

            //ПВ
            if (checkeD.IsPv)
            {
                if (!calculated.PV) CalculatePV();
                fileSaver.SavePV(pVs);
                Progress.AddStep();
                Done.PV();
            }

            //Zvedena
            if (checkeD.IsZvedena)
            {
                if (!calculated.Korneb) CalculateKorneb();
                ListZamersToMassive convertZamersToZvedena = new ListZamersToMassive(zamers, korNebezpechny);
                fileSaver.SaveZvedena(convertZamersToZvedena.Convert());
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
                if (!calculated.Povregd) CalculatePovregd();
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
                if (!calculated.RoadKozhuh) CalculateRoadKozhuh();
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
                if (!calculated.Flantsy) CalculateFlantsy();
                fileSaver.SaveFlantsy(flantsy);
                Progress.AddStep();
                Done.Flantsy();
            }

            //Povitr Perehody
            if (checkeD.IsPovitrPerehody)
            {
                if (!calculated.PovitrPerehody) CalculatePovitrPerehody();
                fileSaver.SavePovitrPerehody(povitrPerehods);
                Progress.AddStep();
                Done.povitrPerehody();
            }

            //необстежено
            //CalculateNeobstegeno();

            //Shurves
            if (checkeD.IsShurfy)
            {
                if (!calculated.Shurfy) CalculateShurfy();
                fileSaver.SaveShurves(shurves);
                Progress.AddStep();
                Done.Shurfy();
            }




            Logs.AddLog("Таблицы построены");
            Progress.Finish();

        }
        private void CalculateNezah()
        {
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            GetNezahyst getNezahyst = new GetNezahyst();
            nezahysts = getNezahyst.CalculateNezah(zamers,neObstegenoDylyanka);
            calculated.Nezahyst = true;
        }
        private void CalculateKorneb()
        {
            if (!calculated.Nezahyst) CalculateNezah();
            if (!calculated.HruntActivity) CalculateHruntActivity();
            GetKorNeb getKorNeb = new GetKorNeb(zamers, nezahysts, hruntAktivities);
            korNebezpechny = getKorNeb.Calculate();
            calculated.Korneb = true;
        }
        private void CalculatePV()
        {
            GetAllPV getAllPV = new GetAllPV();
            pVs = getAllPV.Get(zamers);
            calculated.PV = true;
        }
        private void CalculatePovregd()
        {
            if (!calculated.Korneb) CalculateKorneb();
            GetAllPovregdenya getAllPovregdenya = new GetAllPovregdenya(excelDictionary.GradFirstLine,
                excelDictionary.GradSecondLine);
            povregdenyas = getAllPovregdenya.Get(zamers, korNebezpechny);
            calculated.Povregd = true;
        }
        private void CalculateRoadKozhuh()
        {
            GetAllRoadKozhuhs getAllRoadKozhuhs = new GetAllRoadKozhuhs();
            roadKozhuhs = getAllRoadKozhuhs.Get(zamers);
            calculated.RoadKozhuh = true;
        }
        private void CalculateFlantsy()
        {
            GetAllFlanets getAllFlantsy = new GetAllFlanets();
            flantsy = getAllFlantsy.GetElektroIsolative(zamers);
            calculated.Flantsy = true;
        }
        private void CalculatePovitrPerehody()
        {
            GetAllPovitrPerehody getAllPovitrPerehody = new GetAllPovitrPerehody();
            povitrPerehods = getAllPovitrPerehody.Get(zamers);
            calculated.PovitrPerehody = true;
        }
        private void CalculateNeobstegeno()
        {
            if (!calculated.PovitrPerehody) CalculatePovitrPerehody();
            GetAllNeobstegeno getAllNeobstegeno = new GetAllNeobstegeno();
            neObstegenos = getAllNeobstegeno.Get(zamers, povitrPerehods);
            neObstegenoDylyanka = new List<Dylyanka>();
            foreach (NeObstegeno neObstegeno in neObstegenos)
            { neObstegenoDylyanka.Add(new Dylyanka(neObstegeno.KmStart, neObstegeno.KmEnd)); }
            calculated.Neobstegeno = true;
        }
        private void CalculateShurfy()
        {
            GetAllShurfs getAllShurfs = new GetAllShurfs();
            shurves = getAllShurfs.Get(zamers);
            calculated.Shurfy = true;
        }
        private void CalculateHruntActivity()
        {
            GetHruntActivity getHruntActivity = new GetHruntActivity();
            hruntAktivities = getHruntActivity.Get(zamers);
            calculated.HruntActivity = true;
        }

    }
}
