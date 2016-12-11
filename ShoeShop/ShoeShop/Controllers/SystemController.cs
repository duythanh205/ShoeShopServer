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
    public class SystemController : ApiController
    {
        SystemService systemService = new SystemService();

        /// <summary>
        /// Lấy tất cả các Item có trong cửa hàng
        /// </summary>
        /// <returns></returns>
        [Route("Api/System/v1/GetAllItem")]
        [HttpGet]
        public HttpResponseMessage GetAllItem()
        {
            try
            {
                var result = systemService.GetAllItem();
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListItemResponse));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Thêm 1 sản phẩm vào cửa hàng
        /// </summary>
        /// <returns></returns>
        [Route("Api/System/v1/AddItem")]
        [HttpPost]
        public HttpResponseMessage AddItem([FromBody] AddItemRequest req)
        {
            try
            {
                if (req.ValidData())
                {
                    var result = systemService.AddItem(req);
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, null));
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
    }
}
