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

        public UpdateCartResponse UpdateCart(int id, UpdateCartRequest req)
        {

            try
            {
                int ID = cartDAO.UpdateCart(id,req.cart);
                if (ID != -1 && ID > 0)
                {
                    return new UpdateCartResponse()
                    {
                        Code = ResStatusCode.UpdateCartSucess
                    };
                }

                return new UpdateCartResponse()
                {
                    Code = ResStatusCode.UpdateCartFail
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}