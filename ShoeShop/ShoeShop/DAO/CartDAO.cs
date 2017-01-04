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
        /// Lấy tất cả dữ liệu có trong bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetDataFromTable<T>(TableType type, int id)
        {
            try
            {
                object result = null;
                switch (type)
                {
                    case TableType.Cart:
                        {
                            result = Database.GetInstance().GetCartByCartID<T>(id);
                            break;
                        }
                    case TableType.CartDetail:
                        {
                            result = Database.GetInstance().GetCartDetailByCartID<T>(id);
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