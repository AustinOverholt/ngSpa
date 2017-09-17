using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ngSpa.Services;
using ngSpa.Model;
using System.Collections.Generic;

namespace ngSpa.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void UserService_SelectAll_Test()
        {
            UserService svc = new UserService();
            List<Users> model = svc.SelectAll();
            Assert.IsNotNull(model);

        }
    }
}
