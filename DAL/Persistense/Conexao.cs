using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL.Persistense
{
    public class Conexao
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        protected void AbrirConexao()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ACESSO"].ConnectionString);
                con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void FecharConexao()
        {
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}