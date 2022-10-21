using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Persistense
{
    public class UsuariosDAL : Conexao
    {
        public SqlDataReader SelecionaUsuario(Usuarios u)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT LOGIN, SENHA, NOME_USUARIO, EMAIL, ESTADO, CONTROLE_ALMOXARIFADO FROM Usuario WHERE LOGIN = @Login AND SENHA = @Senha;", con);
                cmd.Parameters.AddWithValue("@Login", u.login);
                cmd.Parameters.AddWithValue("@Senha", u.senha);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Usuário não encontrado!" + ex.Message);
            }
        }
    }
}