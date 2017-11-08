using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Wexin.Models
{
    public class Confirm_OrderViewModel
    {
        public Customer User { get; set; }
        public List<Product> Products { get; set; }
        public string [] ProCounts { get; set; }
        public decimal? OrderTotal { get; set; }
        public decimal? Expressprice { get; set; }
        public bool IsPinkage { get; set; }
        public string BuyType{ get;set;}
    }
}