using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class CartDAO
    {
        /// <summary>
        /// Lấy Cart theo id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetCartById<T>(int id)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetCartByCartID<T>(id);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy Cart Detail theo ID_cart
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetCartDetailByCartID<T>(int id)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetCartDetailByCartID<T>(id);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy Cart Detail theo ID_cart
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetListItemByID<T>(List<int> ids)
        {
            try
            {
                object result = null;
                List<ItemBE> listItem = new List<ItemBE>();

                ids.ForEach(f =>
                {
                    var item = Database.GetInstance().GetItemByID<Item>(f);
                    ItemBE itemBE = new ItemBE(item);
                    //lấy danh sách item meta
                    itemBE.listItemMeta = GetListItemMetaByID(f);
                    listItem.Add(itemBE);
                });

                result = listItem.ToList();
                return (T)result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy danh sách Item Meta theo item id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<ItemMeta> GetListItemMetaByID(int id)
        {
            try
            {
                var listItemMeta = Database.GetInstance().GetItemMetaByItemID<List<ItemMeta>>(id);
                return listItemMeta.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách Item Meta theo item id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T UpdateCart<T>(UpdateCartReq req, int id)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().UpdateTblCart<T>(req, id);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách Item Meta theo item id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T UpdateCartDetail<T>(CartDetail req, int id)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().UpdateTblCartDetail<T>(req, id);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách Item Meta theo item id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddCartDetail(CartDetail req)
        {
            try
            {
                return Database.GetInstance().InsertTblCartDetail(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách Item Meta theo item id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int DeleteCartDetailByIDCart(int ID_Cart)
        {
            try
            {
                return Database.GetInstance().DeleteCartDetailByIDCart(ID_Cart);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int DeleteCartDetailByID(int ID)
        {
            try
            {
                return Database.GetInstance().DeleteCartDetailByID(ID);
            }
            catch
            {
                throw;
            }
        }
    }
}