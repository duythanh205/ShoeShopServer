using ShoeShop.DAO;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Service
{
    public class CartService
    {
        internal GetCartResponse GetCartByCartID(int id)
        {
            CartDAO cartDAO = new CartDAO();

            try
            {
                var ListCarts = cartDAO.GetCartByCartID<List<Cart>>(id);
                if (ListCarts != null && ListCarts.Count > 0)
                {
                    var res = ListCarts.Select(s => new CartResponse()
                    {
                        Cart = s,
                        ListCartDetail = cartDAO.GetCartByCartID<List<CartDetail>>(id)
                    }).ToList();

                    return new GetCartResponse()
                    {
                        ListCartResponse = res
                    };
                }

                return new GetCartResponse()
                {
                    ListCartResponse = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}