using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Persistense
{
    public class EstoqueDAL : Conexao
    {
        public void GravarGeral(Estoque e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_ESTOQUEGERAL(FK_PRODUTO, QTDE, QTDS, ORIGEM, DESTINO, DATAENT, USUARIO, STATUS, OBS) values (@Produto, @QtdE, @QtdS, @Origem, @Destino, @Data, @User, @Status, @Obs);", con);
                cmd.Parameters.AddWithValue("@Produto", e.FK_PRODUTO);
                cmd.Parameters.AddWithValue("@QtdE", e.QTDE);
                cmd.Parameters.AddWithValue("@QtdS", e.QTDS);
                cmd.Parameters.AddWithValue("@Origem", e.Origem);
                cmd.Parameters.AddWithValue("@Destino", e.Destino);
                cmd.Parameters.AddWithValue("@Data", e.Data);
                cmd.Parameters.AddWithValue("@User", e.Usuario);
                cmd.Parameters.AddWithValue("@Status", e.Status);
                cmd.Parameters.AddWithValue("@Obs", e.Obs);

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

        public void AtualizaQTDGeral(Estoque e)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_ESTOQUEGERAL SET QTDS=@QtdS, PROTOCOLO=@Protocolo, OBS=@Obs WHERE PK_GERAL=@ID ;", con);
                cmd.Parameters.AddWithValue("@QtdS", e.QTDS);
                cmd.Parameters.AddWithValue("@Protocolo", e.Protocolo);
                cmd.Parameters.AddWithValue("@Obs", e.Obs);
                cmd.Parameters.AddWithValue("@ID", e.PK_GERAL);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar dados!" + ex.Message);
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

                cmd = new SqlCommand("SELECT QTDS, OBS FROM TB_ESTOQUEGERAL WHERE PK_GERAL=@PK;", con);
                cmd.Parameters.AddWithValue("@PK", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        public SqlDataReader BuscaEstoque(string Estoque)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT E.PK_GERAL, P.Codigo, P.Descricao, P.Modelo, P.Marca, QTD=(E.QTDE - E.QTDS) FROM TB_ESTOQUEGERAL AS E INNER JOIN TB_PRODUTOS AS P ON E.FK_PRODUTO = P.Codigo WHERE E.DESTINO = @Estoque", con);
                cmd.Parameters.AddWithValue("@Estoque", Estoque);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Não encontrado!" + ex.Message);
            }
        }

        public SqlDataReader Inventario(string Estoque)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT P.Descricao, SUM(E.QTDE - E.QTDS) AS QTD FROM TB_ESTOQUEGERAL AS E INNER JOIN TB_PRODUTOS AS P ON E.FK_PRODUTO = P.Codigo WHERE E.DESTINO = @Estoque GROUP BY P.Descricao", con);
                cmd.Parameters.AddWithValue("@Estoque", Estoque);
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