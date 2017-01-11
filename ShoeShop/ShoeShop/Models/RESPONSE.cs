using ShoeShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ShoeShop.Models
{ 
    public class ItemResponse
    {
        public Item Item { set; get; }
        public List<ItemDetail> ListDetail { set; get; }
        public List<ItemMeta> ListMeta { set; get; }

        public ItemResponse()
        {
            ListDetail = new List<ItemDetail>();
            ListMeta = new List<ItemMeta>();
        }

        public ItemResponse(Item item)
        {
            ItemDAO itemDAO = new ItemDAO();
            try
            {
                Item = item;
                ListDetail = itemDAO.GetItemDetailByItemID<List<ItemDetail>>(item.ID);
                ListMeta = itemDAO.GetItemMetaByItemID<List<ItemMeta>>(item.ID);
            }
            catch
            {
                throw;
            }
        }
    }

    public class GetAllItemResponse
    {
        public List<ItemResponse> ListItemResponse { set; get; }
        public ResStatusCode Code { set; get; }
    }

    public class AddItemResponse
    {
        public ResStatusCode Code { set; get; }
    }

    public class GetItemResponse
    {
        public List<ItemResponse> ListItemResponse { set; get; }
        public ResStatusCode Code { set; get; }
    }

    public class AddAccountRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public AccountResData Data { set; get; }
    }

    public class AccountResData
    {
        public Account Account { set; get; }
        public Cart Cart { set; get; }
        public List<CartDetail> CartDetail { set; get; }
    }

    public class GetAccountRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public AccountResData Data { set; get; }
    }

    public class UpdateAccountRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public Account Account { set; get; }
    }

    public class GetCartRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public CartResData Data { set; get; }
    }

    public class CartResData
    {
        public Cart Cart { set; get; }
        public List<CartDetail> ListCartDetail { set; get; }
        public List<ItemBE> ListItem { set; get; }
        //public List<ItemMeta> ListItemMeta { set; get; }
    }

    public class UpdateCartRESPONSE
    {
        public ResStatusCode Code { set; get; }
    }

    public class DeleteCartDetailRESPONSE
    {
        public ResStatusCode Code { set; get; }
    }

    public class ItemBE : Item
    {
        public List<ItemMeta> listItemMeta { set; get; }

        public ItemBE(Item item)
        {
            this.Brand = item.Brand;
            this.Category = item.Category;
            this.Color = item.Color;
            this.CreatedDate = item.CreatedDate;
            this.Gender = item.Gender;
            this.ID = item.ID;
            this.Price = item.Price;
            this.ProductName = item.ProductName;
            this.Status = item.Status;
            this.Type = item.Type;
        }
    }

    public class AddOrderRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public AddOrderBE Data { set; get; }
    }
    public class AddOrderBE
    {
        public Orders Order { set; get; }
        public List<OrderDetail> ListOrderDetail { set; get; }
    }

    public class GetOrderRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public GetOrderBE Data { set; get; }
    }

    public class GetOrderBE
    {
        public Orders Order { set; get; }
        public List<OrderDetail> ListOrderDetail { set; get; }
    }

    public class UpdateOrderRESPONSE
    {
        public ResStatusCode Code { set; get; }
    }

    public class GetAllOrderRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public List<OrderRESPONSE> listOrder { set; get; }
    }

    public class OrderRESPONSE
    {
        public Orders Order { set; get; }
        public List<OrderDetail> ListOrderDetail { set; get; }
    }
}