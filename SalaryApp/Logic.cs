using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp
{
    public class Logic
    {
        public void Run()
        {
            Login();
        }
        private void Login()
        {
            bool run = true;
            while (run)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
            }

        }
        private void UserMenu()
        {

        }
        private void AdminMenu()
        {

        }

        public bool Login(string name, string password, User user)
        {
            if (user != null && user.Name == name && user.Password == password) { return true; }
            return false;
        }

        private void MockData()
        {
            var userList = new List<User>();
            {
                userList.Add(new User { Name = "Rauf", Password = "Hemligt", Role = "Chef", Salary = 35000});
                userList.Add(new User { Name = "Dennis", Password = "Pass", Role = "Slav", Salary = 15000 });
                userList.Add(new User { Name = "Rickard", Password = "Hej", Role = "Utbildare", Salary = 45000 });
                userList.Add(new User { Name = "Marcus", Password = "Codic", Role = "Utbildare", Salary = 5000 });
                userList.Add(new User { Name = "Robin", Password = "Robin", Role = "Robin", Salary = 55000 });
            }
            var adminList = new List<Admin>();
            {
                adminList.Add(new Admin { Name = "admin1", Password = "admin1234", Role = "Admin", Salary = 100000});
            }
        }
    }
}
