using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApproval.DAL;
using ProductApproval.Models;

namespace ProductApproval.DAL
{
    public class ProductSqlDAO : IProductDAO
    {
        private readonly string connectionString;

        public ProductSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        List<Product> ProductList { get; set; }

        public IList<Product> GetAllProducts()
        {
            string sql = "";
            List<Product> productList = new List<Product>();





            return new List<Product>();
        }

        //IList<Product> IProductDAO.GetAllProducts()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
