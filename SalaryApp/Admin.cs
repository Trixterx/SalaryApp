﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp
{
    public class Admin : Account
    {
        public Admin()
        {
            IsAdmin = true;
        }
    }
}
