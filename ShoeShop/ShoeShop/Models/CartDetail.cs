using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class CartDetail
    {
        public int ID { set; get; }
        public int ID_Cart { set; get; }
        public int ID_Item { set; get; }
        public int ProductNumber { set; get; }
        public decimal Price { set; get; }
    }
}