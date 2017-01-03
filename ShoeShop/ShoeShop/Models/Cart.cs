using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class Cart
    {
        public int ID { set; get; }
        public int ID_Customer { set; get; }
        public int Status { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}