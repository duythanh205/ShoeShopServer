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
        //[Route("Api/Card/v1/{id}")]
        //[HttpGet]
        public HttpResponseMessage GetCardByCartID(int id)
        {
            try
            {
                if(id.Equals(null) == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }
               
                var result = CartService.GetCartByCartID(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListCartResponse));
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }
        
    }
}
