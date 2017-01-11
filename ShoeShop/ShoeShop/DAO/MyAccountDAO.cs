using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class MyAccountDAO
    {
        /// <summary>
        /// Thêm mới 1 account
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddAccount(AddAccountREQUEST req)
        {
            try
            {
                return Database.GetInstance().InsertTblAccount(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm mới 1 cart
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddCart(AddCartREQUEST req)
        {
            try
            {
                return Database.GetInstance().InsertTblCart(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy account theo id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetAccountByID<T>(int id)
        {
            try
            {
                return Database.GetInstance().GetAccountByID<T>(id);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy cart theo id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetCartByID<T>(int id)
        {
            try
            {
                return Database.GetInstance().GetCartByCartID<T>(id);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy account theo token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetAccountByToken<T>(GetAccountREQUEST req)
        {
            try
            {
                return Database.GetInstance().GetAccountByToken<T>(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Account
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T UpdateAccount<T>(UpdateAccountREQUEST req, int id)
        {
            try
            {
                return Database.GetInstance().UpdateTblAccount<T>(req, id);
            }
            catch
            {
                throw;
            }
        }
    }
}