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
                    productList.Add(new Product()
                    {
                        ProductNumber = Convert.ToString(reader["ProductNumber"]),
                        ProductDescription = Convert.ToString(reader["ProductDescription"]),
                        DefaultUOM = Convert.ToString(reader["DefaultUOM"]),
                        IsSellable = Convert.ToInt32(reader["isSellable"]),
                        CrossReference = Convert.ToString(reader["CrossReference"]),
                        ItemType = Convert.ToInt32(reader["ItemType"]),
                        IsDrugControlled = Convert.ToInt32(reader["isDrugControlled"]),
                        ManufacturerId = Convert.ToString(reader["ManufacturerId"]),
                        InventoryStatus = Convert.ToString(reader["InventoryStatus"]),
                        AlternativeProducts = Convert.ToString(reader["AlternativeProducts"]),
                        IsNonReturnable = Convert.ToInt32(reader["isNonReturnable"]),
                        IsRefrigerated = Convert.ToInt32(reader["isRefrigerated"]),
                        IsRegulated = Convert.ToInt32(reader["isRegulated"])
                    });
                }
            }

            return productList;
        }

        public IList<Product> GetAllUnapprovedProducts()
        {
            throw new NotImplementedException();
        }
     
            
        
    }
}
       
    