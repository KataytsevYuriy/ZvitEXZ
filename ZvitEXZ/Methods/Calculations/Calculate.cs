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


            Logs.AddLog("Таблицы построены");
        }
    }
}
