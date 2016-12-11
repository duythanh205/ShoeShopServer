using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class ItemMeta
    {
        public int ID { set; get; }
        public int ID_Item { set; get; }
        public string MetaKey { set; get; }
        public string MetaValue { set; get; }
    }
}