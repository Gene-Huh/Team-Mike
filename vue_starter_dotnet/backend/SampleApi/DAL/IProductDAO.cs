﻿using ProductApproval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApproval.DAL
{
    public interface IProductDAO
    {
        
        IList<Product> GetAllApprovedProducts();

        IList<Product> GetAllUnapprovedProducts();

        Product GetItemByProductNumber(string var);

        //void SwitchingIsSellable(Product product);

        int UpdateIsSellable(string productNumber, int isSellable);


    }
}
