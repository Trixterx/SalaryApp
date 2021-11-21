using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp
{
    public class Logic
    {
        private List<Account> accounts = new List<Account>
        {
            new User { Name = "Rauf", Password = "Hemligt", Role = "Chef", Salary = 35000},
            new User { Name = "Dennis", Password = "Pass", Role = "Slav", Salary = 15000 },
            new User { Name = "Rickard", Password = "Hej", Role = "Utbildare", Salary = 45000 },
            new User { Name = "Marcus", Password = "Codic", Role = "Utbildare", Salary = 5000 },
            new User { Name = "Robin", Password = "Robin", Role = "Robin", Salary = 55000 },
            new Admin { Name = "admin1", Password = "admin1234", Role = "Admin", Salary = 100000 }
        };

        private int input;

        public void Run()
        {
            LoginMenu();
        }

        private void LoginMenu()
        {
            bool run = true;

            while (run)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                var userAccount = Login(username, password);

                if (userAccount == null)
                {
                    Console.WriteLine("Incorrect Username or Password.");
                }
                else if (userAccount.IsAdmin)
                {
                    AdminMenu(userAccount);
                }
                else if (!userAccount.IsAdmin)
                {
                    UserMenu(userAccount);
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
        }

        private void UserMenu(Account userAccount)
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("1. See your salary");
                Console.WriteLine("2. See your role");
                Console.WriteLine("3. Remove your user");
                Console.WriteLine("0. Logout");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine($"Salary: {userAccount.Salary}");
                            break;
                        case 2:
                            Console.WriteLine($"Role: {userAccount.Role}");
                            break;
                        case 3:
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();

                            if (username == userAccount.Name && password == userAccount.Password)
                            {
                                accounts.Remove(userAccount);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect username and/or password.");
                            }
                            break;
                        case 0:
                            run = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again.");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Wrong input, try again.");
                }
            }
        }

        private void AdminMenu(Account userAccount)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("1. See salary");
                Console.WriteLine("2. See role");
                Console.WriteLine("3. See all users");
                Console.WriteLine("4. Create user");
                Console.WriteLine("5. Remove user");
                Console.WriteLine("0. Logout");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 0:
                            run = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, try again.");
                }
            }
        }

        public Account Login(string name, string password)
        {
            foreach (var account in accounts)
            {
                if (account != null && account.Name == name && account.Password == password) { return account; }
            }
            return null;
        }
    }
}
