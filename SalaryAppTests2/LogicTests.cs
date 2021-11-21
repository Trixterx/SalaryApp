﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            var user = new User() { Name = "Dennis", Password = "Pass"};
            var logic = new Logic();

            var loginUser = logic.Login(user.Name, user.Password);

            Assert.AreEqual("Dennis", loginUser.Name);
            Assert.AreEqual("Pass", loginUser.Password);
        }
    }
}