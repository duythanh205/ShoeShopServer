using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeShop.Models;
using ShoeShop.Lib;
using ShoeShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Service.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService service = new OrderService();
            AddOrderREQUEST req = new AddOrderREQUEST()
            {
                Order = new Orders()
                {
                    Address = "477/4",
                    CustomerName = "DThanh",
                    Discount = 7,
                    EndDate = DateTime.Now.AddDays(3),
                    ID_Customer = 1,
                    Note = "dada",
                    Phone = "01248756",
                    Status = "dstt",
                    TotalPrice = 750000,

                },
                ListOrderDetail = new List<OrderDetail>()
                {
                    new OrderDetail()
                {
                    ID_Item = 1,
                    ID_Order = 1,
                    NumberProduct = 1,
                    Price = 750000,
                    Size = "30"
                },
                new OrderDetail()
                {
                    ID_Item = 1,
                    ID_Order = 1,
                    NumberProduct = 5,
                    Price = 150000,
                    Size = "31"
                },
                }
            };

            //req.ListOrderDetail = new List<OrderDetail>();

            //string ss = ""
            //AddOrderREQUEST my = ;

            var kq = service.AddOrder(req);
            int i;
            i = 0;
        }
    }
}