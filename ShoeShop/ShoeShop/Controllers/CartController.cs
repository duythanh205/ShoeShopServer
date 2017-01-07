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
        CartService CartService = new CartService();

        /// <summary>
        /// Xem sản phẩm có trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        [Route("Api/Cart/v1/GetCart/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCartByCartID(int id)
        {
            try
            {
                if(id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }
               
                var result = CartService.GetCartByCartID(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.cartResponse));
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        [Route("Api/Cart/v1/UpdateCart/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateCart(int id,[FromBody] UpdateCartRequest req)
        {
            try
            {
                if(req.ValidData() == true)
                {
                    var result = CartService.UpdateCart(id, req);
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace());
                }
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }
        
    }
}
