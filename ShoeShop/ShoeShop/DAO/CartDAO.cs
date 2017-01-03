using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class CartDAO
    {
        public T GetCartByCartID<T>(int ID)
        {
            try
            {
                object result = null;
                result = Database.GetInstance().GetCartByCartID<T>(ID);
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}