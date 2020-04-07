using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApproval.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
    }
}
