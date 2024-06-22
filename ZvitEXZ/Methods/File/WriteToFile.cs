using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.File
{
    public class WriteToFile
    {
        public void WriteFile(string sourceFileName, string folderName, string PipeName, object[,] data,
            string callStartName, string callFinishName, string callPrintFinishName, string ifDataEmpty,
            int sheetNumber, string alternativeFileName = "", double bal = -1, string rangeBal = "F")
        {
            int stringsCount = data.GetLength(0);
            WriteEcxelFile writeEcxelFile = new WriteEcxelFile();
            string printRange = stringsCount > 0 ? $"{callStartName}1:{callPrintFinishName}{7 + stringsCount}" :
                $"{callStartName}1:{callPrintFinishName}8";
            string RangeBal = $"{rangeBal}8:{rangeBal}{7 + stringsCount}";
            alternativeFileName = String.IsNullOrEmpty(alternativeFileName) ? folderName : alternativeFileName;
            writeEcxelFile.WriteFile(folderName, $"{alternativeFileName}_{sourceFileName}",
                PipeName, data, $"{callStartName}7:{callFinishName}7",
                $"{callStartName}8:{callFinishName}{7 + stringsCount}", $"{callStartName}8:{callFinishName}8",
                printRange, ifDataEmpty, sheetNumber, bal, RangeBal);
        }
    }
}
