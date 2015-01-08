using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DapperExtensions;

namespace Common.Lib.Data
{
    public class DapperRepository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public DapperRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.AppSettings["sqlConnectionString"]);
        }

        private SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public T Insert(T entity)
        {
            string adaw = "adwaww adaw";
            using (Connection)
            {
                Connection.Open();
                return Connection.Insert(entity);
            }
        }

        public bool InsertRange(T[] entities)
        {
            bool result = false;
            using (Connection)
            {
                using (var trans = Connection.BeginTransaction())
                {
                    try
                    {
                        Connection.Insert(entities);
                        trans.Commit();
                        result = true;
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public bool Update(T entity)
        {
            using (Connection)
            {
                return Connection.Update(entity);
            }
        }

        public bool Delete(T entity)
        {
            using (Connection)
            {
                return Connection.Delete(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (Connection)
            {
                return Connection.GetList<T>();
            }
        }

        public T Get(int id)
        {
            using (Connection)
            {
                return Connection.Get<T>(id);
            }
        }
        public T Get(Guid id)
        {
            using (Connection)
            {
                return Connection.Get<T>(id);
            }
        }

    }
}
