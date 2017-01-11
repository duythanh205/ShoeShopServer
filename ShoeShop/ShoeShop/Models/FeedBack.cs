using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class FeedBack
    {
        public int ID { set; get; }
        public string Email { set; get; }
        public DateTime CreatedDate { set; get; }
        public string Contents { set; get; }
        public string Status { set; get; }
    }
}