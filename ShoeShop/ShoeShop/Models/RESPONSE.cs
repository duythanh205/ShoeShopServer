﻿using ShoeShop.DAO;
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
}