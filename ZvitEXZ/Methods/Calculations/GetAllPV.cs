﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    public class GetAllPV
    {
        public List<Zamer> Get(List<Zamer> data)
        {
            return data.Where(item => item.Name == Constants.PVName).ToList();
        }
    }
}