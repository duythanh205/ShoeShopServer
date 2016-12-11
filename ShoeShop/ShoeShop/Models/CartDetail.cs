using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class CartDetail
    {
        public string ID { set; get; }
        public string ID_Cart { set; get; }
        public string ID_Item { set; get; }
        public string ProductNumber { set; get; }
        public decimal Price { set; get; }
    }
}