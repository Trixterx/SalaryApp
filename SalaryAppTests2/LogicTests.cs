using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void CreateNewSuperUserTest()
        {
            var user = new SuperUser() { Name = "Jan", Password = "Hem" };

            var logic = new Logic();

            Assert.IsTrue(logic.CreateSuperUser(user.Name, user.Password));
        }

        [TestMethod()]
        public void CreateNewSuperPuperUserTest()
        {
            var user = new SuperPuperUser() { Name = "Jan", Password = "Hem" };

            var logic = new Logic();

            Assert.IsTrue(logic.CreateSuperPuperUser(user.Name, user.Password));
        }



        [TestMethod()]
        public void CheckStringTest()
        {
            string str = null;
            string str2 = "Hej";

            var logic = new Logic();

            Assert.IsTrue(logic.StringIsNullEmptyOrWhiteSpace(str));
            Assert.IsFalse(logic.StringIsNullEmptyOrWhiteSpace(str2));
        }
    }
}