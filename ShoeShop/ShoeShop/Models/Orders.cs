using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class Orders
    {
        public int ID { set; get; }
        public int ID_Customer { set; get; }
        public string CustomerName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Status { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime EndDate { set; get; }
        public float Discount { set; get; }
        public string Note { set; get; }
        public decimal TotalPrice { set; get; }
    }
}