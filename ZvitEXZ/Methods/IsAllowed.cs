using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods
{
    internal class IsAllowed
    {
        public void Check()
        {
            DateTime errorDate = new DateTime(2025, 1, 5);//год, месяц, день
            if(DateTime.Now>errorDate) throw new DivideByZeroException();
        }
    }
}
