using AutoCAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods.AcadMethods
{
    internal class GetAcadFile
    {
        public AcadApplication AcadApplication { get; }
        public GetAcadFile()
        {
            AcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
        }
    }
}
