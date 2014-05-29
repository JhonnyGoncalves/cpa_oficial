using System.Collections.Generic;
using System.Data.SqlClient;
using CPA_Project.Areas.Admin.Models;

namespace CPA_Project.Connect_DB
{
    public class AdminApp
    {
        private Contexto _contexto;

        #region Dando acesso ao administrador

        public List<Administrador> Administradores()
        {
            using (_contexto = new Contexto())
            {
                const string strQuery = "SELECT * FROM ADMINISTRADOR";
                var dadosAdmin = _contexto.ComandoDataReader(strQuery);
                return ConverterDataReaderToList(dadosAdmin);
            }
        }
        private List<Administrador> ConverterDataReaderToList(SqlDataReader reader)
        {
            var admin = new List<Administrador>();
            while (reader.Read())
            {
                var tempAdmin = new Administrador()
                {
                    Login = reader["Login"].ToString(),
                    Senha = reader["Senha"].ToString()
                };
                admin.Add(tempAdmin);
            }
            reader.Close();
            return admin;
        }
        #endregion
    }
}