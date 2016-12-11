using AttributeRouting.Web.Http;
using ShoeShop.DAO;
using ShoeShop.Models;
using ShoeShop.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeShop.Controllers
{
    public class ItemController : ApiController
    {
        ItemService itemService = new ItemService();

        /// <summary>
        /// Tìm các sản phẩm theo giới tính và loại
        /// </summary>
        /// <returns></returns>
        [Route("Api/Item/v1/SearchItem/{gender}/{type}")]
        [HttpGet]
        public HttpResponseMessage GetItemByGenderType(string gender, string type)
        {
            try
            {
                if (string.IsNullOrEmpty(gender))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }
                if (!gender.ToUpper().Equals("MALE") && !gender.ToUpper().Equals("FEMALE"))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }
                if(!DataAccess.getInstance().getListCacheData<List<string>>(CacheDataType.TypeOfItem).Exists(e => e.Equals(type.ToUpper())))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                GetItemByGenderTypeRequest req = new GetItemByGenderTypeRequest()
                {
                    Gender = (Sex)Enum.Parse(typeof(Sex), gender.ToUpper()),
                    Type = type,
                };

                var result = itemService.GetItemByGenderType(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListItemResponse));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Tìm các sản phẩm theo giá tiền
        /// </summary>
        /// <returns></returns>
        /// Api/Item/v1/SearchItem?MinPrice=300&MaxPrice=500
        [Route("Api/Item/v1/SearchItemByPrice")]
        [HttpGet]
        public HttpResponseMessage GetItemByPrice(decimal MinPrice, decimal MaxPrice)
        {
            try
            {
                if (MinPrice == 0 && MaxPrice == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }
                if (MinPrice > MaxPrice)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                GetItemByPriceRequest req = new GetItemByPriceRequest()
                {
                    MaxPrice = MaxPrice,
                    MinPrice = MinPrice
                };

                var result = itemService.GetItemByPrice(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListItemResponse));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Tìm các sản phẩm theo loại
        /// </summary>
        /// <returns></returns>
        [Route("Api/Item/v1/SearchItemByType/{type}")]
        [HttpGet]
        public HttpResponseMessage GetItemByType(string type)
        {
            try
            {
                if (string.IsNullOrEmpty(type))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }
                if (!DataAccess.getInstance().getListCacheData<List<string>>(CacheDataType.TypeOfItem).Exists(e => e.Equals(type.ToUpper())))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                var result = itemService.GetItemByType(type);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListItemResponse));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Tìm các sản phẩm theo loại
        /// </summary>
        /// <returns></returns>
        [Route("Api/Item/v1/SearchItemByColor/{color}")]
        [HttpGet]
        public HttpResponseMessage GetItemByColor(string color)
        {
            try
            {
                if (string.IsNullOrEmpty(color))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }
                if (!DataAccess.getInstance().getListCacheData<List<string>>(CacheDataType.ColorOfItem).Exists(e => e.Equals(color.ToUpper())))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                var result = itemService.GetItemByColor(color);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListItemResponse));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }
    }
}
