using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DAL.Model;
using System.Data;

namespace DAL.Persistense
{
    public class ProdutoDAL : Conexao
    {
        public void Gravar(Produto p)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_PRODUTOS(Status, Descricao, Modelo, Marca, Tipo) values (@Status, @Descricao, @Modelo, @Marca, @Tipo);", con);
                cmd.Parameters.AddWithValue("@Status", p.Status);
                cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
                cmd.Parameters.AddWithValue("@Modelo", p.Modelo);
                cmd.Parameters.AddWithValue("@Marca", p.Marca);
                cmd.Parameters.AddWithValue("@Tipo", p.Tipo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Atualizar(Produto p)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_PRODUTOS SET Status=@Status, Descricao=@Descricao, Modelo=@Modelo, Marca=@Marca, Tipo=@Tipo WHERE Codigo=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Status", p.Status);
                cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
                cmd.Parameters.AddWithValue("@Modelo", p.Modelo);
                cmd.Parameters.AddWithValue("@Marca", p.Marca);
                cmd.Parameters.AddWithValue("@Tipo", p.Tipo);
                cmd.Parameters.AddWithValue("@Codigo", p.Cod_Produto);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao atualizar o produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("DELETE FROM TB_PRODUTOS WHERE Codigo=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao excluir produto!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Produto PesquisarporCodigo(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_PRODUTOS WHERE Codigo=@Codigo;", con);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                dr = cmd.ExecuteReader();

                Produto p = null;

                if (dr.Read())
                {
                    p = new Produto();

                    p.Cod_Produto = Convert.ToInt32(dr["Codigo"]);
                    p.Status = Convert.ToString(dr["Status"]);
                    p.Descricao = Convert.ToString(dr["Descricao"]);
                    p.Modelo = Convert.ToString(dr["Modelo"]);
                    p.Marca = Convert.ToString(dr["Marca"]);
                    p.Tipo = Convert.ToString(dr["Tipo"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Produto não encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_PRODUTOS ORDER BY Descricao ASC;", con);
                dr = cmd.ExecuteReader();

                List<Produto> lista = new List<Produto>();

                while(dr.Read())
                {
                    Produto p = new Produto();

                    p.Cod_Produto = Convert.ToInt32(dr["Codigo"]);
                    p.Status = Convert.ToString(dr["Status"]);
                    p.Descricao = Convert.ToString(dr["Descricao"]);
                    p.Modelo = Convert.ToString(dr["Modelo"]);
                    p.Marca = Convert.ToString(dr["Marca"]);
                    p.Tipo = Convert.ToString(dr["Tipo"]);

                    lista.Add(p);
                }

                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception("Produtos não encontrados!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public SqlDataReader Drop(string Desc)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_PRODUTOS WHERE Descricao LIKE '%' + @Desc + '%'", con);
                cmd.Parameters.AddWithValue("@Desc", Desc);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch(Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

 
        public SqlDataReader SaidaMG(int ID)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_ENTRADA, P.Codigo, P.Descricao, P.Modelo, P.Marca, QTD=(E.QTDE - E.QTDS) FROM TB_ENTRADAMG AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.ID_DEMANDA = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch(Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        public SqlDataReader SaidaMA(int ID)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_ENTRADA, P.Codigo, P.Descricao, P.Modelo, P.Marca, QTD=(E.QTDE - E.QTDS) FROM TB_ENTRADAMA AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.ID_DEMANDA = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        public SqlDataReader SaidaES(int ID)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_ENTRADA, P.Codigo, P.Descricao, P.Modelo, P.Marca, QTD=(E.QTDE - E.QTDS) FROM TB_ENTRADAES AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.ID_DEMANDA = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        public SqlDataReader SaidaPA(int ID)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_ENTRADA, P.Codigo, P.Descricao, P.Modelo, P.Marca, QTD=(E.QTDE - E.QTDS) FROM TB_ENTRADAPA AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.ID_DEMANDA = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        public SqlDataReader SaidaRJ(int ID)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_ENTRADA, P.Codigo, P.Descricao, P.Modelo, P.Marca, QTD=(E.QTDE - E.QTDS) FROM TB_ENTRADARJ AS E INNER JOIN TB_PRODUTOS AS P ON E.ID_PRODUTO = P.Codigo WHERE E.ID_DEMANDA = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }
    }
}