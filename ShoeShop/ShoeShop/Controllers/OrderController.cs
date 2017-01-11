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

        /// <summary>
        /// Thêm vào `1 order
        /// </summary>
        /// <returns></returns>
        [Route("Api/Order/v1/AddOrder")]
        [HttpPost]
        public HttpResponseMessage AddOrder([FromBody] AddOrderREQUEST req)
        {
            try
            {
                if (req.ValidData())
                {
                    var result = orderService.AddOrder(req);
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.Data));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError, null));
            }
        }

        /// <summary>
        /// Thêm vào `1 order
        /// </summary>
        /// <returns></returns>
        [Route("Api/Order/v1/GetOrder/{id}")]
        [HttpGet]
        public HttpResponseMessage GetOrder([FromUri] int id)
        {
            try
            {
                if (id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = orderService.GetOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.Data));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError, null));
            }
        }

        /// <summary>
        /// Thêm vào `1 order
        /// </summary>
        /// <returns></returns>
        [Route("Api/Order/v1/UpdateOrder/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateOrder([FromUri] int id, [FromBody] UpdateOrderREQUEST req)
        {
            try
            {
                if (id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = orderService.UpdateOrder(req, id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, null));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError, null));
            }
        }

        /// <summary>
        /// Thêm vào `1 order
        /// </summary>
        /// <returns></returns>
        [Route("Api/Order/v1/GetALlOrder")]
        [HttpGet]
        public HttpResponseMessage GetALlOrder()
        {
            try
            {
                var result = orderService.GetAllOrders();
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.listOrder));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError, null));
            }
        }
    }
}
