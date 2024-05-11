using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods
{
    public class ParseAllZamers
    {
        public List<Zamer> Parse(List<object[]> data,out ExcelDictionary dictionary)
        {
            dictionary=new ExcelDictionary(data.First());  
            data.RemoveAt(0);
            List<Zamer> result = new List<Zamer>();
            ParseZamer Parse = new ParseZamer();
            foreach (object[] item in data)
            {
                try
                {
                    Zamer zamer = Parse.Parse(item);
                    result.Add(zamer);
                }
                catch (Exception ex)
                {
                    Logs.AddError($"{ex.Message} Объект не создан");
                }
            }
            return result;
        }
    }
}
