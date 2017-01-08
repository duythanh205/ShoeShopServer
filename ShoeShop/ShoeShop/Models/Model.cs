using ShoeShop.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public enum TableType
    {
        Item = 1,
        ItemDetail = 2,
        ItemMeta = 3,
        Cart = 4,
        CartDetail = 5,
        Order = 6,
        OrderDetail = 7,
    }

    public enum CacheDataType
    {
        TypeOfItem = 1,
        ColorOfItem = 2,
    }
}