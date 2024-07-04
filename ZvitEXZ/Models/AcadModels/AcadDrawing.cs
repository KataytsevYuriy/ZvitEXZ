using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    public class AcadDrawing
    {
        public List<AcadDoc> Docs { get; set; }
        public string ProtocolFileName { get; set; }
        public string PipeName { get; set; }
        public string SourceFileName { get; set; }
        public string FolderName { get; set; }
        public string Shifr { get; set; }
        public AcadDrawing(string protocolFileName, string pipeName, string sourceFileName, string folderName, string shifr)
        {
            Docs = new List<AcadDoc>();
            ProtocolFileName = protocolFileName;
            PipeName = pipeName;
            SourceFileName = sourceFileName;
            FolderName=folderName;
            Shifr = shifr;
        }
    }
}
