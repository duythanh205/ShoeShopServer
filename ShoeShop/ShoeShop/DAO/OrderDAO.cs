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
        /// Lấy tất cả dữ liệu có trong bảng Order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetDataOrder <T>(TableType type, int id)
        {
            try
            {
                object result = null;
                switch (type)
                {
                    case TableType.Order:
                        {
                            result = Database.GetInstance().GetOrderByID<T>(id);
                            break;
                        }
                    case TableType.OrderDetail:
                        {
                            result = Database.GetInstance().GetOrderDetailByID<T>(id);
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
    }
}