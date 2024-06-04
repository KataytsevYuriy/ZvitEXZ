using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllPovitrPerehody
    {
        public List<PovitrPerehod> Get(List<Zamer> zamers)
        {
            List<Zamer> vyhods = zamers.Where(el => el.Name == ZvitEXZ.Models.ProjectConstants.VyhodIsZemlyName).ToList();
            List<PovitrPerehod> res = new List<PovitrPerehod>();
            if (vyhods.Count < 2) return res;
            VyhodIsZemly vyhStart = null;
            foreach (VyhodIsZemly vyhod in vyhods)
            {
                if (vyhStart == null && vyhod.PerehodType == PerehodTypes.start) { vyhStart = vyhod; }
                else if (vyhStart != null && vyhod.PerehodType == PerehodTypes.finish)
                {
                    res.Add(new PovitrPerehod(vyhStart, vyhod));
                    vyhStart = null;
                }
                else
                {
                    vyhStart = null;
                    if(vyhod.PerehodType == PerehodTypes.start) { vyhStart = vyhod; }
                }
            }
            return res;
        }
    }
}
