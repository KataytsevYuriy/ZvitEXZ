using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class Checked
    {
        public bool IsUkz { get; }
        public bool IsUpz { get; }
        public bool IsPv { get; }
        public bool IsKorneb { get; }
        public bool IsPovregd { get; }
        public bool IsPovregdGNT { get; }
        public bool IsNezahyst { get; }
        public bool IsPerehody { get; }
        public bool IsFlantsy { get; }
        public bool IsZvedena { get; }
        public bool IsShurfy { get; }
        public bool IsPovitrPerehody { get; }
        public bool IsStatistiks { get; set; }
        public bool IsNenormHlybyna { get; set; }
        public bool IsZapyska { get; set; }
        public bool IsProtokol { get; set; }
        public int CountTrue { get; }
        public Checked(bool ukz, bool upz, bool pv, bool korneb, bool povregd, bool povregdGnt, bool nezah,
            bool perehody, bool flantsy, bool zvedena, bool shurfy, bool povitrPerehody, bool nenormHlybyna,
            bool statistiks, bool isZapyska, bool isProtokol)
        {
            CountTrue = 0;
            IsUkz = ukz; IsUpz = upz; IsPv = pv;
            IsKorneb = korneb; IsPovregd = povregd; IsPovregdGNT = povregdGnt;
            IsNezahyst = nezah; IsPerehody = perehody;
            IsFlantsy = flantsy; IsZvedena = zvedena; IsShurfy = shurfy;
            IsPovitrPerehody = povitrPerehody; IsNenormHlybyna = nenormHlybyna;
            IsStatistiks = statistiks;
            IsZapyska = isZapyska;
            IsProtokol=isProtokol;
            if (IsUkz) CountTrue++;
            if (IsUpz) CountTrue++;
            if (IsPv) CountTrue++;
            if (IsKorneb) CountTrue++;
            if (IsPovregd) CountTrue++;
            if (IsPovregdGNT) CountTrue++;
            if (IsNezahyst) CountTrue++;
            if (IsPerehody) CountTrue++;
            if (IsFlantsy) CountTrue++;
            if (IsZvedena) CountTrue++;
            if (IsShurfy) CountTrue++;
            if (IsPovitrPerehody) CountTrue++;
            if (IsNenormHlybyna) CountTrue++;
            if (IsStatistiks) CountTrue++;
            if (IsZapyska) CountTrue++;
            if( IsProtokol) CountTrue++;
        }
        public Checked(Form1 form1) : this(form1.cbUkz.Checked, form1.cbUpz.Checked, form1.cbPv.Checked,
            form1.cbKorneb.Checked, form1.cbPovregd.Checked, form1.cbPovregdGNT.Checked, form1.cbNezah.Checked,
            form1.cbPereh.Checked, form1.cbFlantsy.Checked, form1.cbZvedena.Checked, form1.cbShurfy.Checked,
            form1.cbPovitrPerehody.Checked, form1.cbNenormHlyb.Checked, form1.cbStatistiks.Checked, form1.cbZapycka.Checked,
            form1.cbProtokol.Checked)
        {
        }
    }
}
