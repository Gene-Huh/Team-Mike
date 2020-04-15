using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductApproval.DAL;
using ProductApproval.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProductApprovalTests.Tests
{
    [TestClass]
    public class UserTests : ParentTest
    {
        [TestMethod]
        public void GetAllUsersTest()
        {
            UsersSqlDAO dao = new UsersSqlDAO(connectionString);
            IList<User> allUsers = dao.GetAllUsers();
            int testResult = allUsers.Count;
            int expectedResult = GetRowCount("users");
            Assert.AreEqual(expectedResult, testResult);
        }

    }
}
