using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class Cart
    {
        public string ID { set; get; }
        public string ID_Customer { set; get; }
        public string Status { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}