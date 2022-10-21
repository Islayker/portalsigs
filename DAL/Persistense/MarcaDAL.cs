using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Model;
using System.Data.SqlClient;

namespace DAL.Persistense
{
    public class MarcaDAL : Conexao
    {
        public void Gravar(Marca m)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("INSERT INTO TB_MARCAS(NOME_MARCA) values (@Nome);", con);
                cmd.Parameters.AddWithValue("@Nome", m.NOME_MARCA);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir marca!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Atualizar(Marca m)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_MARCAS SET NOME_MARCA=@Nome WHERE Codigo=@Codigo;");
                cmd.Parameters.AddWithValue("@Nome", m.NOME_MARCA);
                cmd.Parameters.AddWithValue("@Codigo", m.PKMARCAS);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a marca!" + ex.Message);
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

                cmd = new SqlCommand("DELETE FROM TB_MARCAS WHERE PKMARCAS=@Codigo;");
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir marca!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Marca PesquisarporCodigo(int Codigo)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_MARCAS WHERE PKMARCAS=@Codigo;");
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                Marca m = null;

                if (dr.Read())
                {
                    m = new Marca();

                    m.PKMARCAS = Convert.ToInt32(dr["PKMARCAS"]);
                    m.NOME_MARCA = Convert.ToString(dr["NOME_MARCA"]);
                }

                return m;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhuma marca encontrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Marca> Listar()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_MARCAS ORDER BY NOME_MARCAS ASC;");
                dr = cmd.ExecuteReader();

                List<Marca> lista = new List<Marca>();

                while (dr.Read())
                {
                    Marca m = new Marca();

                    m.PKMARCAS = Convert.ToInt32(dr["PKMARCAS"]);
                    m.NOME_MARCA = Convert.ToString(dr["NOME_MARCA"]);

                    lista.Add(m);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhuma marca encontrada!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}