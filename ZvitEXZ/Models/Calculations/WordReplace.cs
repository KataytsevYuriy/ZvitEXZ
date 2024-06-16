using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class WordReplace
    {
        public string Source { get; set; }
        public string Replacer { get; set; }
        public WordReplace()
        {
            
        }
        public WordReplace(string source, string replacer)
        {
            Source = source;
            Replacer = replacer;
        }
    }
}
