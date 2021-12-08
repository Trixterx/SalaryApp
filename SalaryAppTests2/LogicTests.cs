﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryApp.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            var user = new User() { Name = "Dennis", Password = "Pass" };
            var logic = new Logic();

            var loginUser = logic.Login(user.Name, user.Password);

            Assert.AreEqual("Dennis", loginUser.Name);
            Assert.AreEqual("Pass", loginUser.Password);
        }

        [TestMethod()]
        public void RemoveYourAccountTest()
        {
            var user = new User() { Name = "Rauf", Password = "Hemligt" };
            var logic = new Logic();

            Assert.IsFalse(logic.RemoveYourAccount(user, true, user.Name, user.Password));
        }

        [TestMethod()]
        public void PrintUsersTest()
        {
            var user = new User() { Name = "Rauf", Password = "Hemligt" };

            var logic = new Logic();

            Assert.AreEqual($"Name: {user.Name} | Password: {user.Password}", logic.PrintUsers());
        }

        [TestMethod()]
        public void PrintUsers2Test()
        {
            var user = new User() { Name = "Rauf", Password = "123456789" };

            var logic = new Logic();

            Assert.AreEqual($"Name: {user.Name} | Password: {user.Password}", logic.PrintUsers());
        }

        [TestMethod()]
        public void CreateNewUserTest()
        {
            var user = new User() { Name = "Jan", Password = "Hem" };

            var logic = new Logic();

            Assert.IsTrue(logic.CreateUser(user.Name, user.Password));
        }

        [TestMethod()]
        public void CreateNewAdminTest()
        {
            var user = new Admin() { Name = "Jan", Password = "Hem" };

            var logic = new Logic();

            Assert.IsTrue(logic.CreateAdmin(user.Name, user.Password));
        }

        [TestMethod()]
        public void CreateNewAdmin2Test()
        {
            var user = new Admin() { Name = "Rauf", Password = "123456789" };

            var logic = new Logic();

            Assert.IsTrue(logic.CreateAdmin(user.Name, user.Password));
        }

        [TestMethod()]
        public void CheckStringTest()
        {
            string str = "";
            string str2 = "Hej";

            var logic = new Logic();

            Assert.IsTrue(logic.StringIsNullEmptyOrWhiteSpace(str));
            Assert.IsFalse(logic.StringIsNullEmptyOrWhiteSpace(str2));
        }
    }
}