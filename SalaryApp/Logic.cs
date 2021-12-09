using System;
using System.Collections.Generic;

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
            new Admin { Name = "admin1", Password = "admin1234", Role = "Admin", Salary = 100000 },
            new Admin { Name = "admin2", Password = "admin1234", Role = "Admin", Salary = 100000 }
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
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Login Menu");
                Console.WriteLine("-----------------------------------------------");
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (!StringIsNullEmptyOrWhiteSpace(username) && !StringIsNullEmptyOrWhiteSpace(password))
                {
                    var userAccount = Login(username, password);

                    if (userAccount != null)
                    {
                        if (userAccount.IsAdmin)
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
                    else
                    {
                        Console.WriteLine("Incorrect Username and/or Password.");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, try again.");
                }
            }
        }

        private void UserMenu(Account userAccount)
        {
            bool run = true;

            Console.Clear();

            while (run)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"User Menu | User: {userAccount.Name}");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("1. See your salary");
                Console.WriteLine("2. See your role");
                Console.WriteLine("3. Remove your account");
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
                            Console.WriteLine("Remove your account");
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();

                            run = RemoveYourAccount(userAccount, run, username, password);
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

        public bool RemoveYourAccount(Account userAccount, bool run, string username, string password)
        {
            if (!StringIsNullEmptyOrWhiteSpace(username) && !StringIsNullEmptyOrWhiteSpace(password))
            {
                if (username == userAccount.Name && password == userAccount.Password)
                {
                    accounts.Remove(userAccount);
                    Console.WriteLine("Your user have been successfully removed.");
                    Console.WriteLine("You have been logged out.");
                    run = false;
                }
                else
                {
                    Console.WriteLine("Incorrect Username and/or Password.");
                }
            }
            else
            {
                Console.WriteLine("Wrong input.");
            }

            return run;
        }

        private void AdminMenu(Account userAccount)
        {
            bool run = true;
            string username;
            string password;

            Console.Clear();

            while (run)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Admin Menu | Admin: {userAccount.Name}");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("1. See your salary");
                Console.WriteLine("2. See your role");
                Console.WriteLine("3. See all accounts");
                Console.WriteLine("4. Create account");
                Console.WriteLine("5. Remove account");
                Console.WriteLine("0. Logout");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine($"User: {userAccount.Name}");
                            Console.WriteLine($"Salary: {userAccount.Salary}");
                            break;

                        case 2:
                            Console.WriteLine($"User: {userAccount.Name}");
                            Console.WriteLine($"Role: {userAccount.Role}");
                            break;

                        case 3:
                            Console.WriteLine(PrintUsers());
                            break;

                        case 4:
                            Console.WriteLine("Create a new account");
                            Console.Write("Username: ");
                            username = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();

                            CreateNewAccount(username, password);
                            break;

                        case 5:
                            Console.WriteLine("Remove a account");
                            Console.Write("Username: ");
                            username = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();

                            RemoveAccount(username, password);
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

        public string PrintUsers()
        {
            foreach (var account in accounts)
            {
                return $"Name: {account.Name} | Password: {account.Password}";
            }
            return string.Empty;
        }

        public void RemoveAccount(string username, string password)
        {
            if (!StringIsNullEmptyOrWhiteSpace(username) && !StringIsNullEmptyOrWhiteSpace(password))
            {
                foreach (var account in accounts)
                {
                    if (account.Name == username && account.Password == password)
                    {
                        accounts.Remove(account);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong input.");
            }
        }

        public void CreateNewAccount(string username, string password)
        {
            if (!StringIsNullEmptyOrWhiteSpace(username) && !StringIsNullEmptyOrWhiteSpace(password))
            {
                Console.WriteLine("Is the new user Admin, y/n?");
                string adminOrNot = Console.ReadLine().ToLower();
                if (!StringIsNullEmptyOrWhiteSpace(adminOrNot))
                {
                    switch (adminOrNot)
                    {
                        case "y":
                            if (CreateAdmin(username, password))
                            {
                                Console.WriteLine("Admin was created.");
                            }
                            else
                            {
                                Console.WriteLine("Already exist.");
                            }
                            break;

                        case "n":
                            if (CreateUser(username, password))
                            {
                                Console.WriteLine("User was created.");
                            }
                            else
                            {
                                Console.WriteLine("Already exist.");
                            }
                            break;

                        default:
                            Console.WriteLine("Something went wrong.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input.");
                }
            }
            else
            {
                Console.WriteLine("Wrong input.");
            }
        }

        public bool CreateUser(string username, string password)
        {
            foreach (var account in accounts)
            {
                if (account.Name == username)
                {
                    return false;
                }
                else
                {
                    accounts.Add(new User { Name = username, Password = password });
                    return true;
                }
            }
            return false;
        }

        public bool CreateSuperUser(string username, string password)
        {
            foreach (var account in accounts)
            {
                if (account.Name == username)
                {
                    return false;
                }
                else
                {
                    accounts.Add(new SuperUser { Name = username, Password = password });
                    return true;
                }
            }
            return false;
        }

        public bool CreateSuperPuperUser(string username, string password)
        {
            foreach (var account in accounts)
            {
                if (account.Name == username)
                {
                    return false;
                }
                else
                {
                    accounts.Add(new SuperPuperUser { Name = username, Password = password });
                    return true;
                }
            }
            return false;
        }

        public bool CreateAdmin(string username, string password)
        {
            foreach (var account in accounts)
            {
                if (account.Name == username)
                {
                    return false;
                }
                else
                {
                    accounts.Add(new Admin { Name = username, Password = password });
                    return true;
                }
            }
            return false;
        }

        public Account Login(string name, string password)
        {
            foreach (var account in accounts)
            {
                if (account != null && account.Name == name && account.Password == password) { return account; }
            }
            return null;
        }

        public bool StringIsNullEmptyOrWhiteSpace(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
