using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class SystemDAO
    {
        /// <summary>
        /// Lấy tất cả dữ liệu có trong bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetDataFromTable<T>(TableType type)
        {
            try
            {
                object result = null;
                switch (type)
                {
                    case TableType.Item:
                        {
                            result = Database.GetInstance().GetAllItem<T>();
                            break;
                        }
                    case TableType.ItemDetail:
                        {
                            result = Database.GetInstance().GetAllItemDetail<T>();
                            break;
                        }
                    case TableType.ItemMeta:
                        {
                            result = Database.GetInstance().GetAllItemMeta<T>();
                            break;
                        }
                    default: break;
                }

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm mới 1 sản phẩm vào bảng Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddItem(Item req)
        {
            try
            {
                return Database.GetInstance().InsertTblItem(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm data vào bảng ItemDetail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool AddItemDetail(List<ItemDetail> req)
        {
            try
            {
                return Database.GetInstance().InsertTblItemDetail(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm data vào bảng ItemMeta
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool AddItemMeta(List<ItemMeta> req)
        {
            try
            {
                return Database.GetInstance().InsertTblItemMeta(req);
            }
            catch
            {
                throw;
            }
        }
    }
}