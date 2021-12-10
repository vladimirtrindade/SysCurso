using System.Data.SqlClient;

namespace DAO.SQLServer
{
    public class BaseDAO
    {
        private readonly string _connectionString;
        public BaseDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected SqlConnection Connection => new SqlConnection(_connectionString);
    }
}