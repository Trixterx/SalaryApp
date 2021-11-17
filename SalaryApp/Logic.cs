using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp
{
    public class Logic
    {
        public bool Login(string name, string password, User user)
        {
            if (user != null && user.Name == name && user.Password == password) { return true; }
            return false;
        }
    }
}
