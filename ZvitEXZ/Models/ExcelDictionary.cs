using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models
{
    public class ExcelDictionary
    {
        public string Type { get; set; }
        public string ShortType { get; set; }
        public string PipeTypeRodPadezh { get; set; }
        public string Name { get; set; }
        public string NameDilyanky { get; set; }
        public string DylaynkaKm { get; set; }
        public string DN { get; set; }
        public string TypeIziliatsii { get; set; }
        public float GradFirstLine { get; set; }
        public float GradSecondLine { get; set; }
        public string NameOrganization { get; set; }
        public string DateStart { get; set; }
        public string ProjectsOrganization { get; set; }
        public string BuildingsOrganization { get; set; }
        public string StartDN { get; set; }
        public string Thikness { get; set; }
        public string StealMark { get; set; }
        public string PipeBuilder { get; set; }//производитель труб
        public string LengthByTZ { get; set; }
        public string ProjectPressure { get; set; }
        public string WorkPressure { get; set; }
        public string Temperuture { get; set; }
        public string Rechovyna { get; set; }
        public string IsolationKlass { get; set; }
        public string IsolationConstruction { get; set; }
        public string DnToDn { get; set; } //переход диаметров
        public string Remonty { get; set; }
        public string PoperObstegennya { get; set; }
        public string Shyfr { get; set; }//шифр газопровода
        public string SourceFileName { get; set; }//имя исхолного файла
        public ExcelDictionary(object[] data)
        {
            if (data[1] == null) throw new ArgumentNullException("пустое значение тип трубопровода");
            Type = data[1].ToString();
            if (data[0] == null) throw new ArgumentNullException("пустое значение краткого типа трубопровода");
            string[] t = data[0].ToString().Split('/');
            ShortType = t[0];
            if (t.Length > 1) { PipeTypeRodPadezh = t[1]; }
            else
            {
                PipeTypeRodPadezh = ShortType;
                Logs.AddError($"Укажите название трубопровода именительном и родительном падежах. Закладка \"Справочник\" ячейка \"E1\" через символ \"/\" (нужно только для записки)");
            }
            if (data[2] == null)
            {
                Name = "";
                Logs.AddAlarm("пустое значение названия трубопровода");
            }
            else
            {
                Name = data[2].ToString();
            }
            if (data[3] == null)
            {
                NameDilyanky = "";
            }
            else
            {
                NameDilyanky = data[3].ToString();
            }
            if (string.IsNullOrEmpty(NameDilyanky)) Logs.AddError("Укажмте название УКПГ(ЦВНГК)... в графе \"Назва ділянки\" (C3).");
            if (data[4] == null) { DylaynkaKm = ""; }
            else
            {
                DylaynkaKm = data[4].ToString();
            }
            if (data[5] == null) { DN = ""; }
            else
            {
                DN = data[5].ToString();
            }
            if (data[6].ToString() == "стрічкове")
            {
                TypeIziliatsii = "стрічкове";
                GradFirstLine = float.Parse(data[10].ToString().Replace(",", "."));
                GradSecondLine = float.Parse(data[8].ToString().Replace(",", "."));
            }
            else
            {
                TypeIziliatsii = "бітумне";
                GradFirstLine = float.Parse(data[9].ToString().Replace(",", "."));
                GradSecondLine = float.Parse(data[7].ToString().Replace(",", "."));
            }
            if (data[11] == null) { NameOrganization = ""; }
            else
            {
                NameOrganization = data[11].ToString();
            }
            if (data[12] == null) { DateStart = ""; }
            else
            {
                DateStart = data[12].ToString();
            }
            if (data[13] == null) { ProjectsOrganization = ""; }
            else
            {
                ProjectsOrganization = data[13].ToString();
            }
            if (data[14] == null) { BuildingsOrganization = ""; }
            else
            {
                BuildingsOrganization = data[14].ToString();
            }
            if (data[15] == null) { StartDN = ""; }
            else
            {
                StartDN = data[15].ToString();
            }
            if (data[16] == null) { Thikness = ""; }
            else
            {
                Thikness = data[16].ToString();
            }
            if (data[17] == null) { StealMark = ""; }
            else
            {
                StealMark = data[17].ToString();
            }
            if (data[18] == null) { PipeBuilder = ""; }
            else
            {
                PipeBuilder = data[18].ToString();
            }
            if (data[19] == null) { LengthByTZ = ""; }
            else
            {
                LengthByTZ = data[19].ToString();
            }
            if (data[20] == null) { ProjectPressure = ""; }
            else
            {
                ProjectPressure = data[20].ToString();
            }
            if (data[21] == null) { WorkPressure = ""; }
            else
            {
                WorkPressure = data[21].ToString();
            }
            if (data[22] == null) { Temperuture = ""; }
            else
            {
                Temperuture = data[22].ToString();
            }
            if (data[23] == null) { Rechovyna = ""; }
            else
            {
                Rechovyna = data[23].ToString();
            }
            if (data[24] == null) { IsolationKlass = ""; }
            else
            {
                IsolationKlass = data[24].ToString();
            }
            if (data[26] == null) { IsolationConstruction = ""; }
            else
            {
                IsolationConstruction = data[26].ToString();
            }
            if (data[27] == null) { DnToDn = ""; }
            else
            {
                DnToDn = data[27].ToString();
            }
            if (data[28] == null) { Remonty = ""; }
            else
            {
                Remonty = data[28].ToString();
            }
            if (data[29] == null) { PoperObstegennya = ""; }
            else
            {
                PoperObstegennya = data[29].ToString();
            }
            if (data[31] == null) { Shyfr = ""; }
            else
            {
                Shyfr = data[31].ToString();
            }
            if (data[36] == null) { SourceFileName = ""; }
            else
            {
                SourceFileName = data[36].ToString();
            }

        }
    }
}
