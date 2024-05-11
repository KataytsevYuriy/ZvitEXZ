using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models
{
    public class LogMessage
    {
        public int Priority { get;}
        public string Message { get;}
        public LogMessage(int priority, string message)
        {
            Priority = priority;
            Message = message;
        }
    }
}
