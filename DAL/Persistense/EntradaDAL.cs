using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistense
{
    public class EntradaDAL : Conexao
    {
        #region "MINAS GERAIS"
        public void GravarMG(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_ENTRADAMG(ID_DEMANDA, ID_PRODUTO, NF, QTDE, QTDS, DATAENT, ORIGEM, USUARIO) values (@ID, @Produto, @NF, @QtdE, @QtdS, @Data, @Origem, @User);", con);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public SqlDataReader SelecionaQTDS(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT QTDS FROM TB_ENTRADAMG WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public void AtualizarQTDS(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAMG SET QTDS=@QtdS WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarMG(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAMG SET ID_DEMANDA=@ID, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, QTDS=@QtdS, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;", con);
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
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

                cmd = new SqlCommand("DELETE FROM TB_ENTRADAMG WHERE PK_=@Codigo;");
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

        public SqlDataReader InventarioProjetosMG(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT P.Descricao, E.NF, SUM(E.QTDE - E.QTDS) AS QTD FROM TB_ENTRADAMG AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.ID_DEMANDA = @ID GROUP BY P.Descricao, E.NF;", con);
                cmd.Parameters.AddWithValue("@ID", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public List<Entrada> ListarMG()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_ENTRADAMG;");
                dr = cmd.ExecuteReader();

                List<Entrada> lista = new List<Entrada>();

                while (dr.Read())
                {
                    Entrada e = new Entrada();

                    e.Cod_Entrada = Convert.ToInt32(dr["PK_ENTRADA"]);
                    e.ID_Demanda = Convert.ToInt32(dr["ID_DEMANDA"]);
                    e.ID_PRODUTO = Convert.ToInt32(dr["ID_PRODUTO"]);
                    e.NF = Convert.ToString(dr["NF"]);
                    e.QtdE = Convert.ToInt32(dr["QtdE"]);
                    e.QtdS = Convert.ToInt32(dr["QtdS"]);
                    e.Data = Convert.ToDateTime(dr["DATAENT"]);
                    e.Origem = Convert.ToString(dr["ORIGEM"]);
                    e.Usuario = Convert.ToString(dr["USUARIO"]);

                    lista.Add(e);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhuma entrada encontrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion

        #region "MARANHÃO"
        public void GravarMA(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_ENTRADAMA(ID_DEMANDA, ID_PRODUTO, NF, QTDE, QTDS, DATAENT, ORIGEM, USUARIO) values (@ID, @Produto, @NF, @QtdE, @QtdS, @Data, @Origem, @User);", con);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public SqlDataReader SelecionaQTDSMA(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT QTDS FROM TB_ENTRADAMA WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public void AtualizarQTDSMA(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAMA SET QTDS=@QtdS WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarMA(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAMA SET PK_ENTRADA=@PK, ID_DEMANDA=@ID, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, QTDS=@QtdS, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;");
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
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

                cmd = new SqlCommand("DELETE FROM TB_ENTRADAMA WHERE PK_=@Codigo;");
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

        public SqlDataReader InventarioProjetosMA(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT P.Descricao, E.NF, SUM(E.QTDE - E.QTDS) AS QTD FROM TB_ENTRADAMA AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.ID_DEMANDA = @ID GROUP BY P.Descricao, E.NF;", con);
                cmd.Parameters.AddWithValue("@ID", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public List<Entrada> ListarMA()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_ENTRADAMA;");
                dr = cmd.ExecuteReader();

                List<Entrada> lista = new List<Entrada>();

                while (dr.Read())
                {
                    Entrada e = new Entrada();

                    e.Cod_Entrada = Convert.ToInt32(dr["PK_ENTRADA"]);
                    e.ID_Demanda = Convert.ToInt32(dr["ID_DEMANDA"]);
                    e.ID_PRODUTO = Convert.ToInt32(dr["ID_PRODUTO"]);
                    e.NF = Convert.ToString(dr["NF"]);
                    e.QtdE = Convert.ToInt32(dr["QtdE"]);
                    e.QtdS = Convert.ToInt32(dr["QtdS"]);
                    e.Data = Convert.ToDateTime(dr["DATAENT"]);
                    e.Origem = Convert.ToString(dr["ORIGEM"]);
                    e.Usuario = Convert.ToString(dr["USUARIO"]);

                    lista.Add(e);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhuma entrada encontrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion

        #region "ESPIRITO SANTO"
        public void GravarES(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_ENTRADAES(ID_DEMANDA, ID_PRODUTO, NF, QTDE, QTDS, DATAENT, ORIGEM, USUARIO) values (@ID, @Produto, @NF, @QtdE, @QtdS, @Data, @Origem, @User);", con);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public SqlDataReader SelecionaQTDSES(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT QTDS FROM TB_ENTRADAES WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public void AtualizarQTDSES(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAES SET QTDS=@QtdS WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarES(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAES SET PK_ENTRADA=@PK, ID_DEMANDA=@ID, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, QTDS=@QtdS, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;");
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
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

                cmd = new SqlCommand("DELETE FROM TB_ENTRADAES WHERE PK_=@Codigo;");
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

        //public Produto PesquisarporCodigo(int Codigo)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_PRODUTOS WHERE Codigo=@Codigo;");
        //        cmd.Parameters.AddWithValue("@Codigo", Codigo);

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

        public List<Entrada> ListarES()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_ENTRADAES;");
                dr = cmd.ExecuteReader();

                List<Entrada> lista = new List<Entrada>();

                while (dr.Read())
                {
                    Entrada e = new Entrada();

                    e.Cod_Entrada = Convert.ToInt32(dr["PK_ENTRADA"]);
                    e.ID_Demanda = Convert.ToInt32(dr["ID_DEMANDA"]);
                    e.ID_PRODUTO = Convert.ToInt32(dr["ID_PRODUTO"]);
                    e.NF = Convert.ToString(dr["NF"]);
                    e.QtdE = Convert.ToInt32(dr["QtdE"]);
                    e.QtdS = Convert.ToInt32(dr["QtdS"]);
                    e.Data = Convert.ToDateTime(dr["DATAENT"]);
                    e.Origem = Convert.ToString(dr["ORIGEM"]);
                    e.Usuario = Convert.ToString(dr["USUARIO"]);

                    lista.Add(e);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhuma entrada encontrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion

        #region "PARÁ"
        public void GravarPA(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_ENTRADAPA(ID_DEMANDA, ID_PRODUTO, NF, QTDE, QTDS, DATAENT, ORIGEM, USUARIO) values (@ID, @Produto, @NF, @QtdE, @QtdS, @Data, @Origem, @User);", con);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public SqlDataReader SelecionaQTDSPA(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT QTDS FROM TB_ENTRADAPA WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public void AtualizarQTDSPA(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAPA SET QTDS=@QtdS WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarPA(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADAPA SET PK_ENTRADA=@PK, ID_DEMANDA=@ID, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, QTDS=@QtdS, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;");
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
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

                cmd = new SqlCommand("DELETE FROM TB_ENTRADAPA WHERE PK_=@Codigo;");
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

        //public Produto PesquisarporCodigo(int Codigo)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_PRODUTOS WHERE Codigo=@Codigo;");
        //        cmd.Parameters.AddWithValue("@Codigo", Codigo);

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

        public List<Entrada> ListarPA()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_ENTRADAPA;");
                dr = cmd.ExecuteReader();

                List<Entrada> lista = new List<Entrada>();

                while (dr.Read())
                {
                    Entrada e = new Entrada();

                    e.Cod_Entrada = Convert.ToInt32(dr["PK_ENTRADA"]);
                    e.ID_Demanda = Convert.ToInt32(dr["ID_DEMANDA"]);
                    e.ID_PRODUTO = Convert.ToInt32(dr["ID_PRODUTO"]);
                    e.NF = Convert.ToString(dr["NF"]);
                    e.QtdE = Convert.ToInt32(dr["QtdE"]);
                    e.QtdS = Convert.ToInt32(dr["QtdS"]);
                    e.Data = Convert.ToDateTime(dr["DATAENT"]);
                    e.Origem = Convert.ToString(dr["ORIGEM"]);
                    e.Usuario = Convert.ToString(dr["USUARIO"]);

                    lista.Add(e);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhuma entrada encontrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion

        #region "RIO DE JANEIRO"
        public void GravarRJ(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_ENTRADARJ(ID_DEMANDA, ID_PRODUTO, NF, QTDE, QTDS, DATAENT, ORIGEM, USUARIO) values (@ID, @Produto, @NF, @QtdE, @QtdS, @Data, @Origem, @User);", con);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public SqlDataReader SelecionaQTDSRJ(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT QTDS FROM TB_ENTRADARJ WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public void AtualizarQTDSRJ(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADARJ SET QTDS=@QtdS WHERE PK_ENTRADA=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarRJ(Entrada e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ENTRADARJS SET PK_ENTRADA=@PK, ID_DEMANDA=@ID, ID_PRODUTO=@Produto, NF=@NF, QTDE=@QtdE, QTDS=@QtdS, DATAENT=@Data, ORIGEM=@Origem, USUARIO=@User;");
                cmd.Parameters.AddWithValue("@PK", e.Cod_Entrada);
                cmd.Parameters.AddWithValue("@ID", e.ID_Demanda);
                cmd.Parameters.AddWithValue("@Produto", e.ID_PRODUTO);
                cmd.Parameters.AddWithValue("@NF", e.NF);
                cmd.Parameters.AddWithValue("@QtdE", e.QtdE);
                cmd.Parameters.AddWithValue("@QtdS", e.QtdS);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@User", e.Usuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entrada!" + ex.Message);
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

                cmd = new SqlCommand("DELETE FROM TB_ENTRADARJ WHERE PK_=@Codigo;");
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

        //public Produto PesquisarporCodigo(int Codigo)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT * FROM TB_PRODUTOS WHERE Codigo=@Codigo;");
        //        cmd.Parameters.AddWithValue("@Codigo", Codigo);

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

        public List<Entrada> ListarRJ()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_ENTRADARJ;");
                dr = cmd.ExecuteReader();

                List<Entrada> lista = new List<Entrada>();

                while (dr.Read())
                {
                    Entrada e = new Entrada();

                    e.Cod_Entrada = Convert.ToInt32(dr["PK_ENTRADA"]);
                    e.ID_Demanda = Convert.ToInt32(dr["ID_DEMANDA"]);
                    e.ID_PRODUTO = Convert.ToInt32(dr["ID_PRODUTO"]);
                    e.NF = Convert.ToString(dr["NF"]);
                    e.QtdE = Convert.ToInt32(dr["QtdE"]);
                    e.QtdS = Convert.ToInt32(dr["QtdS"]);
                    e.Data = Convert.ToDateTime(dr["DATAENT"]);
                    e.Origem = Convert.ToString(dr["ORIGEM"]);
                    e.Usuario = Convert.ToString(dr["USUARIO"]);

                    lista.Add(e);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhuma entrada encontrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion
    }
}