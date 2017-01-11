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
                            Gender = reader["Gender"].ToString().Trim(),
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
                            Size = reader["Size"].ToString().Trim(),
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
                    command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = req.Gender;
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
                    command.Parameters.Add("@Size", SqlDbType.NVarChar);
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
                    cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = req.Gender;
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
                            Size = reader["Size"].ToString().Trim(),
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
                    Gender = reader["Gender"].ToString().Trim(),
                    Price = (decimal)reader["Price"],
                };
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm data vào bảng Account
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsertTblAccount(AddAccountREQUEST req)
        {
            int id = -1;
            string query = "insert into dbo.Account Output Inserted.ID values (@Email, @CreatedDate, @Status, @Type, @FullName, @Address, @Phone, @Token, @ID_Cart)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = req.Email;
                    command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = req.Status;
                    command.Parameters.Add("@Type", SqlDbType.NVarChar).Value = req.Type;
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = req.FullName;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = req.Address;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = req.Phone;
                    command.Parameters.Add("@Token", SqlDbType.NVarChar).Value = req.Token;
                    command.Parameters.Add("@ID_Cart", SqlDbType.Int).Value = -1; // cập nhật sau

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
        /// Thêm data vào bảng Cart
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsertTblCart(Cart cart)
        {
            int id = -1;
            string query = "insert into dbo.Cart Output Inserted.ID values (@ID_Customer, @Status, @CreatedDate)";
            string queryUpdate = "UPDATE Account SET ID_Cart = @id_cart WHERE ID = @id";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@ID_Customer", SqlDbType.Int).Value = cart.ID_Customer;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = cart.Status;
                    command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;

                    id = (int)command.ExecuteScalar();
                    // Update ID cart bên Account
                    if (id > 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(queryUpdate, connect))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = cart.ID_Customer;
                            cmd.Parameters.Add("@id_cart", SqlDbType.Int).Value = id;
                            cmd.ExecuteScalar();
                        }
                    }
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
        /// Lấy account theo iD
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetAccountByID<T>(int ID)
        {
            SqlDataReader reader = null;
            Account acc = null;
            object result = null;
            string query = "select* from dbo.Account where ID = @id";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        acc = new Account()
                        {
                            Address = reader["Address"].ToString().Trim(),
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Email = reader["Email"].ToString().Trim(),
                            FullName = reader["FullName"].ToString().Trim(),
                            ID = (int)reader["ID"],
                            ID_Cart = (int)reader["ID_Cart"],
                            Phone = reader["Phone"].ToString().Trim(),
                            Status = reader["Status"].ToString().Trim(),
                            Token = reader["Token"].ToString().Trim(),
                            Type = reader["Type"].ToString().Trim()
                        };
                    }
                }

                result = acc;
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
        /// Lấy account theo Token vs Status
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetAccountByToken<T>(GetAccountREQUEST req)
        {
            SqlDataReader reader = null;
            Account acc = null;
            object result = null;
            string query = "select* from dbo.Account where Token = @token and Status = @status";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@token", SqlDbType.NVarChar).Value = req.Token;
                    cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = req.Status;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        acc = new Account()
                        {
                            Address = reader["Address"].ToString().Trim(),
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Email = reader["Email"].ToString().Trim(),
                            FullName = reader["FullName"].ToString().Trim(),
                            ID = (int)reader["ID"],
                            ID_Cart = (int)reader["ID_Cart"],
                            Phone = reader["Phone"].ToString().Trim(),
                            Status = reader["Status"].ToString().Trim(),
                            Token = reader["Token"].ToString().Trim(),
                            Type = reader["Type"].ToString().Trim()
                        };
                    }
                }

                result = acc;
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
        /// Cập nhật dữ liệu bảng Account
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T UpdateTblAccount<T>(UpdateAccountREQUEST req, int id)
        {
            int result = -1;
            SqlDataReader reader = null;
            object res = null;
            string query = "UPDATE Account SET Email = @email, Status = @status, Type = @type, FullName = @fullname, Address = @address, Phone = @phone WHERE ID = @id";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = req.Email;
                    command.Parameters.Add("@status", SqlDbType.NVarChar).Value = req.Status;
                    command.Parameters.Add("@type", SqlDbType.NVarChar).Value = req.Type;
                    command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = req.FullName;
                    command.Parameters.Add("@address", SqlDbType.NVarChar).Value = req.Address;
                    command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = req.Phone;

                    result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        string getQuery = string.Format("Select * from Account where ID = {0}", id);
                        using (SqlCommand cmd = new SqlCommand(getQuery, connect))
                        {
                            reader = cmd.ExecuteReader();
                            Account acc = null;
                            while (reader.Read())
                            {
                                acc = new Account()
                                {
                                    Address = reader["Address"].ToString().Trim(),
                                    CreatedDate = (DateTime)reader["CreatedDate"],
                                    ID_Cart = (int)reader["ID_Cart"],
                                    Email = reader["Email"].ToString().Trim(),
                                    FullName = reader["FullName"].ToString().Trim(),
                                    ID = (int)reader["ID"],
                                    Phone = reader["Phone"].ToString().Trim(),
                                    Status = reader["Status"].ToString().Trim(),
                                    Token = reader["Token"].ToString().Trim(),
                                    Type = reader["Type"].ToString().Trim(),
                                };
                            }
                            res = acc;
                        }
                    }
                }

                return (T)res;
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
        /// Lây dư lieu cart
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetAllCart<T>()
        {
            SqlDataReader reader = null;
            Cart cart = null;
            object result = null;
            string query = "select* from Cart";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cart = new Cart()
                        {
                            ID = (int)reader["ID"],
                            ID_Customer = (int)reader["ID_Customer"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Status = reader["Status"].ToString().Trim()
                        };
                    }
                }
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
        /// Lay cart detail
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCartDetail<T>()
        {
            SqlDataReader reader = null;
            List<CartDetail> list = new List<CartDetail>();
            object result = null;
            string query = "select* from CartDetail";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new CartDetail()
                        {
                            ID = (int)reader["ID"],
                            ID_Cart = (int)reader["ID_Cart"],
                            ID_Item = (int)reader["ID_Item"],
                            NumberProduct = (int)reader["ProductNumber"],
                            Price = (decimal)reader["Price"]
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
        /// Lay Cart theo ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetCartByCartID<T>(int ID)
        {
            SqlDataReader reader = null;
            object result = null;
            Cart newCart = null;
            string query = "select* from dbo.Cart where ID = @id";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        newCart = new Cart()
                        {
                            ID = (int)reader["ID"],
                            ID_Customer = (int)reader["ID_Customer"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Status = reader["Status"].ToString().Trim(),
                        };

                        result = newCart;
                    }
                }

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
        /// Lay CartDetail theo ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetCartDetailByCartID<T>(int ID)
        {
            SqlDataReader reader = null;
            List<CartDetail> list = new List<CartDetail>();
            object result = null;
            string query = "select* from dbo.CartDetail where ID_Cart = @id_cart";

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
                            ID_Item = (int)reader["ID_Item"],
                            NumberProduct = (int)reader["NumberProduct"],
                            Price = (decimal)reader["Price"],
                            Size = reader["Size"].ToString().Trim()
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
        /// Lay GetItemByID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetItemByID<T>(int ID)
        {
            SqlDataReader reader = null;
            Item item = null;
            object result = null;
            string query = "select* from dbo.Item where ID = @id";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        item = new Item()
                        {
                            Brand = reader["Brand"].ToString().Trim(),
                            Category = reader["Category"].ToString().Trim(),
                            Color = reader["Color"].ToString().Trim(),
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            ID = (int)reader["ID"],
                            ProductName = reader["ProductName"].ToString().Trim(),
                            Status = reader["Status"].ToString().Trim(),
                            Type = reader["Type"].ToString().Trim(),
                            Gender = reader["Gender"].ToString().Trim(),
                            Price = (decimal)reader["Price"],
                        };
                    }
                }

                result = item;
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
        /// Cập nhật bảng Cart
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T UpdateTblCart<T>(UpdateCartReq req, int id)
        {
            int result = -1;
            object res = null;
            SqlDataReader reader = null;
            string query = "UPDATE Cart SET ID_Customer = @idCustomer, Status = @status, CreatedDate = @date WHERE ID = @id";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.Parameters.Add("@idCustomer", SqlDbType.Int).Value = req.ID_Customer;
                    command.Parameters.Add("@status", SqlDbType.NVarChar).Value = req.Status;
                    command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;

                    result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        string getQuery = string.Format("Select * from Cart where ID = {0}", id);
                        using (SqlCommand cmd = new SqlCommand(getQuery, connect))
                        {
                            reader = cmd.ExecuteReader();
                            Cart cart = null;
                            while (reader.Read())
                            {
                                cart = new Cart()
                                {
                                    CreatedDate = (DateTime)reader["CreatedDate"],
                                    ID_Customer = (int)reader["ID_Customer"],
                                    Status = reader["Status"].ToString().Trim(),
                                    ID = (int)reader["ID"],
                                };
                            }
                            res = cart;
                        }
                    }
                }

                return (T)res;
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
        /// Cập nhật bảng CartDetail
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T UpdateTblCartDetail<T>(CartDetail req, int id)
        {
            int result = -1;
            object res = null;
            SqlDataReader reader = null;
            string query = "UPDATE CartDetail SET ID_Cart = @idCart, ID_Item = @idItem, NumberProduct = @num, Price = @price, Size = @size WHERE ID = @id";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.Parameters.Add("@idCart", SqlDbType.Int).Value = req.ID_Cart;
                    command.Parameters.Add("@idItem", SqlDbType.Int).Value = req.ID_Item;
                    command.Parameters.Add("@num", SqlDbType.Int).Value = req.NumberProduct;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = req.Price;
                    command.Parameters.Add("@size", SqlDbType.NVarChar).Value = req.Size;

                    result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        string getQuery = string.Format("Select * from CartDetail where ID = {0}", id);
                        using (SqlCommand cmd = new SqlCommand(getQuery, connect))
                        {
                            reader = cmd.ExecuteReader();
                            CartDetail cartDetail = null;
                            while (reader.Read())
                            {
                                cartDetail = new CartDetail()
                                {
                                    ID_Cart = (int)reader["ID_Cart"],
                                    ID_Item = (int)reader["ID_Item"],
                                    NumberProduct = (int)reader["NumberProduct"],
                                    Price = (decimal)reader["Price"],
                                    ID = (int)reader["ID"],
                                    Size = reader["Size"].ToString().Trim()
                                };
                            }
                            res = cartDetail;
                        }
                    }
                }

                return (T)res;
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
        /// Thêm cart detail
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsertTblCartDetail(CartDetail req)
        {
            int id = -1;
            string query = "insert into dbo.CartDetail Output Inserted.ID values (@ID_Cart, @ID_Item, @NumberProduct, @Price, @Size)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@ID_Cart", SqlDbType.Int).Value = req.ID_Cart;
                    command.Parameters.Add("@ID_Item", SqlDbType.Int).Value = req.ID_Item;
                    command.Parameters.Add("@NumberProduct", SqlDbType.Int).Value = req.NumberProduct;
                    command.Parameters.Add("@Price", SqlDbType.Decimal).Value = req.Price;
                    command.Parameters.Add("@Size", SqlDbType.NVarChar).Value = req.Size;

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
        /// Xóa cart detail bằng id của cart detail
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int DeleteCartDetailByIDCart(int ID)
        {
            int id = -1;
            string query = "DELETE FROM CartDetail WHERE ID_Cart = @id ";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    id = (int)command.ExecuteNonQuery();
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
        /// Xóa cart detail bằng id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int DeleteCartDetailByID(int ID)
        {
            int id = -1;
            string query = "DELETE FROM CartDetail WHERE ID = @id ";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    id = (int)command.ExecuteNonQuery();
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
        /// Thêm vào bảng Order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T InsertTblOrder<T>(Orders req)
        {
            int result = -1;
            object res = null;
            Orders orders = null;
            string query = "insert into Orders Output Inserted.ID values (@ID_Customer, @CustomerName, @Address, @Phone, @Status, @CreatedDate, @EndDate, @Discount, @Note, @TotalPrice)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {

                    command.Parameters.Add("@ID_Customer", SqlDbType.Int).Value = req.ID_Customer;
                    command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = req.CustomerName;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = req.Address;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = req.Phone;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = req.Status;
                    command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DateTime.Now.AddDays(10);
                    command.Parameters.Add("@Discount", SqlDbType.Int).Value = req.Discount;
                    command.Parameters.Add("@Note", SqlDbType.NVarChar).Value = req.Note;
                    command.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = req.TotalPrice;

                    result = (int)command.ExecuteScalar();
                    if (result > 0)
                    {
                        orders = new Orders()
                        {
                            Address = req.Address,
                            CreatedDate = req.CreatedDate,
                            CustomerName = req.CustomerName,
                            Discount = req.Discount,
                            EndDate = req.EndDate,
                            ID = result,
                            ID_Customer = req.ID_Customer,
                            Note = req.Note,
                            Phone = req.Phone,
                            Status = req.Status,
                            TotalPrice = req.TotalPrice
                        };
                        res = orders;
                    }
                }

                return (T)res;
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
        public T InsertTblOrderDetail<T>(List<OrderDetail> req)
        {
            int result = -1;
            List<OrderDetail> ListDetail = new List<OrderDetail>();
            object res = null;
            string query = "insert into dbo.OrdersDetail Output Inserted.ID values (@ID_Order, @ID_Item, @NumberProduct, @Price, @Size)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@ID_Order", SqlDbType.Int);
                    command.Parameters.Add("@ID_Item", SqlDbType.Int);
                    command.Parameters.Add("@NumberProduct", SqlDbType.Int);
                    command.Parameters.Add("@Price", SqlDbType.Decimal);
                    command.Parameters.Add("@Size", SqlDbType.NVarChar);

                    foreach (var item in req)
                    {
                        command.Parameters["@ID_Order"].Value = item.ID_Order;
                        command.Parameters["@ID_Item"].Value = item.ID_Item;
                        command.Parameters["@NumberProduct"].Value = item.NumberProduct;
                        command.Parameters["@Price"].Value = item.Price;
                        command.Parameters["@Size"].Value = item.Size;

                        result = (int)command.ExecuteScalar();
                        if (result > 0)
                        {
                            ListDetail.Add(new OrderDetail()
                            {
                                ID = result,
                                ID_Item = item.ID_Item,
                                ID_Order = item.ID_Order,
                                NumberProduct = item.NumberProduct,
                                Price = item.Price
                            });
                        }
                    }
                }

                res = ListDetail.ToList();
                return (T)res;
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
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetItemDetailByItemID<T>(int ID, string size)
        {
            SqlDataReader reader = null;
            ItemDetail item = null;
            object result = null;
            string query = "select* from dbo.ItemDetail where ID_Item = @id_item and Size = @size";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id_item", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@size", SqlDbType.NVarChar).Value = size;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        item = new ItemDetail()
                        {
                            ID = (int)reader["ID"],
                            ID_Item = (int)reader["ID_Item"],
                            NumberProduct = (int)reader["NumberProduct"],
                            Size = reader["Size"].ToString().Trim(),
                        };
                    }
                }

                result = item;
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
        /// Lấy Order by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetOrderByID<T>(int ID)
        {
            SqlDataReader reader = null;
            Orders order = null;
            object result = null;
            string query = "select* from dbo.Orders where ID = @id";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        order = new Orders()
                        {
                            Address = reader["Address"].ToString().Trim(),
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            CustomerName = reader["CustomerName"].ToString().Trim(),
                            Discount = (int)reader["Discount"],
                            EndDate = (DateTime)reader["EndDate"],
                            ID = (int)reader["ID"],
                            ID_Customer = (int)reader["ID_Customer"],
                            Note = reader["Note"].ToString().Trim(),
                            Phone = reader["Phone"].ToString().Trim(),
                            Status = reader["Status"].ToString().Trim(),
                            TotalPrice = (decimal)reader["TotalPrice"]
                        };
                    }
                }

                result = order;
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
        /// Lay CartDetail theo ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetOrderDetail<T>(int ID)
        {
            SqlDataReader reader = null;
            List<OrderDetail> list = new List<OrderDetail>();
            object result = null;
            string query = "select* from dbo.OrdersDetail where ID_Order = @id";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new OrderDetail()
                        {
                            ID = (int)reader["ID"],
                            ID_Order = (int)reader["ID_Order"],
                            ID_Item = (int)reader["ID_Item"],
                            NumberProduct = (int)reader["NumberProduct"],
                            Price = (decimal)reader["Price"],
                            Size = reader["Size"].ToString().Trim()
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
        /// Cập nhật dữ liệu bảng Order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int UpdateTblOrder(UpdateOrderREQUEST req, int id)
        {
            int result = -1;
            string query = "UPDATE Orders SET Status = @status, EndDate = @enddate, Discount = @discount, TotalPrice = @total WHERE ID = @id";
            string getQuery = string.Format("select* from Orders where ID = {0}", id);
            int oldDiscount = 0, curDiscount = 0;
            decimal oldTotalPrice = 0, newTotalPrice = 0;
            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(getQuery, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        oldDiscount = (int)reader["Discount"];
                        oldTotalPrice = (decimal)reader["TotalPrice"];
                    }

                    curDiscount = req.Discount - oldDiscount;
                    newTotalPrice = oldTotalPrice - curDiscount;
                    reader.Close();
                }

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.Parameters.Add("@status", SqlDbType.NVarChar).Value = req.Status;
                    command.Parameters.Add("@enddate", SqlDbType.DateTime).Value = req.EndDate;
                    command.Parameters.Add("@discount", SqlDbType.Int).Value = req.Discount;
                    command.Parameters.Add("@total", SqlDbType.Decimal).Value = newTotalPrice;

                    result = command.ExecuteNonQuery();
                }

                return result;
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
        /// Lấy tất ca Orders
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetAllOrder<T>()
        {
            SqlDataReader reader = null;
            List<Orders> list = new List<Orders>();
            object result = null;
            string query = "select* from Orders";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //string Address = reader["Address"].ToString().Trim();
                        //string CustomerName = reader["CustomerName"].ToString().Trim();
                        //int Discount = (int)reader["Discount"];
                        //DateTime EndDate = (DateTime)reader["EndDate"];
                        //int ID_Customer = (int)reader["ID_Customer"];
                        //DateTime CreatedDate = (DateTime)reader["CreatedDate"];
                        //int ID = (int)reader["ID"];
                        //string Note = reader["Note"].ToString().Trim();
                        //string Phone = reader["Phone"].ToString().Trim();
                        //decimal TotalPrice = (decimal)reader["TotalPrice"];
                        //string Status = reader["Status"].ToString().Trim();

                        list.Add(new Orders()
                        {
                            Address = reader["Address"].ToString().Trim(),
                            CustomerName = reader["CustomerName"].ToString().Trim(),
                            Discount = (int)reader["Discount"],
                            EndDate = (DateTime)reader["EndDate"],
                            ID_Customer = (int)reader["ID_Customer"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            ID = (int)reader["ID"],
                            Note = reader["Note"].ToString().Trim(),
                            Phone = reader["Phone"].ToString().Trim(),
                            TotalPrice = (decimal)reader["TotalPrice"],
                            Status = reader["Status"].ToString().Trim(),
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
        /// Cập nhật dữ liệu bảng Order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int UpdateItemDetailNumberProduct(List<ItemDetail> req)
        {
            int result = -1;
            string query = "UPDATE ItemDetail SET NumberProduct = @num WHERE ID = @id";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters.Add("@num", SqlDbType.Int);

                    foreach (var item in req)
                    {
                        command.Parameters["@id"].Value = item.ID;
                        command.Parameters["@num"].Value = item.NumberProduct;

                        result = command.ExecuteNonQuery();
                    }
                }

                return result;
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
    }
}