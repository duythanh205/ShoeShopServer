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

        public GetOrderResponse GetOrderByID(int id)
        {
            OrderResponse res = null;
            try
            {
                var order = orderDAO.GetDataOrder<Orders>(TableType.Order, id);
                var listOrderDetail = orderDAO.GetDataOrder<List<OrderDetail>>(TableType.OrderDetail, id);

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}