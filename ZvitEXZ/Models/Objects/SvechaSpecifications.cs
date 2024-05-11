using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Objects
{
    public class SvechaSpecifications
    {
        public enum SpecificationType
        {
            undefined, vytazhna, produvochna
        }
        public enum TehnicState
        {
            undefined, obrezana, needToPaint
        }
    }
}
