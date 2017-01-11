using ShoeShop.DAO;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Service
{
    public class MyAccountService
    {
        MyAccountDAO myAccountDAO = new MyAccountDAO();

        /// <summary>
        /// Thêm 1 account vào
        /// </summary>
        /// <returns></returns>
        public AddAccountRESPONSE AddAccount(AddAccountREQUEST req)
        {
            try
            {
                int idCustomer = myAccountDAO.AddAccount(req);
                if (idCustomer > 0)
                {
                    //tạo giỏ hàng rổng của account này
                    //add cart
                    int idCart = myAccountDAO.AddCart(new AddCartREQUEST()
                    {
                        ID_Customer = idCustomer,
                        Status = "Active",
                    });

                    if (idCart > 0)
                    {
                        return new AddAccountRESPONSE()
                        {
                            Code = ResStatusCode.Success,
                            Data = new AccountResData()
                            {
                                Cart = new Cart()
                                {
                                    ID = idCart,
                                    ID_Customer = idCustomer,
                                    Status = "Active",
                                    CreatedDate = DateTime.Now
                                },
                                Account = new Account()
                                {
                                    Address = req.Address,
                                    CreatedDate = DateTime.Now,
                                    Email = req.Email,
                                    FullName = req.FullName,
                                    ID = idCustomer,
                                    ID_Cart = idCart,
                                    Phone = req.Phone,
                                    Status = req.Status,
                                    Token = req.Token,
                                    Type = req.Type
                                },
                                CartDetail = new List<CartDetail>()
                            },
                        };
                    }

                }

                return new AddAccountRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
                    Data = null,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy Account theo id
        /// </summary>
        /// <returns></returns>
        public GetAccountRESPONSE GetAccountByID(int id)
        {
            try
            {
                Account acc = myAccountDAO.GetAccountByID<Account>(id);
                if (acc != null)
                {
                    //Lấy giỏ hàng ra
                    Cart cart = myAccountDAO.GetCartByID<Cart>(acc.ID_Cart);

                    if (cart != null)
                    {
                        return new GetAccountRESPONSE()
                        {
                            Code = ResStatusCode.Success,
                            Data = new AccountResData()
                            {
                                Cart = cart,
                                Account = acc,
                                CartDetail = new List<CartDetail>()
                            },
                        };
                    }

                }

                return new GetAccountRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
                    Data = null,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy Account theo token
        /// </summary>
        /// <returns></returns>
        public GetAccountRESPONSE GetAccountByToken(GetAccountREQUEST req)
        {
            try
            {
                Account acc = myAccountDAO.GetAccountByToken<Account>(req);
                if (acc != null)
                {
                    //Lấy giỏ hàng ra
                    Cart cart = myAccountDAO.GetCartByID<Cart>(acc.ID_Cart);

                    if (cart != null)
                    {
                        return new GetAccountRESPONSE()
                        {
                            Code = ResStatusCode.Success,
                            Data = new AccountResData()
                            {
                                Cart = cart,
                                Account = acc,
                                CartDetail = new List<CartDetail>()
                            },
                        };
                    }

                }

                return new GetAccountRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
                    Data = null,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <returns></returns>
        public UpdateAccountRESPONSE UpdateAccount(UpdateAccountREQUEST req, int id)
        {
            try
            {
                Account acc = myAccountDAO.UpdateAccount<Account>(req, id);
                if (acc != null)
                {
                    return new UpdateAccountRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        Account = acc
                    };
                }

                return new UpdateAccountRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
                    Account = null,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}