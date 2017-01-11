using ShoeShop.DAO;
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
    public class CartController : ApiController
    {
        CartService cartService = new CartService();

        /// <summary>
        /// Lấy Cart theo ID
        /// </summary>
        /// <returns></returns>
        [Route("Api/Cart/v1/GetCartById/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCartById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                var result = cartService.GetCartByID(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.Data));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update 1 cart theo id
        /// </summary>
        /// <returns></returns>
        [Route("Api/Cart/v1/UpdateCart/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateCart([FromUri]int id, [FromBody] UpdateCartREQUEST req)
        {
            try
            {
                if (id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                var result = cartService.UpdateCart(id, req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, null));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Delete 1 cart theo id
        /// </summary>
        /// <returns></returns>
        [Route("Api/Cart/v1/DeleteCartDetail/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteCartDetail([FromUri]int id)
        {
            try
            {
                if (id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                var result = cartService.DeleteCartDetailByID(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, null));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }
    }
}
