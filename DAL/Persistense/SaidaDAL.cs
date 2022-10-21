using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Persistense
{
    public class SaidaDAL : Conexao
    {
        #region "MINAS GERAIS"
        public void GravarMG(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_SAIDAMG(FK_ENTRADA, ID_PRODUTO, QTDS, DATASAIDA, USUARIO, NUMPEDIDO, LIBERADOR, RECEBEDOR, AUTORIZADO, STATUS_PEDIDO) values (@IDEntrada, @IDProduto, @QtdS, @Data, @User, @Pedido, @Liberador, @Recebedor, @Autorizado, @Status);", con);
                cmd.Parameters.AddWithValue("@IDEntrada", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@IDProduto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdS", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);
                cmd.Parameters.AddWithValue("@Pedido", s.NumPedido);
                cmd.Parameters.AddWithValue("@Liberador", s.Liberador);
                cmd.Parameters.AddWithValue("@Recebedor", s.Recebedor);
                cmd.Parameters.AddWithValue("@Autorizado", s.Autorizado);
                cmd.Parameters.AddWithValue("@Status", s.StatusPedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarMG(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_SAIDAMG SET PK_SAIDA=@PK, FK_ENTRADA=@FK, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;", con);
                cmd.Parameters.AddWithValue("@PK", s.Cod_Saida);
                cmd.Parameters.AddWithValue("@FK", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@Produto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdE", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExcluirMG(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("DELETE FROM TB_SAIDAMG WHERE PK_=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //public Saida PesquisarporPedido(string Pedido)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_SAIDAMG WHERE NUMPEDIDO=@PEDIDO;", con);
        //        cmd.Parameters.AddWithValue("@Pedido", Pedido);

        //        Produto p = null;

        //        if (dr.Read())
        //        {
        //            p = new Produto();

        //            p.Cod_Produto = Convert.ToInt32(dr["Codigo"]);
        //            p.Status = Convert.ToString(dr["Status"]);
        //            p.Descricao = Convert.ToString(dr["Descricao"]);
        //            p.Modelo = Convert.ToString(dr["Modelo"]);
        //            p.Marca = Convert.ToString(dr["Marca"]);
        //            p.Tipo = Convert.ToString(dr["Tipo"]);
        //        }

        //        return p;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("" + ex.Message);
        //    }
        //    finally
        //    {
        //        FecharConexao();
        //    }
        //}

        public SqlDataReader SelectSaidaMG(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_SAIDAMG WHERE NUMPEDIDO=@Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("´Dados de saída não localizados!" + ex.Message);
            }
        }

        public SqlDataReader reportMG(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_SAIDA, P.Codigo, P.Descricao, P.Modelo, P.Marca, E.QTDS FROM TB_SAIDAMG AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.NUMPEDIDO = @Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }
        #endregion

        #region "MARANHÃO"
        public void GravarMA(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_SAIDAMA(FK_ENTRADA, ID_PRODUTO, QTDS, DATASAIDA, USUARIO, NUMPEDIDO, LIBERADOR, RECEBEDOR, AUTORIZADO, STATUS_PEDIDO) values (@IDEntrada, @IDProduto, @QtdS, @Data, @User, @Pedido, @Liberador, @Recebedor, @Autorizado, @Status);", con);
                cmd.Parameters.AddWithValue("@IDEntrada", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@IDProduto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdS", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);
                cmd.Parameters.AddWithValue("@Pedido", s.NumPedido);
                cmd.Parameters.AddWithValue("@Liberador", s.Liberador);
                cmd.Parameters.AddWithValue("@Recebedor", s.Recebedor);
                cmd.Parameters.AddWithValue("@Autorizado", s.Autorizado);
                cmd.Parameters.AddWithValue("@Status", s.StatusPedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarMA(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_SAIDAMA SET PK_SAIDA=@PK, FK_ENTRADA=@FK, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;", con);
                cmd.Parameters.AddWithValue("@PK", s.Cod_Saida);
                cmd.Parameters.AddWithValue("@FK", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@Produto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdE", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExcluirMA(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("DELETE FROM TB_SAIDAMA WHERE PK_=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //public Saida PesquisarporPedido(string Pedido)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_SAIDAMG WHERE NUMPEDIDO=@PEDIDO;", con);
        //        cmd.Parameters.AddWithValue("@Pedido", Pedido);

        //        Produto p = null;

        //        if (dr.Read())
        //        {
        //            p = new Produto();

        //            p.Cod_Produto = Convert.ToInt32(dr["Codigo"]);
        //            p.Status = Convert.ToString(dr["Status"]);
        //            p.Descricao = Convert.ToString(dr["Descricao"]);
        //            p.Modelo = Convert.ToString(dr["Modelo"]);
        //            p.Marca = Convert.ToString(dr["Marca"]);
        //            p.Tipo = Convert.ToString(dr["Tipo"]);
        //        }

        //        return p;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("" + ex.Message);
        //    }
        //    finally
        //    {
        //        FecharConexao();
        //    }
        //}

        public SqlDataReader SelectSaidaMA(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_SAIDAMA WHERE NUMPEDIDO=@Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("´Dados de saída não localizados!" + ex.Message);
            }
        }

        public SqlDataReader reportMA(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_SAIDA, P.Codigo, P.Descricao, P.Modelo, P.Marca, E.QTDS, E.LIBERADOR FROM TB_SAIDAMA AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.NUMPEDIDO = @Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        #endregion

        #region "ESPIRITO SANTO"
        public void GravarES(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_SAIDAES(FK_ENTRADA, ID_PRODUTO, QTDS, DATASAIDA, USUARIO, NUMPEDIDO, LIBERADOR, RECEBEDOR, AUTORIZADO, STATUS_PEDIDO) values (@IDEntrada, @IDProduto, @QtdS, @Data, @User, @Pedido, @Liberador, @Recebedor, @Autorizado, @Status);", con);
                cmd.Parameters.AddWithValue("@IDEntrada", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@IDProduto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdS", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);
                cmd.Parameters.AddWithValue("@Pedido", s.NumPedido);
                cmd.Parameters.AddWithValue("@Liberador", s.Liberador);
                cmd.Parameters.AddWithValue("@Recebedor", s.Recebedor);
                cmd.Parameters.AddWithValue("@Autorizado", s.Autorizado);
                cmd.Parameters.AddWithValue("@Status", s.StatusPedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarES(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_SAIDAES SET PK_SAIDA=@PK, FK_ENTRADA=@FK, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;", con);
                cmd.Parameters.AddWithValue("@PK", s.Cod_Saida);
                cmd.Parameters.AddWithValue("@FK", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@Produto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdE", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExcluirES(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("DELETE FROM TB_SAIDAES WHERE PK_=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //public Saida PesquisarporPedido(string Pedido)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_SAIDAMG WHERE NUMPEDIDO=@PEDIDO;", con);
        //        cmd.Parameters.AddWithValue("@Pedido", Pedido);

        //        Produto p = null;

        //        if (dr.Read())
        //        {
        //            p = new Produto();

        //            p.Cod_Produto = Convert.ToInt32(dr["Codigo"]);
        //            p.Status = Convert.ToString(dr["Status"]);
        //            p.Descricao = Convert.ToString(dr["Descricao"]);
        //            p.Modelo = Convert.ToString(dr["Modelo"]);
        //            p.Marca = Convert.ToString(dr["Marca"]);
        //            p.Tipo = Convert.ToString(dr["Tipo"]);
        //        }

        //        return p;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("" + ex.Message);
        //    }
        //    finally
        //    {
        //        FecharConexao();
        //    }
        //}

        public SqlDataReader SelectSaidaES(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_SAIDAES WHERE NUMPEDIDO=@Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("´Dados de saída não localizados!" + ex.Message);
            }
        }

        public SqlDataReader reportES(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_SAIDA, P.Codigo, P.Descricao, P.Modelo, P.Marca, E.QTDS, E.LIBERADOR FROM TB_SAIDAES AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.NUMPEDIDO = @Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        #endregion

        #region "PARÁ"
        public void GravarPA(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_SAIDAPA(FK_ENTRADA, ID_PRODUTO, QTDS, DATASAIDA, USUARIO, NUMPEDIDO, LIBERADOR, RECEBEDOR, AUTORIZADO, STATUS_PEDIDO) values (@IDEntrada, @IDProduto, @QtdS, @Data, @User, @Pedido, @Liberador, @Recebedor, @Autorizado, @Status);", con);
                cmd.Parameters.AddWithValue("@IDEntrada", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@IDProduto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdS", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);
                cmd.Parameters.AddWithValue("@Pedido", s.NumPedido);
                cmd.Parameters.AddWithValue("@Liberador", s.Liberador);
                cmd.Parameters.AddWithValue("@Recebedor", s.Recebedor);
                cmd.Parameters.AddWithValue("@Autorizado", s.Autorizado);
                cmd.Parameters.AddWithValue("@Status", s.StatusPedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarPA(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_SAIDAPA SET PK_SAIDA=@PK, FK_ENTRADA=@FK, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;", con);
                cmd.Parameters.AddWithValue("@PK", s.Cod_Saida);
                cmd.Parameters.AddWithValue("@FK", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@Produto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdE", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExcluirPA(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("DELETE FROM TB_SAIDAPA WHERE PK_=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //public Saida PesquisarporPedido(string Pedido)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_SAIDAMG WHERE NUMPEDIDO=@PEDIDO;", con);
        //        cmd.Parameters.AddWithValue("@Pedido", Pedido);

        //        Produto p = null;

        //        if (dr.Read())
        //        {
        //            p = new Produto();

        //            p.Cod_Produto = Convert.ToInt32(dr["Codigo"]);
        //            p.Status = Convert.ToString(dr["Status"]);
        //            p.Descricao = Convert.ToString(dr["Descricao"]);
        //            p.Modelo = Convert.ToString(dr["Modelo"]);
        //            p.Marca = Convert.ToString(dr["Marca"]);
        //            p.Tipo = Convert.ToString(dr["Tipo"]);
        //        }

        //        return p;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("" + ex.Message);
        //    }
        //    finally
        //    {
        //        FecharConexao();
        //    }
        //}

        public SqlDataReader SelectSaidaPA(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_SAIDAPA WHERE NUMPEDIDO=@Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("´Dados de saída não localizados!" + ex.Message);
            }
        }

        public SqlDataReader reportPA(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_SAIDA, P.Codigo, P.Descricao, P.Modelo, P.Marca, E.QTDS, E.LIBERADOR FROM TB_SAIDAPA AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.NUMPEDIDO = @Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }
        #endregion

        #region "RIO DE JANEIRO"
        public void GravarRJ(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_SAIDARJ(FK_ENTRADA, ID_PRODUTO, QTDS, DATASAIDA, USUARIO, NUMPEDIDO, LIBERADOR, RECEBEDOR, AUTORIZADO, STATUS_PEDIDO) values (@IDEntrada, @IDProduto, @QtdS, @Data, @User, @Pedido, @Liberador, @Recebedor, @Autorizado, @Status);", con);
                cmd.Parameters.AddWithValue("@IDEntrada", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@IDProduto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdS", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);
                cmd.Parameters.AddWithValue("@Pedido", s.NumPedido);
                cmd.Parameters.AddWithValue("@Liberador", s.Liberador);
                cmd.Parameters.AddWithValue("@Recebedor", s.Recebedor);
                cmd.Parameters.AddWithValue("@Autorizado", s.Autorizado);
                cmd.Parameters.AddWithValue("@Status", s.StatusPedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarRJ(Saida s)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_SAIDARJ SET PK_SAIDA=@PK, FK_ENTRADA=@FK, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;", con);
                cmd.Parameters.AddWithValue("@PK", s.Cod_Saida);
                cmd.Parameters.AddWithValue("@FK", s.Cod_Entrada);
                cmd.Parameters.AddWithValue("@Produto", s.Cod_Produto);
                cmd.Parameters.AddWithValue("@QtdE", s.QtdS);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@User", s.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a saída!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExcluirRJ(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("DELETE FROM TB_SAIDARJ WHERE PK_=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //public Saida PesquisarporPedido(string Pedido)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_SAIDAMG WHERE NUMPEDIDO=@PEDIDO;", con);
        //        cmd.Parameters.AddWithValue("@Pedido", Pedido);

        //        Produto p = null;

        //        if (dr.Read())
        //        {
        //            p = new Produto();

        //            p.Cod_Produto = Convert.ToInt32(dr["Codigo"]);
        //            p.Status = Convert.ToString(dr["Status"]);
        //            p.Descricao = Convert.ToString(dr["Descricao"]);
        //            p.Modelo = Convert.ToString(dr["Modelo"]);
        //            p.Marca = Convert.ToString(dr["Marca"]);
        //            p.Tipo = Convert.ToString(dr["Tipo"]);
        //        }

        //        return p;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("" + ex.Message);
        //    }
        //    finally
        //    {
        //        FecharConexao();
        //    }
        //}

        public SqlDataReader SelectSaidaRJ(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_SAIDARJ WHERE NUMPEDIDO=@Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("´Dados de saída não localizados!" + ex.Message);
            }
        }

        public SqlDataReader reportRJ(string Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_SAIDA, P.Codigo, P.Descricao, P.Modelo, P.Marca, E.QTDS, E.LIBERADOR FROM TB_SAIDARJ AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.NUMPEDIDO = @Pedido;", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        #endregion
    }
}