using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPA_Project.Connect_DB
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection _connection;
        public Contexto()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BancoCPA"].ConnectionString);
            _connection.Open();
        }

        public void ComandoNonQuery(string strQuery)
        {
            var cmd = new SqlCommand(strQuery, _connection);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ComandoDataReader(string strQuery)
        {
            var cmd = new SqlCommand(strQuery, _connection);
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if (_connection.State.Equals(ConnectionState.Open))
                _connection.Close();
        }
    }
}
