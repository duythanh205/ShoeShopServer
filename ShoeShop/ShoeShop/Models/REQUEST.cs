using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class AddItemRequest
    {
        public Item Item { set; get; }
        public List<ItemDetail> ListDetail { set; get; }
        public List<ItemMeta> ListMeta { set; get; }

        public bool ValidData()
        {
            try
            {
                if (string.IsNullOrEmpty(Item.Brand))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Item.Category))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Item.Color))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Item.Type))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Item.Status))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Item.ProductName))
                {
                    return false;
                }
                if (Item.Price <= 0)
                {
                    return false;
                }
                if(ListDetail == null || ListDetail.Count == 0)
                {
                    return false;
                }
                if (ListMeta == null || ListMeta.Count == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class GetItemByGenderTypeRequest
    {
        public Sex Gender { set; get; }
        public string Type { set; get; }
    }

    public class GetItemByPriceRequest
    {
        public decimal MinPrice { set; get; }
        public decimal MaxPrice { set; get; }
    }

    public class GetCartByIDRequest
    {
        public int ID { set; get; }
    }
}
