using ShoeShop.Models;
using ShoeShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeShop.Controllers
{
    public class OrderController : ApiController
    {
        OrderService orderService = new OrderService();

        [Route("Api/Order/v1/GetOrder/{id}")]
        [HttpGet]
        public HttpResponseMessage GetOrdeByID(int id)
        {
            try
            {
                if (id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                var result = orderService.GetOrderByID(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.orderResponse));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }
    }
}
