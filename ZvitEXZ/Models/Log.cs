using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models
{
    public class Log
    {
        public string Text { get; }
        public int Type { get; } //0-Alert, 1-Error, 2-Info
        public Log(string text, int type)
        {
            Text=text;
            Type=type;
        }
    }
}
