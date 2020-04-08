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


        [HttpGet("{isSellable}", Name = "GetProducts")]
        public IList<Product> GetProducts(int isSellable)
        {

            if (isSellable == 1)
            {
                return dao.GetAllApprovedProducts();
            }
            else
            {
                return dao.GetAllUnapprovedProducts();
            }

        }
    }

    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private IProductDAO dao;

        public ItemController(IProductDAO dataAccessLayer)
        {
            dao = dataAccessLayer;
        }
        
        [HttpGet("{ProductNumber}", Name = "GetProductNumber")]
        public Product GetProductNumber(string productNumber)
        {

            if (productNumber != null)
            {
                return dao.GetItemByProductNumber(productNumber);
            }
            else
            {
                return new Product();
            }
        }

        [HttpPut("{productNumber}")]
        public ActionResult SwitchingIsSellable(string productNumber, Product product)
        {
            int isSellable = 0;
            Product prodNum = dao.GetItemByProductNumber(productNumber);

            if (prodNum != null)
            {
                if (prodNum.IsSellable == 0)
                {
                    isSellable = 1;
                }
                if (prodNum.IsSellable == 1)
                {
                    isSellable = 0;
                }
            }

            prodNum.IsSellable = product.IsSellable;

            //dao.SaveChanges(prodNum);

            return NoContent();
        }
    }

}
