using System.Collections.Generic;
using ZvitEXZ.Methods.File;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Methods.File.Converters;
using System.Linq;
using System.Collections;
using ZvitEXZ.Models.AcadModels;
using System.IO;

namespace ZvitEXZ.Methods.Calculations
{
    public class Calculate
    {
        List<Nezahyst> nezahysts;
        List<KorNebezpechny> korNebezpechny;
        List<Povregdenya> povregdenyas;
        List<PovregdenyaGNT> povregdenyasGNT;
        double mediumBall;
        List<RoadKozhuh> roadKozhuhs;
        List<Flanets> flantsy;
        List<NeObstegeno> neObstegenos;
        List<PovitrPerehod> povitrPerehods;
        List<Zamer> zamers;
        List<PV> pVs;
        List<Shurf> shurves;
        List<HruntAktivity> hruntAktivities;
        List<Hlubyna> hlubynas;
        List<NenormHlubyna> nenormHlubynas;
        CalculationDone calculated;
        ExcelDictionary excelDictionary;
        List<Forest> forests;
        Statistics statistics;
        List<WordReplace> wordReplaces;
        AcadDrawing acadDrawing;
        public Calculate()
        {
            calculated = new CalculationDone();
        }
        public void CalculateAll(List<Zamer> Zamers, ExcelDictionary dictionary, Checked checkeD, double kmPerDrawing)
        {
            SetMestnost setMestnost = new SetMestnost();
            zamers = setMestnost.Set(Zamers);
            excelDictionary = dictionary;
            PipeName PipeName = new PipeName();
            string pipeName = PipeName.GetPipeName(dictionary);
            SaveToFiles fileSaver = new SaveToFiles(dictionary.SourceFileName, pipeName);
            Progress.SetOperationCount(checkeD.CountTrue);
            Progress.AddStep();
            if (checkeD.IsUpz || checkeD.IsUkz || checkeD.IsPv || checkeD.IsKorneb || checkeD.IsPovregd || checkeD.IsPovregdGNT ||
                checkeD.IsNezahyst || checkeD.IsPerehody || checkeD.IsFlantsy || checkeD.IsZvedena || checkeD.IsShurfy ||
                checkeD.IsPovitrPerehody || checkeD.IsStatistiks || checkeD.IsNenormHlybyna)
                if (!System.IO.File.Exists($"{Directory.GetCurrentDirectory()}\\{ProjectConstants.ShablonFileName}") &&
                    (!System.IO.File.Exists($"{Directory.GetCurrentDirectory()}\\{ProjectConstants.ShablonFileName2}")))
                {
                    Logs.AddAlarm("Файл \"Shablon.xlsb\" не найденн, он должен находиться в папке с программой");
                    return;
                }
            if (checkeD.IsZapyska)
                if (!System.IO.File.Exists($"{Directory.GetCurrentDirectory()}\\{ProjectConstants.ShablonWordFileName}") &&
                   (!System.IO.File.Exists($"{Directory.GetCurrentDirectory()}\\{ProjectConstants.ShablonWordFileName2}")))
                {
                    Logs.AddAlarm("Файл \"Shablon.docm\" не найденн, он должен находиться в папке с программой");
                    return;
                }
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
                if (!calculated.Povregd) CalculatePovregd();
                ConvertZamersToZvedena convertZamersToZvedena = new ConvertZamersToZvedena(zamers, korNebezpechny, povregdenyas);
                fileSaver.SaveZvedena(zamers, korNebezpechny, povregdenyas);
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
            //PovregdenyaGNT
            if (checkeD.IsPovregdGNT)
            {
                if (!calculated.PovregdGNT) CalculatePovregdGNT();

                fileSaver.SavePovregdGNT(povregdenyasGNT, mediumBall);
                Progress.AddStep();
                Done.PovregdGNT();
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

            //Ненормативна глибина
            if (checkeD.IsNenormHlybyna)
            {
                if (!calculated.NenormHlybyna) CalculateAllNenormHlubynas();
                fileSaver.SaveNenormHlubynas(nenormHlubynas);
                Progress.AddStep();
                Done.NenormHlubynas();
            }

            //Статистика
            if (checkeD.IsStatistiks)
            {
                if (!calculated.Statistiks) CalculateAllStatistics();
                fileSaver.SaveStatistics(statistics);
                Progress.AddStep();
                Done.NenormHlubynas();
            }

            //Записка
            if (checkeD.IsZapyska)
            {
                if (!calculated.Zapyska) CalculateZapyska();
                WriteWordFile writeWordFile = new WriteWordFile();
                writeWordFile.Save(dictionary.SourceFileName, wordReplaces);
                Progress.AddStep();
                Done.Zapyska();
            }

            //Drawing protokol
            if (checkeD.IsProtokol && ProjectConstants.IsAllowedCad)
            {
                if (!calculated.Protokol) CalculateProtokol(kmPerDrawing);
                fileSaver.SaveCadProtocol(acadDrawing);
            }



            CalculateAllHlubynas();


            Logs.AddLog("Таблицы построены");
            Progress.Finish();

        }
        private void CalculateNezah()
        {
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            GetAllNezahyst getNezahyst = new GetAllNezahyst();
            nezahysts = getNezahyst.CalculateNezah(zamers, neObstegenos);
            calculated.Nezahyst = true;
        }
        private void CalculateKorneb()
        {
            if (!calculated.Nezahyst) CalculateNezah();
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            if (!calculated.HruntActivity) CalculateHruntActivity();
            GetAllKorNeb getKorNeb = new GetAllKorNeb(zamers, nezahysts, hruntAktivities, neObstegenos);
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
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            GetAllPovregdenya getAllPovregdenya = new GetAllPovregdenya(excelDictionary.GradFirstLine,
                excelDictionary.GradSecondLine, neObstegenos);
            povregdenyas = getAllPovregdenya.Get(zamers, korNebezpechny);
            calculated.Povregd = true;
        }
        private void CalculatePovregdGNT()
        {
            if (!calculated.Povregd) CalculatePovregd();
            GetAllPovregdenyasGNT allPovregdenyasGNT = new GetAllPovregdenyasGNT();
            povregdenyasGNT = allPovregdenyasGNT.Get(povregdenyas, neObstegenos, zamers.First().Km, zamers.Last().Km, out mediumBall);
            calculated.PovregdGNT = true;
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
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            GetHruntActivity getHruntActivity = new GetHruntActivity();
            hruntAktivities = getHruntActivity.Get(zamers, neObstegenos);
            calculated.HruntActivity = true;
        }
        private void CalculateAllHlubynas()
        {
            GetAllHlubynas getAllHlubynas = new GetAllHlubynas(zamers);
            hlubynas = getAllHlubynas.Get();
            calculated.Hlubyna = true;
        }
        private void CalculateAllNenormHlubynas()
        {
            if (!calculated.Hlubyna) CalculateAllHlubynas();
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            GetAllNenormHlubyna getAllNenormHlubynas = new GetAllNenormHlubyna(hlubynas, neObstegenos);
            nenormHlubynas = getAllNenormHlubynas.Get();
            calculated.NenormHlybyna = true;
        }
        private void CalculateForests()
        {
            GetAllForest getAllForest = new GetAllForest();
            forests = getAllForest.Get(zamers);
            calculated.Forests = true;
        }
        private void CalculateAllStatistics()
        {
            if (!calculated.Nezahyst) CalculateNezah();
            if (!calculated.Korneb) CalculateKorneb();
            if (!calculated.Povregd) CalculatePovregd();
            if (!calculated.RoadKozhuh) CalculateRoadKozhuh();
            if (!calculated.Flantsy) CalculateFlantsy();
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            if (!calculated.PovitrPerehody) CalculatePovitrPerehody();
            if (!calculated.PV) CalculatePV();
            if (!calculated.Shurfy) CalculateShurfy();
            if (!calculated.HruntActivity) CalculateHruntActivity();
            if (!calculated.Hlubyna) CalculateAllHlubynas();
            if (!calculated.NenormHlybyna) CalculateAllNenormHlubynas();
            if (!calculated.Forests) CalculateForests();
            statistics = new Statistics(zamers, excelDictionary, nezahysts, korNebezpechny, povregdenyas, roadKozhuhs, flantsy,
                neObstegenos, povitrPerehods, pVs, shurves, hruntAktivities, hlubynas, nenormHlubynas, forests);
            calculated.Statistiks = true;
        }
        private void CalculateZapyska()
        {
            if (!calculated.Statistiks) CalculateAllStatistics();
            GetAllWordReplacer GetWordReplacer = new GetAllWordReplacer();
            wordReplaces = GetWordReplacer.Get(statistics);
        }
        private void CalculateProtokol(double kmPerDrawing)
        {
            if (!calculated.Nezahyst) CalculateNezah();
            if (!calculated.Korneb) CalculateKorneb();
            if (!calculated.Povregd) CalculatePovregd();
            if (!calculated.HruntActivity) CalculateHruntActivity();
            if (!calculated.Hlubyna) CalculateAllHlubynas();
            if (!calculated.NenormHlybyna) CalculateAllNenormHlubynas();
            if (!calculated.Neobstegeno) CalculateNeobstegeno();
            GetAcadDrawing getAcadDrawing = new GetAcadDrawing(excelDictionary, zamers, povitrPerehods, hruntAktivities, povregdenyas, nezahysts,
                korNebezpechny, hlubynas, neObstegenos);
            if (AcadConstants.KmStart == null)
                AcadConstants.KmStart = zamers.FirstOrDefault().Km;
            acadDrawing = getAcadDrawing.Calculate((double)AcadConstants.KmStart, kmPerDrawing);
        }
    }
}
