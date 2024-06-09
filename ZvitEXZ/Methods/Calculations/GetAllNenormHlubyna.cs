using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllNenormHlubyna
    {
        private List<Zamer> zamers;
        private List<NeObstegeno> neObstegeno;
        List<NenormHlubyna> nenormHlubyna;
        public GetAllNenormHlubyna(List<Zamer> zamers, List<NeObstegeno> neObstegeno)
        {
            this.neObstegeno = neObstegeno;
            this.zamers = zamers;
            nenormHlubyna = new List<NenormHlubyna>();
        }
        //public List<NenormHlubyna> Get()
        //{

        //}
    }
}
