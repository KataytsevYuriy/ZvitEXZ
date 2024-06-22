using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoCAD;
//using au
//using AXDBLib;
//using Autodesk.AutoCAD.Runtime;
//using Autodesk.AutoCAD.ApplicationServices;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.Geometry;

namespace ZvitEXZ.Methods
{
    internal class AcadDriwingTest
    {
        private AcadApplication AcadApp = default(AcadApplication);
        private AcadCircle Circle = default(AcadCircle);

        public void PrintPline()
        {
            AcadApp = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
            List<Point> points = new List<Point>();
            points.Add(new Point(2, 2));
            points.Add(new Point(3, 4));
            double[] vertices = new double[]
          {1,1,0,5,5,0,9,20,0,2,5,0,1,1,0};


           AcadPolyline pline = AcadApp.ActiveDocument.ModelSpace.AddPolyline(vertices);
            pline.color =ACAD_COLOR.acYellow;
            var acDoc = AcadApp.ActiveDocument;
            var acDb=acDoc.Database;
            //using (DbTransaction tr = acDb.)
                //string m_layer = (string)AcadApp.ActiveDocument.GetVariable("clayer");
                //layers = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;
                //var l = AcadApp.ActiveDocument.ActiveLayer as AcadLayer;
                int i = 0;

            //AcadApp.ActiveDocument.SendCommand("^c\r\n");
            //AcadApp.ActiveDocument.SendCommand("^c\r\n");
            AcadApp.ActiveDocument.SendCommand("-вставить;луг;-2,-2,0\r\n");
            //AcadApp.ActiveDocument.SendCommand("луг\r\n");
            //AcadApp.ActiveDocument.SendCommand("-2,-2,0\r\n");
            //AcadApp.ActiveDocument.SendCommand("\r\n");
            //AcadApp.ActiveDocument.SendCommand("\r\n");
            //AcadApp.ActiveDocument.SendCommand("\r\n");
            //AcadApp.ActiveDocument.SendCommand("test1\r\n");            
            //Circle = AcadApp.ActiveDocument.ModelSpace.AddCircle(new double[] { 0, 0, 0 }, 3);
            //string t = Circle.ObjectName;
            //long tr = Circle.ObjectID;
            //string han = Circle.Handle;
        }
        public void CopyBlock()
        {
            //AcadLayerStateManager
           AutoCAD.AcadBlocks acadBlocks = AcadApp.ActiveDocument.Blocks;
           //AutoCAD.AcadBlock block=acadBlocks.ge;
            AcadBlocks acadBlock = AcadApp.ActiveDocument.Blocks;
        }
    
    }
}
