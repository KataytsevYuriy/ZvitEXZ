using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    public class Tree:Zamer
    {
        public Tree(object[] data) : base(data)
        {
            Name = ProjectConstants.TreeName;
        }
        public override string ToString()
        {
            return ProjectConstants.TreeName;
        }
    }
}
