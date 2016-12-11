using ShoeShop.Lib;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShoeShop.DAO
{
    public class DataAccess
    {
        static DataAccess instance;
        readonly static object lockobj = new object();
        public static DataAccess getInstance()
        {
            if (instance == null)
            {
                lock (lockobj)
                {
                    if (instance == null)
                    {
                        instance = new DataAccess();
                    }
                }
            }
            return instance;
        }

        private DataAccess()
        {
            Init();
        }

        public void Init()
        {
            try
            {
                SetListType();
                SetListColor();
            }
            catch
            {
                throw;
            }
        }

        private static List<string> listType = new List<string>();
        private static List<string> listColor = new List<string>();

        private void SetListType()
        {
            try
            {
                if (listType == null || listType.Count == 0)
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ItemType.json");
                    var data = File.ReadAllText(filePath);
                    listType = string.IsNullOrEmpty(data) ? null : data.FromJson<List<string>>(true);
                }
            }
            catch
            {
                throw;
            }
        }

        private void SetListColor()
        {
            try
            {
                if (listColor == null || listColor.Count == 0)
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ItemColor.json");
                    var data = File.ReadAllText(filePath);
                    listColor = string.IsNullOrEmpty(data) ? null : data.FromJson<List<string>>(true);
                }
            }
            catch
            {
                throw;
            }
        }

        public T getListCacheData<T>(CacheDataType type)
        {
            try
            {
                object result = null;
                switch (type)
                {
                    case CacheDataType.TypeOfItem:
                        {
                            result = listType.ToList();
                            break;
                        }
                    case CacheDataType.ColorOfItem:
                        {
                            result = listColor.ToList();
                            break;
                        }
                    default:
                        throw new Exception(string.Format("Không tìm thấy CacheDataReferencesType[{0}] trong DataAccess.getCacheData.", type));
                }
                return (T)result;
            }
            catch
            {
                throw;
            }
        }

    }
}