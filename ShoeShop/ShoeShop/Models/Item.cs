using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class Item
    {
        public int ID { set; get; }
        public string ProductName { set; get; }
        public string Brand { set; get; }
        public string Color { set; get; }
        public string Gender { set; get; }
        public string Status { set; get; }
        public string Type { set; get; }
        public DateTime CreatedDate { set; get; }
        public string Category { set; get; }
        public decimal Price { set; get; }
    }
}