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
                if (ListDetail == null || ListDetail.Count == 0)
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
        public string Gender { set; get; }
        public string Type { set; get; }
    }

    public class GetItemByPriceRequest
    {
        public decimal MinPrice { set; get; }
        public decimal MaxPrice { set; get; }
    }

    public class AddAccountREQUEST : Account
    {
        //public Account Account { set; get; }
        public bool ValidData()
        {
            try
            {
                if (string.IsNullOrEmpty(this.FullName))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(this.Email))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(this.Token))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(this.Type))
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

    public class GetAccountREQUEST
    {
        public string Token { set; get; }
        public string Status { set; get; }
    }

    public class UpdateAccountREQUEST
    {
        public string Email { set; get; }
        public string Status { set; get; }
        public string Type { set; get; }
        public string FullName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }

        public bool ValidData()
        {
            try
            {
                if (string.IsNullOrEmpty(Email))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Status))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Type))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(FullName))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Address))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Phone))
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

    public class AddCartREQUEST : Cart
    {

    }

    public class UpdateCartREQUEST
    {
        public UpdateCartReq Cart { set; get; }
        public List<CartDetail> ListCartDetail { set; get; }
        //public List<Item> ListItem { set; get; }
    }

    public class UpdateCartReq
    {
        public int ID_Customer { set; get; }
        public string Status { set; get; }
    }

    public class AddOrderREQUEST
    {
        public Orders Order { set; get; }
        public List<OrderDetail> ListOrderDetail { set; get; }

        public bool ValidData()
        {
            try
            {
                if (string.IsNullOrEmpty(Order.Address))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Order.CustomerName))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Order.Note))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Order.Phone))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(Order.Status))
                {
                    return false;
                }
                if (Order.TotalPrice < 0)
                {
                    return false;
                }
                if (Order.ID_Customer < 0)
                {
                    return false;
                }
                if (ListOrderDetail.Count == 0)
                {
                    return false;
                }
                if (ListOrderDetail == null)
                {
                    return false;
                }


                return true;
            }
            catch
            {
                throw;
            }
        }
    }

    public class UpdateOrderREQUEST
    {
        public int Discount { set; get; }
        public string Status { set; get; }
        public DateTime EndDate { set; get; }
    }
}