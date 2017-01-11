using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeShop.DAO;
using ShoeShop.Lib;
using ShoeShop.Models;
using ShoeShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.DAO.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        [TestMethod()]
        public void DeleteCartDetailTest()
        {
            //int id = 2;
            //Database.GetInstance().DeleteCartDetailByIDCart(id);
            //Orders req = new Orders()
            //{
            //    Address = "477/4",
            //    CustomerName = "DThanh",
            //    Discount = 7.5f,
            //    EndDate = DateTime.Now.AddDays(3),
            //    ID_Customer = 1,
            //    Note = "dada",
            //    Phone = "01248756",
            //    Status = "dstt",
            //    TotalPrice = 750000
            //};
            //var res = Database.GetInstance().InsertTblOrder<Orders>(req);

            //List<OrderDetail> req = new List<OrderDetail>()
            //{
            //    new OrderDetail()
            //    {
            //        ID_Item = 1,
            //        ID_Order = 1,
            //        NumberProduct = 2,
            //        Price = 750000
            //    },
            //    new OrderDetail()
            //    {
            //        ID_Item = 2,
            //        ID_Order = 1,
            //        NumberProduct = 2,
            //        Price = 150000
            //    },
            //    new OrderDetail()
            //    {
            //        ID_Item = 3,
            //        ID_Order = 1,
            //        NumberProduct = 2,
            //        Price = 950000
            //    },
            //};

            //var res = Database.GetInstance().InsertTblOrderDetail<List<OrderDetail>>(req);
            //var res = Database.GetInstance().GetOrderByID<Orders>(3);
            //var res = Database.GetInstance().GetOrderDetail<List<OrderDetail>>(1);
            OrderService o = new OrderService();
            //var res = o.GetOrder(4);
            //UpdateOrderREQUEST iq = new UpdateOrderREQUEST()
            //{
            //    Discount = 20,
            //    EndDate = DateTime.Now.AddDays(7),
            //    Status = "Finish"
            //};
            //var rs = o.UpdateOrder(iq, 5);

            //var r = o.GetAllOrders();


            //var str = DateTime.Now.AddDays(2).ToString("yyyyMMdd");


            //var dt = DateTime.Now.AddDays(3);

            //string str = dt.ToJson();

            //string da = "1/9/2017";
            //string kl = da.ToJson();

            //DateTime dd = kl.FromJson<DateTime>();

             decimal d = 100, b = 200;
            int k = 1;

            d = b - k;

            int i;
            i = 0;
        }

    }
}