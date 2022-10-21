using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Persistense
{
    public class TimeDAL : Conexao
    {
        public void GravarRecebedor(Time t)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_RECEBEDOR(RECEBEDOR, CARGO, ESTADO) values (@Nome, @Cargo, @Estado );", con);
                cmd.Parameters.AddWithValue("@Nome", t.Recebedor);
                cmd.Parameters.AddWithValue("@Cargo", t.Cargo);
                cmd.Parameters.AddWithValue("@Estado", t.UF);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar recebedor!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}