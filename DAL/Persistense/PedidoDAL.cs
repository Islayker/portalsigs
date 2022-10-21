using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistense
{
    public class PedidoDAL : Conexao
    {
        #region "MG"
        public Pedido PesquisarPedidoMG()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_CONTROLLERPEDIDO WHERE ESTADO='MG';", con);
                dr = cmd.ExecuteReader();

                Pedido p = null;

                if (dr.Read())
                {
                    p = new Pedido();

                    p.NumPedido = Convert.ToInt32(dr["NUM_PEDIDO"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Número do Pedido não encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarPedidoMG(int Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_CONTROLLERPEDIDO SET NUM_PEDIDO=@Pedido WHERE ESTADO = 'MG';", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o pedido!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion

        #region "MA"
        public Pedido PesquisarPedidoMA()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_CONTROLLERPEDIDO WHERE ESTADO='MA';", con);
                dr = cmd.ExecuteReader();

                Pedido p = null;

                if (dr.Read())
                {
                    p = new Pedido();

                    p.NumPedido = Convert.ToInt32(dr["NUM_PEDIDO"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Número do Pedido não encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarPedidoMA(int Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_CONTROLLERPEDIDO SET NUM_PEDIDO=@Pedido WHERE ESTADO = 'MA';", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o pedido!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion

        #region "ES"
        public Pedido PesquisarPedidoES()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_CONTROLLERPEDIDO WHERE ESTADO='ES';", con);
                dr = cmd.ExecuteReader();

                Pedido p = null;

                if (dr.Read())
                {
                    p = new Pedido();

                    p.NumPedido = Convert.ToInt32(dr["NUM_PEDIDO"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Número do Pedido não encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarPedidoES(int Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_CONTROLLERPEDIDO SET NUM_PEDIDO=@Pedido WHERE ESTADO = 'ES';", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o pedido!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion

        #region "PA"
        public Pedido PesquisarPedidoPA()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_CONTROLLERPEDIDO WHERE ESTADO='PA';", con);
                dr = cmd.ExecuteReader();

                Pedido p = null;

                if (dr.Read())
                {
                    p = new Pedido();

                    p.NumPedido = Convert.ToInt32(dr["NUM_PEDIDO"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Número do Pedido não encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarPedidoPA(int Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_CONTROLLERPEDIDO SET NUM_PEDIDO=@Pedido WHERE ESTADO = 'PA';", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o pedido!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion

        #region "RJ"
        public Pedido PesquisarPedidoRJ()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT * FROM TB_CONTROLLERPEDIDO WHERE ESTADO='RJ';", con);
                dr = cmd.ExecuteReader();

                Pedido p = null;

                if (dr.Read())
                {
                    p = new Pedido();

                    p.NumPedido = Convert.ToInt32(dr["NUM_PEDIDO"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Número do Pedido não encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizarPedidoRJ(int Pedido)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("UPDATE TB_CONTROLLERPEDIDO SET NUM_PEDIDO=@Pedido WHERE ESTADO = 'RJ';", con);
                cmd.Parameters.AddWithValue("@Pedido", Pedido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o pedido!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion
        public SqlDataReader SelecionaPedido(string UF)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT NUM_PEDIDO FROM TB_CONTROLLERPEDIDO WHERE ESTADO = @UF;", con);
                cmd.Parameters.AddWithValue("@UF", UF);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        
    }
}