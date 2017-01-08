using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class OrderDetail
    {
        public int ID { set; get; }
        public int ID_Order { set; get; }
        public int ID_Item { set; get; }
        public int NumberProduct { set; get; }
        public decimal Price { set; get; }
    }
}