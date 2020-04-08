using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProductApproval.DAL;
using ProductApproval.Models;

namespace ProductApproval.DAL
{
    public class ProductSqlDAO : IProductDAO
    {
        private readonly string connectionString;
        private string getApprovedProductsSql = "SELECT * FROM ProductList WHERE isSellable = 1";
        private string getUnapprovedProductsSql = "SELECT * FROM ProductList WHERE isSellable = 0";
        private string getProductNumberSql = "SELECT * FROM ProductList WHERE ProductNumber = @ProductNumber";

        public ProductSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        List<Product> ProductList { get; set; }

        public IList<Product> GetAllApprovedProducts()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(getApprovedProductsSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productList.Add(MapReadToProduct(reader));
                }
            }

            return productList;
        }

        public IList<Product> GetAllUnapprovedProducts()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(getUnapprovedProductsSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productList.Add(MapReadToProduct(reader));
                }
            }

            return productList;
        }

        public Product GetItemByProductNumber(string productNumber)
        {
            Product item = new Product();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(getProductNumberSql, conn);
                cmd.Parameters.AddWithValue("@ProductNumber", productNumber);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    item=(MapReadToProduct(reader));
                }
                return item;
            }
        }


        private Product MapReadToProduct(SqlDataReader reader)
        {
            Product product = new Product();
            product.ProductNumber = Convert.ToString(reader["ProductNumber"]);
            product.ProductDescription = Convert.ToString(reader["ProductDescription"]);
            product.DefaultUOM = Convert.ToString(reader["DefaultUOM"]);
            product.IsSellable = Convert.ToInt32(reader["isSellable"]);
            product.CrossReference = Convert.ToString(reader["CrossReference"]);
            product.ItemType = Convert.ToInt32(reader["ItemType"]);
            product.IsDrugControlled = Convert.ToInt32(reader["isDrugControlled"]);
            product.ManufacturerId = Convert.ToString(reader["ManufacturerId"]);
            product.InventoryStatus = Convert.ToString(reader["InventoryStatus"]);
            product.AlternativeProducts = Convert.ToString(reader["AlternativeProducts"]);
            product.IsNonReturnable = Convert.ToInt32(reader["isNonReturnable"]);
            product.IsRefrigerated = Convert.ToInt32(reader["isRefrigerated"]);
            product.IsRegulated = Convert.ToInt32(reader["isRegulated"]);

            return product;
        }

    }
}

