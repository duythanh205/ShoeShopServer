using ShoeShop.DAO;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Service
{
    public class ItemService
    {
        ItemDAO itemDAO = new ItemDAO();

        /// <summary>
        /// Lấy tất cả sản phẩm theo điều kiện tìm kiếm là giới tính và loại
        /// </summary>
        /// <returns></returns>
        public GetItemResponse GetItemByGenderType(GetItemByGenderTypeRequest req)
        {
            try
            {
                var ListItems = itemDAO.GetItemByGenderType<List<Item>>(req);
                if (ListItems != null && ListItems.Count > 0)
                {
                    var res = ListItems.Select(s => new ItemResponse()
                    {
                        Item = s,
                        ListDetail = itemDAO.GetItemDetailByItemID<List<ItemDetail>>(s.ID),
                        ListMeta = itemDAO.GetItemMetaByItemID<List<ItemMeta>>(s.ID)
                    }).ToList();

                    return new GetItemResponse()
                    {
                        Code = ResStatusCode.Success,
                        ListItemResponse = res
                    };
                }

                return new GetItemResponse()
                {
                    Code = ResStatusCode.NotFoundItem,
                    ListItemResponse = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả sản phẩm theo điều kiện tìm kiếm là giá tiền
        /// </summary>
        /// <returns></returns>
        public GetItemResponse GetItemByPrice(GetItemByPriceRequest req)
        {
            try
            {
                var ListItems = itemDAO.GetItemByPrice<List<Item>>(req);
                if (ListItems != null && ListItems.Count > 0)
                {
                    var res = ListItems.Select(s => new ItemResponse()
                    {
                        Item = s,
                        ListDetail = itemDAO.GetItemDetailByItemID<List<ItemDetail>>(s.ID),
                        ListMeta = itemDAO.GetItemMetaByItemID<List<ItemMeta>>(s.ID)
                    }).ToList();

                    return new GetItemResponse()
                    {
                        Code = ResStatusCode.Success,
                        ListItemResponse = res
                    };
                }

                return new GetItemResponse()
                {
                    Code = ResStatusCode.NotFoundItem,
                    ListItemResponse = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả sản phẩm theo loại
        /// </summary>
        /// <returns></returns>
        public GetItemResponse GetItemByType(string type)
        {
            try
            {
                var ListItems = itemDAO.GetItemByType<List<Item>>(type);
                if (ListItems != null && ListItems.Count > 0)
                {
                    var res = ListItems.Select(s => new ItemResponse()
                    {
                        Item = s,
                        ListDetail = itemDAO.GetItemDetailByItemID<List<ItemDetail>>(s.ID),
                        ListMeta = itemDAO.GetItemMetaByItemID<List<ItemMeta>>(s.ID)
                    }).ToList();

                    return new GetItemResponse()
                    {
                        Code = ResStatusCode.Success,
                        ListItemResponse = res
                    };
                }

                return new GetItemResponse()
                {
                    Code = ResStatusCode.NotFoundItem,
                    ListItemResponse = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả sản phẩm theo màu sắc
        /// </summary>
        /// <returns></returns>
        public GetItemResponse GetItemByColor(string color)
        {
            try
            {
                var ListItems = itemDAO.GetItemByColor<List<Item>>(color);
                if (ListItems != null && ListItems.Count > 0)
                {
                    var res = ListItems.Select(s => new ItemResponse()
                    {
                        Item = s,
                        ListDetail = itemDAO.GetItemDetailByItemID<List<ItemDetail>>(s.ID),
                        ListMeta = itemDAO.GetItemMetaByItemID<List<ItemMeta>>(s.ID)
                    }).ToList();

                    return new GetItemResponse()
                    {
                        Code = ResStatusCode.Success,
                        ListItemResponse = res
                    };
                }

                return new GetItemResponse()
                {
                    Code = ResStatusCode.NotFoundItem,
                    ListItemResponse = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}