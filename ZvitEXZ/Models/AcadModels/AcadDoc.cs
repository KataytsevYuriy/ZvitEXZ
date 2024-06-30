using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class AcadDoc
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string FolderName { get; set; }
        public string Shifr { get; set; }
        public string Km { get; set; }
        public string NextSheet { get; set; }
        public List<DrawingStep> DrawingSteps { get; set; }
        public int CellsCount
        {
            get { return DrawingSteps.Max(el => el.CellsCount()); }
        }
        public AcadDoc(string name, string filename, string folderName, string shifr, string km)
        {
            Name = name;
            FileName = filename;
            FolderName = folderName;
            Shifr = shifr;
            Km = km;
            NextSheet = string.Empty;
            DrawingSteps = new List<DrawingStep>();
        }
    }
}
