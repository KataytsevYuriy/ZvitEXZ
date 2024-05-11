using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods
{
    public class PipeName
    {
        public string GetPipeName(ExcelDictionary dictionary)
        {
            return $"{char.ToUpper(dictionary.Type[0])}{dictionary.Type.Substring(1)} {dictionary.Name}, ДУ{dictionary.DN}";
        }
    }
}
