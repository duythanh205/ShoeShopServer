using ShoeShop.DAO;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Service
{
    public class SystemService
    {
        SystemDAO systemDAO = new SystemDAO();

        /// <summary>
        /// Lấy tất cả sản phẩm có trong cửa hàng
        /// </summary>
        /// <returns></returns>
        public GetAllItemResponse GetAllItem()
        {
            List<ItemResponse> res = new List<ItemResponse>();

            try
            {
                var listItem = GetDataFromTable<List<Item>>(TableType.Item);
                var listItemDetail = GetDataFromTable<List<ItemDetail>>(TableType.ItemDetail);
                var listItemMeta = GetDataFromTable<List<ItemMeta>>(TableType.ItemMeta);

                res = listItem.Select(s => new ItemResponse()
                {
                    Item = s,
                    ListDetail = listItemDetail.Where(w => s.ID == w.ID_Item).ToList(),
                    ListMeta = listItemMeta.Where(w1 => s.ID == w1.ID_Item).ToList()

                }).ToList();

                return new GetAllItemResponse()
                {
                    ListItemResponse = res,
                    Code = ResStatusCode.Success
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy dữ liệu từ 1 bảng trong database
        /// </summary>
        /// <returns></returns>
        public T GetDataFromTable<T>(Models.TableType type)
        {
            try
            {
                return systemDAO.GetDataFromTable<T>(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Thêm 1 sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public AddItemResponse AddItem(AddItemRequest req)
        {
            try
            {
                int ID = systemDAO.AddItem(req.Item);
                if (ID != -1 && ID > 0)
                {
                    bool addToDetail = AddItemToDetail(ID, req.ListDetail);
                    bool addToMeta = AddItemToMeta(ID, req.ListMeta);
                    if (addToDetail && addToMeta)
                    {
                        return new AddItemResponse()
                        {
                            Code = ResStatusCode.AddItemSuccess
                        };
                    }

                }

                return new AddItemResponse()
                {
                    Code = ResStatusCode.AddItemFail
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool AddItemToDetail(int ID, List<ItemDetail> ListDetail)
        {
            try
            {
                List<ItemDetail> Req = ListDetail.Select(s => new ItemDetail()
                {
                    ID_Item = ID,
                    NumberProduct = s.NumberProduct,
                    Size = s.Size
                }).ToList();

                return systemDAO.AddItemDetail(Req);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool AddItemToMeta(int ID, List<ItemMeta> ListMeta)
        {
            try
            {
                List<ItemMeta> Req = ListMeta.Select(s => new ItemMeta()
                {
                    ID_Item = ID,
                    MetaKey = s.MetaKey,
                    MetaValue = s.MetaValue
                }).ToList();

                return systemDAO.AddItemMeta(Req);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}