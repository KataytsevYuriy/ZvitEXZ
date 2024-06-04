using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    public class NeObstegenaDylyanka:Pereshkoda
    {
        public string ReasonNeodstegenosty { get; set; }
        public NeObstegenaDylyanka(object[] data) : base(data)
        {
            Name = Constants.NeobstegenaDylyankaName;
            if (data[31] == null)
            {
                ReasonNeodstegenosty = "";
            }
            else
            {
                ReasonNeodstegenosty = data[31].ToString();
            }
        }
        public override string ToString()
        {
            return $"{Name} {ReasonNeodstegenosty}";
        }
    }
}
