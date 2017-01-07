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
        CartDAO cartDAO = new CartDAO();
        public GetCartResponse GetCartByCartID(int id)
        {
            CartResponse res = null;
            try
            {
                var cart = cartDAO.GetDataFromTable<Cart>(TableType.Cart, id);
                var listCartDetail = cartDAO.GetDataFromTable<List<CartDetail>>(TableType.CartDetail, id);

                return new GetCartResponse()
                {
                    cartResponse = new CartResponse()
                    {
                        Cart = cart,
                        ListCartDetail = listCartDetail,
                    },
                    Code = ResStatusCode.Success
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CartResponse UpdateCart(int id, UpdateCartRequest req)
        {

            throw new NotImplementedException();
        }
    }
}