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
    public class MyAccountController : ApiController
    {
        MyAccountService myAccountService = new MyAccountService();

        /// <summary>
        /// Thêm 1 account mới
        /// </summary>
        /// <returns></returns>
        [Route("Api/MyAccount/v1/AddAccount")]
        [HttpPost]
        public HttpResponseMessage AddAccount([FromBody] AddAccountREQUEST req)
        {
            try
            {
                if (req.ValidData())
                {
                    var result = myAccountService.AddAccount(req);
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
        /// Lấy account theo id
        /// </summary>
        /// <returns></returns>
        [Route("Api/MyAccount/v1/GetAccount/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAccountByID(int id)
        {
            try
            {
                var result = myAccountService.GetAccountByID(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.Data));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy account theo token va status
        /// account?token=dad&status=dadad
        /// </summary>
        /// <returns></returns>
        [Route("Api/MyAccount/v1/GetAccount")]
        [HttpGet]
        public HttpResponseMessage GetAccountByToken(string token, string status)
        {
            try
            {
                if(string.IsNullOrEmpty(token))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }
                if(string.IsNullOrEmpty(status))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }
                GetAccountREQUEST req = new GetAccountREQUEST()
                {
                    Status = status,
                    Token = token
                };

                var result = myAccountService.GetAccountByToken(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.Data));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Cập nhật account
        /// </summary>
        /// <returns></returns>
        [Route("Api/MyAccount/v1/UpdateAccount/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateAccount([FromUri] int id,  [FromBody] UpdateAccountREQUEST acc)
        {
            try
            {
                if (!acc.ValidData())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }
              
                var result = myAccountService.UpdateAccount(acc, id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.Account));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }
    }
}
