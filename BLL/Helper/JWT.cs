﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issure { get; set; }
        public string Audience { get; set; }
        public double Duration { get; set; }
    }
}
