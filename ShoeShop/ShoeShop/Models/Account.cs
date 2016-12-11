using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class Account
    {
        public string ID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public DateTime CreatedDate { set; get; }
        public string Status { set; get; }
        public string Type { set; get; }
        public string FullName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
    }
}