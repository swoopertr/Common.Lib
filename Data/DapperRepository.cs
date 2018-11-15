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
 public T ItemQuery(string query)
        {
            var result = new T();
            try
            {
               _connection.Open();
                result = _connection.Query<T>(query).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public List<T> ListQuery(string query)
        {
            var result = new List<T>();
            try
            {
                _connection.Open();
                result = _connection.Query<T>(query).ToList();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public int CountQuery(string query)
        {
            int result = 0;
            try
            {
                _connection.Open();
                result = _connection.Query<int>(query).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return result;
        }
    }
}
