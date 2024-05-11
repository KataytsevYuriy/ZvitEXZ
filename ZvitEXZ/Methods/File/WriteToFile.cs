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
        public void WriteFile(string sourceFileName,string folderName, string PipeName, string[,] data,
            string callStartName, string callFinishName, string callPrintFinishName, string ifDataEmpty, int sheetNumber)
        {
            int stringsCount = data.GetLength(0);
            WriteEcxelFile writeEcxelFile = new WriteEcxelFile();
            string printRange = stringsCount > 0 ? $"{callStartName}1:{callPrintFinishName}{7 + stringsCount}" :
                $"{callStartName}1:{callPrintFinishName}8";
            writeEcxelFile.WriteFile(folderName, $"{folderName}_{sourceFileName}",
                PipeName, data, $"{callStartName}7:{callFinishName}7", 
                $"{callStartName}8:{callFinishName}{7 + stringsCount}", $"{callStartName}8:{callFinishName}8",
                printRange, ifDataEmpty, sheetNumber);
        }
    }
}
