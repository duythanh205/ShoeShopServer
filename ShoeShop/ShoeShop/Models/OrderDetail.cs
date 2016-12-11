using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class OrderDetail
    {
        public string ID { set; get; }
        public string ID_Order { set; get; }
        public string ID_Item { set; get; }
        public string NumberProduct { set; get; }
        public decimal Price { set; get; }
    }
}