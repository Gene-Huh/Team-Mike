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
        private string addApprovedProductSql = "INSERT INTO ProductList (ProductNumber, ProductDescription, DefaultUOM, isSellable, CrossReference, ItemType, isDrugControlled, ManufacturerID, InventoryStatus, AlternativeProducts, isNonReturnable, isRefrigerated, isRegulated) VALUES ('123','generic product description','OH',1,'123',1,0,'INTERNATIONAL INC.','Buy','',0,0,0);";
        private string addUnapprovedProductSql = "INSERT INTO ProductList (ProductNumber, ProductDescription, DefaultUOM, isSellable, CrossReference, ItemType, isDrugControlled, ManufacturerID, InventoryStatus, AlternativeProducts, isNonReturnable, isRefrigerated, isRegulated) VALUES ('123','generic product description','OH',0,'123',1,0,'INTERNATIONAL INC.','Buy','',0,0,0);";

        [TestMethod]
        public void GetAllApprovedProductsTest()
        {
            int originalCount = GetRowCount("ProductList");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(addApprovedProductSql, conn);
                cmd.ExecuteNonQuery();
            }

            ProductSqlDAO dao = new ProductSqlDAO(connectionString);
            IList<Product> product = dao.GetAllApprovedProducts();
            Assert.AreEqual(originalCount + 1, product.Count);
        }

        [TestMethod]
        public void GetAllUnapprovedProductsTest()
        {
            //int originalCount = GetRowCount("ProductList");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(addUnapprovedProductSql, conn);
                cmd.ExecuteNonQuery();
            }

            ProductSqlDAO dao = new ProductSqlDAO(connectionString);
            IList<Product> product = dao.GetAllUnapprovedProducts();
            Assert.AreEqual(1, product.Count);
        }
    }
}
