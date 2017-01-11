using ShoeShop.DAO;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Service
{
    public class OrderService
    {
        OrderDAO orderDAO = new OrderDAO();

        /// <summary>
        /// Lấy cart theo id
        /// </summary>
        /// <returns></returns>
        public AddOrderRESPONSE AddOrder(AddOrderREQUEST req)
        {
            try
            {
                Orders order = null;
                List<OrderDetail> orderDetail = null;
                //Lấy danh sách Item detail theo ID_Item ra
                //Với mỗi ID_Item và Size. So sánh số lượng (numberproduct) trong ListOrderDetail và ItemDetail
                var ListItemDetail = orderDAO.GetItemDetailByItemID(req.ListOrderDetail);
                if (ListItemDetail != null && ListItemDetail.Count > 0)
                {
                    bool correct = CheckNumberProduct(ListItemDetail, req.ListOrderDetail);
                    if (!correct)
                    {
                        return new AddOrderRESPONSE()
                        {
                            Code = ResStatusCode.NotEnoughItem,
                            Data = null
                        };
                    }

                    order = orderDAO.AddOrder<Orders>(req.Order);
                    var ListOrderDetail = req.ListOrderDetail.Select(s => new OrderDetail()
                    {
                        ID = s.ID,
                        ID_Item = s.ID_Item,
                        ID_Order = order.ID,
                        NumberProduct = s.NumberProduct,
                        Price = s.Price,
                        Size = s.Size
                    }).ToList();
                    orderDetail = orderDAO.AddOrderDetail<List<OrderDetail>>(ListOrderDetail);

                    //Update ListItem Detail
                    int n = ListItemDetail.Count;
                    for (int i = 0; i < n; i++)
                    {
                        ListItemDetail[i].NumberProduct = ListItemDetail[i].NumberProduct - ListOrderDetail[i].NumberProduct;
                    }
                    orderDAO.UpdateItemDetailNumberProduct(ListItemDetail);

                    return new AddOrderRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        Data = new AddOrderBE()
                        {
                            ListOrderDetail = orderDetail,
                            Order = order
                        }
                    };
                }

                return new AddOrderRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
                    Data = null
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckNumberProduct(List<ItemDetail> listItemDetail, List<OrderDetail> listOrderDetail)
        {
            try
            {
                if (listItemDetail.Count != listOrderDetail.Count)
                {
                    return false;
                }

                int n = listItemDetail.Count;
                for (int i = 0; i < n; i++)
                {
                    if (listOrderDetail[i].NumberProduct > listItemDetail[i].NumberProduct)
                    {
                        return false;
                    }
                }

                return true;
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
        public GetOrderRESPONSE GetOrder(int id)
        {
            try
            {
                var order = orderDAO.GetOrder<Orders>(id);
                var orderDetail = orderDAO.GetOrderDetail<List<OrderDetail>>(id);
                
                if(order != null && orderDetail.Count > 0)
                {
                    return new GetOrderRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        Data = new GetOrderBE()
                        {
                            ListOrderDetail = orderDetail,
                            Order = order
                        }
                    };
                }
                

                return new GetOrderRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
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
        public UpdateOrderRESPONSE UpdateOrder(UpdateOrderREQUEST req, int id)
        {
            try
            {
                int res = orderDAO.UpdateOrder(req, id);
                if(res > 0)
                {
                    return new UpdateOrderRESPONSE()
                    {
                        Code = ResStatusCode.Success
                    };
                }


                return new UpdateOrderRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
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
        public GetAllOrderRESPONSE GetAllOrders()
        {
            try
            {
                var ListOrder = orderDAO.GetAllOrder<List<Orders>>();
                if(ListOrder != null && ListOrder.Count > 0)
                {
                    var res = ListOrder.Select(s => new OrderRESPONSE()
                    {
                        Order = s,
                        ListOrderDetail = orderDAO.GetOrderDetail<List<OrderDetail>>(s.ID)
                    }).ToList();

                    return new GetAllOrderRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        listOrder = res,
                    };
                }

                return new GetAllOrderRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
                    listOrder = null
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}