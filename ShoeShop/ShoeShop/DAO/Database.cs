using ShoeShop.Lib;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class Database
    {
        private static Database instance { set; get; }

        private static object lockObj = new object();

        private SqlConnection connect { set; get; }
        private Database()
        {
            Init();
        }

        /// <summary>
        /// Create SqlConnection and get ConnectionString
        /// </summary>
        private void Init()
        {
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = ConfigurationManager.ConnectionStrings["sqlString"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sigleton
        /// </summary>
        /// <returns></returns>
        public static Database GetInstance()
        {
            try
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new Database();
                        }
                    }
                }

                return instance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Call Sql Connection Open
        /// </summary>
        public void SqlConnectionOpen()
        {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Call Sql Connection Close
        /// </summary>
        public void SqlConnectionClose()
        {
            try
            {
                connect.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả sản phầm trong cửa hàng
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetAllItem<T>()
        {
            SqlDataReader reader = null;
            List<Item> list = new List<Item>();
            object result = null;
            string query = "select* from Item";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Item()
                        {
                            Brand = reader["Brand"].ToString().Trim(),
                            Category = reader["Category"].ToString().Trim(),
                            Color = reader["Color"].ToString().Trim(),
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            ID = (int)reader["ID"],
                            ProductName = reader["ProductName"].ToString().Trim(),
                            Status = reader["Status"].ToString().Trim(),
                            Type = reader["Type"].ToString().Trim(),
                            Gender = (Sex)Int16.Parse(reader["Gender"].ToString()),
                            Price = (decimal)reader["Price"],
                        });
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy tất cả data trong bảng ItemDetail
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetAllItemDetail<T>()
        {
            SqlDataReader reader = null;
            List<ItemDetail> list = new List<ItemDetail>();
            object result = null;
            string query = "select* from ItemDetail";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ItemDetail()
                        {
                            ID = (int)reader["ID"],
                            ID_Item = (int)reader["ID_Item"],
                            NumberProduct = (int)reader["NumberProduct"],
                            Size = (int)reader["Size"],
                        });
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy tất cả data trong bảng ItemMeta
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetAllItemMeta<T>()
        {
            SqlDataReader reader = null;
            List<ItemMeta> list = new List<ItemMeta>();
            object result = null;
            string query = "select* from ItemMeta";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ItemMeta()
                        {
                            ID = (int)reader["ID"],
                            ID_Item = (int)reader["ID_Item"],
                            MetaKey = reader["MetaKey"].ToString().Trim(),
                            MetaValue = reader["MetaValue"].ToString().Trim(),
                        });
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Thêm data vào bảng Item
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsertTblItem(Item req)
        {
            int id = -1;
            string query = "insert into dbo.Item Output Inserted.ID values (@ProductName, @Brand, @Color, @Gender, @Status, @Type, @CreatedDate, @Category, @Price)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    //command.Parameters.AddWithValue("@ID", (int)req.ID);
                    command.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = req.ProductName;
                    command.Parameters.Add("@Brand", SqlDbType.NVarChar).Value = req.Brand;
                    command.Parameters.Add("@Color", SqlDbType.NVarChar).Value = req.Color;
                    command.Parameters.Add("@Gender", SqlDbType.Int).Value = (int)req.Gender;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = req.Status;
                    command.Parameters.Add("@Type", SqlDbType.NVarChar).Value = req.Type;
                    command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@Category", SqlDbType.NVarChar).Value = req.Category;
                    command.Parameters.Add("@Price", SqlDbType.Decimal).Value = req.Price;

                    id = (int)command.ExecuteScalar();
                }

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Thêm data vào bảng ItemDetail
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool InsertTblItemDetail(List<ItemDetail> req)
        {
            int result = -1;
            string query = "insert into dbo.ItemDetail values (@ID_Item, @Size, @NumberProduct)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@ID_Item", SqlDbType.Int);
                    command.Parameters.Add("@Size", SqlDbType.Int);
                    command.Parameters.Add("@NumberProduct", SqlDbType.Int);

                    foreach (var item in req)
                    {
                        command.Parameters["@ID_Item"].Value = item.ID_Item;
                        command.Parameters["@Size"].Value = item.Size;
                        command.Parameters["@NumberProduct"].Value = item.NumberProduct;

                        result = command.ExecuteNonQuery();
                    }
                }

                return result <= 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Thêm data vào bảng ItemMeta
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool InsertTblItemMeta(List<ItemMeta> req)
        {
            int result = -1;
            string query = "insert into dbo.ItemMeta values (@ID_Item, @MetaKey, @MetaValue)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@ID_Item", SqlDbType.Int);
                    command.Parameters.Add("@MetaKey", SqlDbType.NVarChar);
                    command.Parameters.Add("@MetaValue", SqlDbType.NVarChar);

                    foreach (var item in req)
                    {
                        command.Parameters["@ID_Item"].Value = item.ID_Item;
                        command.Parameters["@MetaKey"].Value = item.MetaKey;
                        command.Parameters["@MetaValue"].Value = item.MetaValue;

                        result = command.ExecuteNonQuery();
                    }
                }

                return result <= 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo giởi tính và loại
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetItemByGenderType<T>(GetItemByGenderTypeRequest req)
        {
            SqlDataReader reader = null;
            List<Item> list = new List<Item>();
            object result = null;
            string query = "select* from dbo.Item where Gender = @gender AND Type = @type";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@gender", SqlDbType.Int).Value = (int)req.Gender;
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = req.Type;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //list.Add(new Item()
                        //{
                        //    Brand = reader["Brand"].ToString().Trim(),
                        //    Category = reader["Category"].ToString().Trim(),
                        //    Color = reader["Color"].ToString().Trim(),
                        //    CreatedDate = (DateTime)reader["CreatedDate"],
                        //    ID = (int)reader["ID"],
                        //    ProductName = reader["ProductName"].ToString().Trim(),
                        //    Status = reader["Status"].ToString().Trim(),
                        //    Type = reader["Type"].ToString().Trim(),
                        //    Gender = (Sex)Int16.Parse(reader["Gender"].ToString()),
                        //    Price = (decimal)reader["Price"],
                        //});
                        list.Add(GetItemFromReader(reader));
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo giởi tính và loại
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetItemDetailByItemID<T>(int ID)
        {
            SqlDataReader reader = null;
            List<ItemDetail> list = new List<ItemDetail>();
            object result = null;
            string query = "select* from dbo.ItemDetail where ID_Item = @id_item";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id_item", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ItemDetail()
                        {
                            ID = (int)reader["ID"],
                            ID_Item = (int)reader["ID_Item"],
                            NumberProduct = (int)reader["NumberProduct"],
                            Size = (int)reader["Size"],
                        });
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo giởi tính và loại
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetItemMetaByItemID<T>(int ID)
        {
            SqlDataReader reader = null;
            List<ItemMeta> list = new List<ItemMeta>();
            object result = null;
            string query = "select* from dbo.ItemMeta where ID_Item = @id_item";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id_item", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ItemMeta()
                        {
                            ID = (int)reader["ID"],
                            ID_Item = (int)reader["ID_Item"],
                            MetaKey = reader["MetaKey"].ToString().Trim(),
                            MetaValue = reader["MetaValue"].ToString().Trim(),
                        });
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }


        /// <summary>
        /// Tìm kiếm sản phẩm theo gía tiền
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetItemByPrice<T>(GetItemByPriceRequest req)
        {
            SqlDataReader reader = null;
            List<Item> list = new List<Item>();
            object result = null;
            string query = "select* from dbo.Item where Price >= @min AND Price <= @max";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@min", SqlDbType.Decimal).Value = req.MinPrice;
                    cmd.Parameters.Add("@max", SqlDbType.Decimal).Value = req.MaxPrice;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //list.Add(new Item()
                        //{
                        //    Brand = reader["Brand"].ToString().Trim(),
                        //    Category = reader["Category"].ToString().Trim(),
                        //    Color = reader["Color"].ToString().Trim(),
                        //    CreatedDate = (DateTime)reader["CreatedDate"],
                        //    ID = (int)reader["ID"],
                        //    ProductName = reader["ProductName"].ToString().Trim(),
                        //    Status = reader["Status"].ToString().Trim(),
                        //    Type = reader["Type"].ToString().Trim(),
                        //    Gender = (Sex)Int16.Parse(reader["Gender"].ToString()),
                        //    Price = (decimal)reader["Price"],
                        //});
                        list.Add(GetItemFromReader(reader));
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo loại
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetItemByType<T>(string type)
        {
            SqlDataReader reader = null;
            List<Item> list = new List<Item>();
            object result = null;
            string query = "select* from dbo.Item where Type = @type";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(GetItemFromReader(reader));
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo màu sắc
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetItemByColor<T>(string color)
        {
            SqlDataReader reader = null;
            List<Item> list = new List<Item>();
            object result = null;
            string query = "select* from dbo.Item where Color = @color";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@color", SqlDbType.NVarChar).Value = color;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(GetItemFromReader(reader));
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        private Item GetItemFromReader(SqlDataReader reader)
        {
            try
            {
                return new Item()
                {
                    Brand = reader["Brand"].ToString().Trim(),
                    Category = reader["Category"].ToString().Trim(),
                    Color = reader["Color"].ToString().Trim(),
                    CreatedDate = (DateTime)reader["CreatedDate"],
                    ID = (int)reader["ID"],
                    ProductName = reader["ProductName"].ToString().Trim(),
                    Status = reader["Status"].ToString().Trim(),
                    Type = reader["Type"].ToString().Trim(),
                    //Gender = (Sex)Int16.Parse(reader["Gender"].ToString()),
                    Gender = (Sex)Enum.Parse(typeof(Sex), reader["Gender"].ToString()),
                    Price = (decimal)reader["Price"],
                };
            }
            catch
            {
                throw;
            }
        }

        public T GetCartByCartID<T>(int ID)
        {
            SqlDataReader reader = null;
            List<CartDetail> list = new List<CartDetail>();
            object result = null;
            string query = "select* from dbo.Cart where ID_Cart = @id_cart";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id_cart", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new CartDetail()
                        {
                            ID = (int)reader["ID"],
                            ID_Cart = (int)reader["ID_Cart"],
                            ProductNumber = (int)reader["ProductNumber"],
                            Price = (int)reader["Price"],
                        });
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
    }
}