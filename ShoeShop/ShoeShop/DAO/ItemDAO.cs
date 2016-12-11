using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class ItemDAO
    {
        /// <summary>
        /// Tìm kiếm sản phẩm theo Giới tính và Loại
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetItemByGenderType<T>(GetItemByGenderTypeRequest req)
        {
            try
            {
                object result = null;             
                result = Database.GetInstance().GetItemByGenderType<T>(req);
                           
                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách các ItemDetail trong bảng ItemDetail theo khóa chính ID của Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetItemDetailByItemID<T>(int ID)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetItemDetailByItemID<T>(ID);

                return (T)result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy danh sách các ItemMeta trong bảng ItemMeta theo khóa chính ID của Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetItemMetaByItemID<T>(int ID)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetItemMetaByItemID<T>(ID);

                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo giá tiền
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetItemByPrice<T>(GetItemByPriceRequest req)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetItemByPrice<T>(req);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo loại
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetItemByType<T>(string type)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetItemByType<T>(type);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo màu sắc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetItemByColor<T>(string color)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetItemByColor<T>(color);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }
    }
}