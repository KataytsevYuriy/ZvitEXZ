using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.AcadModels
{
    public class AcadDoc
    {
        public string PipeName { get; set; }
        public string FileName { get; set; }
        public string FolderName { get; set; }
        public string Shifr { get; set; }
        public string Km { get; set; }
        public string NextSheet { get; set; }
        public int DocNumber { get; set; }
        public double KmStart { get; set; }
        public double KmEnd { get; set; }
        public List<DrawingStep> DrawingSteps { get; set; }
        public int CellsCount
        {
            get { return DrawingSteps.Max(el => el.CellsCount()); }
        }
        public AcadDoc(string pipeName, string filename, string folderName, string shifr, double kmStart, double kmEnd, int docNumber)
        {
            PipeName = pipeName;
            FileName = filename;
            FolderName = folderName;
            Shifr = shifr;
            KmStart = kmStart;
            KmEnd = kmEnd;
            DocNumber = docNumber;
            Km = $"км {ConvertToString.DoubleToString(kmStart)} - км {ConvertToString.DoubleToString(kmEnd)}";
            NextSheet = string.Empty;
            DrawingSteps = new List<DrawingStep>();
        }
    }
}
