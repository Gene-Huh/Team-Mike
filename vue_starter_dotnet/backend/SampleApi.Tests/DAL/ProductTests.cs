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
    public class ProductTests : ParentTest
    {
        private string addProductSql = "Insert INTO products (data row) VALUES (Actual values)";

        [TestMethod]
        public void GetAllProductsTest()
        {
            int originalCount = GetRowCount("products");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(addProductSql, conn);
                cmd.ExecuteNonQuery();
            }

            ProductSqlDAO dao = new ProductSqlDAO(connectionString);
            IList<Product> product = dao.GetAllProducts();
            Assert.AreEqual(originalCount + 1, product.Count);
        }
    }
}
