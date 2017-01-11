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

        /// <summary>
        /// Lấy cart theo id
        /// </summary>
        /// <returns></returns>
        public GetCartRESPONSE GetCartByID(int id)
        {
            try
            {
                var cart = cartDAO.GetCartById<Cart>(id);
                var listCartDetail = cartDAO.GetCartDetailByCartID<List<CartDetail>>(id);
                var listItemID = listCartDetail.Select(s => s.ID_Item).ToList();
                var listItem = cartDAO.GetListItemByID<List<ItemBE>>(listItemID);
                //var listItemMeta = cartDAO.GetListItemMetaByID<List<ItemMeta>>(listItemID);

                if (cart != null)
                {
                    return new GetCartRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        Data = new CartResData()
                        {
                            Cart = cart,
                            ListCartDetail = listCartDetail,
                            ListItem = listItem
                        },
                    };
                }

                return new GetCartRESPONSE()
                {
                    Code = ResStatusCode.NotFoundItem,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy cart theo id
        /// </summary>
        /// <returns></returns>
        public UpdateCartRESPONSE UpdateCart(int id, UpdateCartREQUEST req)
        {
            try
            {
                var cart = cartDAO.UpdateCart<Cart>(req.Cart, id);
                if (cart != null)
                {
                    if (req.ListCartDetail.Count == 0)
                    {
                        //Xóa toàn bộ
                        int res = cartDAO.DeleteCartDetailByIDCart(id);
                    }
                    else
                    {
                        req.ListCartDetail.ForEach(f =>
                        {
                            if (f.ID == -1)
                            {
                            //thêm mới cart detail
                            int res = cartDAO.AddCartDetail(f);
                            }
                            else
                            {
                            //Update cart detail này
                            var res = cartDAO.UpdateCartDetail<CartDetail>(f, f.ID);
                            }
                        });
                    }

                    return new UpdateCartRESPONSE()
                    {
                        Code = ResStatusCode.Success
                    };
                }

                return new UpdateCartRESPONSE()
                {
                    Code = ResStatusCode.NotFoundItem,
                    //Data = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy cart theo id
        /// </summary>
        /// <returns></returns>
        public DeleteCartDetailRESPONSE DeleteCartDetailByID(int id)
        {
            try
            {
                int res = cartDAO.DeleteCartDetailByID(id);
                if (res > 0)
                {
                    return new DeleteCartDetailRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                    };
                }

                return new DeleteCartDetailRESPONSE()
                {
                    Code = ResStatusCode.NotFoundItem,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}