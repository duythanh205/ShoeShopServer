using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class OrderDAO
    {
        /// <summary>
        /// Add vào Order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T AddOrder<T>(Orders req)
        {
            try
            {
                return Database.GetInstance().InsertTblOrder<T>(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add vào OrderDetail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T AddOrderDetail<T>(List<OrderDetail> req)
        {
            try
            {
                return Database.GetInstance().InsertTblOrderDetail<T>(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add vào OrderDetail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ItemDetail> GetItemDetailByItemID(List<OrderDetail> req)
        {
            try
            {
                List<ItemDetail> ListItemDetail = new List<ItemDetail>();
                req.ForEach(f => 
                {
                    var itemDetail = Database.GetInstance().GetItemDetailByItemID<ItemDetail>(f.ID_Item, f.Size);
                    ListItemDetail.Add(itemDetail);
                });

                return ListItemDetail;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add vào OrderDetail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetOrder<T>(int id)
        {
            try
            {
                return Database.GetInstance().GetOrderByID<T>(id);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get OrderDetail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetOrderDetail<T>(int id)
        {
            try
            {
                return Database.GetInstance().GetOrderDetail<T>(id);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add vào OrderDetail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateOrder(UpdateOrderREQUEST req, int id)
        {
            try
            {
                return Database.GetInstance().UpdateTblOrder(req, id);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get All orders
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetAllOrder<T>()
        {
            try
            {
                return Database.GetInstance().GetAllOrder<T>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add vào OrderDetail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateItemDetailNumberProduct(List<ItemDetail> req)
        {
            try
            {
                return Database.GetInstance().UpdateItemDetailNumberProduct(req);
            }
            catch
            {
                throw;
            }
        }
    }
}