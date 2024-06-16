using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Methods.Calculations;
using Aspose.Cells;

namespace ZvitEXZ.Models.Calculations
{
    public class Statistics
    {
        public string PipeType { get; set; }
        public string PipeShortType { get; set; }
        public string PipeTypeRodPadezh { get; set; }
        public string PipeName { get; set; }
        //public string PipeShortName { get; set; }
        public string DylyankaKm { get; set; }
        public string DylyankaName { get; set; }
        public string DN { get; set; }
        public string IsolationType { get; set; }
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
        public double KmFakt { get; set; }
        public double KmObstegeno { get; set; }
        public double KmObstegenoPerсent { get; set; }
        public double KmNeobstegeno { get; set; }
        public double KmNeobstegenoPerсent { get; set; }
        public List<NeObstegeno> NeObstegenos { get; set; }
        public double Water { get; set; }
        public double WaterPersent { get; set; }
        public double HruntHight { get; set; }
        public double HruntHightPerсent { get; set; }
        public double HruntMedium { get; set; }
        public double HruntMediumtPerсent { get; set; }
        public double HruntLow { get; set; }
        public double HruntLowPersent { get; set; }
        public double Protected { get; set; }
        public double ProtectedPerсent { get; set; }
        public double NoProtected { get; set; }
        public double NoProtectedPerсent { get; set; }
        public double Korneb { get; set; }
        public double KornebPersent { get; set; }
        public double RhruntMin { get; set; }
        public double RhruntMax { get; set; }
        public double PovregdFirstCherga { get; set; }
        public double PovregdFirstChergaPercent { get; set; }
        public double PovregdSecondCherga { get; set; }
        public double PovregdSecondChergaPercent { get; set; }
        public double Umin { get; set; }
        public double Umax { get; set; }
        public double HlubMin { get; set; }
        public double HlybMax { get; set; }
        public double ForestsAll { get; set; }
        public double ForestsAllPrecent { get; set; }
        public double ForestsToClear { get; set; }
        public double ForestsToClearPrecent { get; set; }
        public List<Truboprovod> StoronnieComunications { get; set; }
        public List<Forest> Forests { get; set; }
        public List<Kanal> Kanals { get; set; }
        public List<River> Rivers { get; set; }
        public List<Lep> Leps { get; set; }
        public int PvCount { get; set; }
        public List<NenormHlubyna> NenormHlubynas { get; set; }
        public List<Shurf> Shurves { get; set; }

        public Statistics(List<Zamer> zamers, ExcelDictionary dictionary, List<Nezahyst> nezahysts, List<KorNebezpechny> korNebezpechny,
            List<Povregdenya> povregdenyas, List<RoadKozhuh> roadKozhuhs, List<Flanets> flantsy, List<NeObstegeno> neObstegenos,
            List<PovitrPerehod> povitrPerehods, List<PV> pVs, List<Shurf> shurves, List<HruntAktivity> hruntAktivities, List<Hlubyna> hlubynas,
            List<NenormHlubyna> nenormHlubynas, List<Forest> forests)
        {
            PipeType = dictionary.Type;
            PipeShortType = dictionary.ShortType;
            PipeTypeRodPadezh = dictionary.PipeTypeRodPadezh;
            PipeName = dictionary.Name;
            DylyankaKm = dictionary.DylaynkaKm;
            DylyankaName = dictionary.NameDilyanky;
            DN = dictionary.DN;
            IsolationType = dictionary.TypeIziliatsii;
            GradFirstLine = dictionary.GradFirstLine;
            GradSecondLine = dictionary.GradSecondLine;
            NameOrganization = dictionary.NameOrganization;
            DateStart = dictionary.DateStart;
            ProjectsOrganization = dictionary.ProjectsOrganization;
            BuildingsOrganization = dictionary.BuildingsOrganization;
            StartDN = dictionary.StartDN;
            Thikness = dictionary.Thikness;
            StealMark = dictionary.StealMark;
            PipeBuilder = dictionary.PipeBuilder;
            LengthByTZ = dictionary.LengthByTZ;
            ProjectPressure = dictionary.ProjectPressure;
            WorkPressure = dictionary.WorkPressure;
            Temperuture = dictionary.Temperuture;
            Rechovyna = dictionary.Rechovyna;
            IsolationKlass = dictionary.IsolationKlass;
            IsolationConstruction = dictionary.IsolationConstruction;
            DnToDn = dictionary.DnToDn;
            Remonty = dictionary.Remonty;
            PoperObstegennya = dictionary.PoperObstegennya;
            Shyfr = dictionary.Shyfr;
            SourceFileName = dictionary.SourceFileName;
            KmNeobstegeno = neObstegenos.Sum(el => el.KmEnd - el.KmStart);
            KmFakt = zamers.Last().Km - zamers.First().Km;
            KmObstegeno = KmFakt - KmNeobstegeno;
            KmObstegenoPerсent = Math.Round(100 * KmObstegeno / KmFakt, 2);
            KmNeobstegenoPerсent = Math.Round(100 * KmNeobstegeno / KmFakt, 2);
            NeObstegenos = neObstegenos;
            Water = (double)zamers.Where(z => z.Name == ProjectConstants.RiverName || z.Name == ProjectConstants.SwampName).Select(item => item as Pereshkoda).Sum(el => el.Length) / 1000;
            WaterPersent = Math.Round(100 * Water / KmFakt, 2);
            HruntHight = hruntAktivities.Where(hr => hr.HruntAktivityType == HruntAktivityTypes.hight).Sum(el => el.KmFinish - el.KmStart);
            HruntHightPerсent = GetPersent(HruntHight);
            //Math.Round(100 * HruntHight / KmObstegeno, 2);
            HruntMedium = hruntAktivities.Where(hr => hr.HruntAktivityType == HruntAktivityTypes.medium).Sum(el => el.KmFinish - el.KmStart);
            HruntMediumtPerсent = GetPersent(HruntMedium);
            //Math.Round(100 * HruntMedium / KmObstegeno, 2);
            HruntLow = hruntAktivities.Where(hr => hr.HruntAktivityType == HruntAktivityTypes.low).Sum(el => el.KmFinish - el.KmStart);
            HruntLowPersent = GetPersent(HruntLow);
            //Math.Round(100 * HruntLow / KmObstegeno, 2);
            RhruntMin = zamers.Where(el => el.Rhr != null).Select(item => item.Rhr).Min() ?? 0;
            RhruntMax = zamers.Where(el => el.Rhr != null).Select(item => item.Rhr).Max() ?? 0;
            NoProtected = nezahysts.Sum(el => el.KmEnd - el.KmStart);
            NoProtectedPerсent = Math.Round(100 * NoProtected / KmObstegeno, 2);
            Protected = KmObstegeno - NoProtected;
            ProtectedPerсent = 100 - NoProtectedPerсent;
            Korneb = korNebezpechny.Sum(el => el.KmEnd - el.KmStart);
            KornebPersent = Math.Round(100 * Korneb / KmFakt, 2);
            PovregdFirstCherga = povregdenyas.Where(el => el.Cherga == 1).Sum(el => el.KmEnd - el.KmStart);
            PovregdFirstChergaPercent = GetPersent(PovregdFirstCherga);
            PovregdSecondCherga = povregdenyas.Where(el => el.Cherga == 2).Sum(el => el.KmEnd - el.KmStart);
            PovregdSecondChergaPercent = GetPersent(PovregdSecondCherga);
            List<double> Utzs = zamers.Where(el => el.Utz != null).Select(el => el.Utz ?? 0).ToList();
            Umin = Utzs.Max();
            Umax = Utzs.Min();
            List<double> hlubs = zamers.Where(el => el.Hlub != null).Select(item => item.Hlub ?? 0).ToList();
            HlubMin = hlubs.Min();
            HlybMax = hlubs.Max();
            ForestsAll = forests.Sum(el => el.KmEnd - el.KmStart);
            ForestsAllPrecent = Math.Round(100 * ForestsAll / KmFakt, 2);
            ForestsToClear = forests.Where(item => item.ToClean == true).Sum(el => el.KmEnd - el.KmStart);
            ForestsToClearPrecent = Math.Round(100 * ForestsToClear / KmFakt, 2);
            Forests = forests;
            StoronnieComunications = zamers.Where(el => el.Name == ProjectConstants.TruboprovodName).Select(tr => tr as Truboprovod)
                .Where(t => t.IsVrezkaToAnoterTruboprovid == false).ToList();
            Kanals = zamers.Where(el => el.Name == ProjectConstants.KanalName).Select(tr => tr as Kanal).ToList();
            Rivers = zamers.Where(el => el.Name == ProjectConstants.RiverName).Select(tr => tr as River).ToList();
            Leps = zamers.Where(el => el.Name == ProjectConstants.LepName).Select(tr => tr as Lep).ToList();
            PvCount=zamers.Where(el=>el.Name==ProjectConstants.PVName).Count();
            NenormHlubynas = nenormHlubynas;
            Shurves=shurves;
        }
        public Statistics()
        {

        }
        private double GetPersent(double data)
        {
            return Math.Round(100 * data / KmObstegeno, 2);
        }
    }
}
