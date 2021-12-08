using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp
{
    public  class SuperUser : Account
    {
        public SuperUser()
        {
            IsAdmin = true;
        }
    }
}
