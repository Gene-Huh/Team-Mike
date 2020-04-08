using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApproval.DAL;
using ProductApproval.Models;

namespace ProductApproval.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductDAO dao;

        public ProductsController(IProductDAO dataAccessLayer)
        {
            dao = dataAccessLayer;
        }

        [HttpGet]
        public IList<Product> GetAllProducts()
        {

            return dao.GetAllApprovedProducts();
        }

        [HttpGet("{isSellable}", Name = "GetProducts")]
        public IList<Product> GetProducts(int isSellable)
        {
            
            if(isSellable == 1)
            {
                return dao.GetAllApprovedProducts();
            }
            else 
            {
                return dao.GetAllUnapprovedProducts();
            }  
                      
        }
    }
}