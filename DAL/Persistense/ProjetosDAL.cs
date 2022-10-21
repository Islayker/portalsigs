using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistense
{
    public class ProjetosDAL : Conexao
    {
        public DataTable DDLMG()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT ID, Num_OS, UF, Site, Localidade FROM Base WHERE UF='MG' OR UF='BR' AND STATUS <> 'Cancelado' ORDER BY ID ASC", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                DataColumn agragado = new DataColumn("Agregado", Type.GetType("System.String"));
                agragado.Expression = "ID + ' - ' + Localidade";
                dt2.Columns.Add(agragado);
                return dt2;
            }
            catch(Exception ex)
            {
                throw new Exception("Nenhum projeto encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public DataTable DDLMA()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT ID, Num_OS, UF, Site, Localidade FROM Base WHERE UF='MA' OR UF='BR' AND STATUS <> 'Cancelado' ORDER BY ID ASC", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                DataColumn agragado = new DataColumn("Agregado", Type.GetType("System.String"));
                agragado.Expression = "ID + ' - ' + Localidade";
                dt2.Columns.Add(agragado);
                return dt2;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhum projeto encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public DataTable DDLES()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT ID, Localidade, UF FROM Base WHERE UF='ES' OR UF='BR' AND STATUS <> 'Cancelado' ORDER BY ID ASC", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                DataColumn agragado = new DataColumn("Agregado", Type.GetType("System.String"));
                agragado.Expression = "ID + ' - ' + Localidade";
                dt2.Columns.Add(agragado);
                return dt2;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhum projeto encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public DataTable DDLPA()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT ID, Localidade, UF FROM Base WHERE UF='PA' OR UF='BR' AND STATUS <> 'Cancelado' ORDER BY ID ASC", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                DataColumn agragado = new DataColumn("Agregado", Type.GetType("System.String"));
                agragado.Expression = "ID + ' - ' + Localidade";
                dt2.Columns.Add(agragado);
                return dt2;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhum projeto encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public DataTable DDLRJ()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT ID, Localidade, UF FROM Base WHERE UF='RJ' OR UF='BR' AND STATUS <> 'Cancelado' ORDER BY ID ASC", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                DataColumn agragado = new DataColumn("Agregado", Type.GetType("System.String"));
                agragado.Expression = "ID + ' - ' + Localidade";
                dt2.Columns.Add(agragado);
                return dt2;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhum projeto encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public DataTable DDLGERAL()
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT ID, Localidade, UF FROM Base WHERE STATUS <> 'Cancelado' ORDER BY ID ASC", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                DataColumn agragado = new DataColumn("Agregado", Type.GetType("System.String"));
                agragado.Expression = "ID + ' - ' + Localidade";
                dt2.Columns.Add(agragado);
                return dt2;
            }
            catch (Exception ex)
            {
                throw new Exception("Nenhum projeto encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public SqlDataReader SelecionaUF(int Cod)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT UF FROM Base WHERE ID=@PK", con);
                cmd.Parameters.AddWithValue("@PK", Cod);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a entrada!" + ex.Message);
            }
        }

        //public DataTable MG(int ID)
        //{
        //    try
        //    {
        //        AbrirConexao();

        //        cmd = new SqlCommand("SELECT ID, Num_OS, UF, Site, Localidade FROM Base WHERE ID=@ID", con);
        //        cmd.Parameters.AddWithValue("@ID", ID);
        //        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
        //        DataTable dt2 = new DataTable();
        //        da2.Fill(dt2);
        //        return dt2;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Nenhum projeto encontrado!" + ex.Message);
        //    }
        //    finally
        //    {
        //        FecharConexao();
        //    }
        //}

        public Projetos MG(int ID)
        {
            try
            {
                AbrirConexao();

                cmd = new SqlCommand("SELECT ID, Num_OS, UF, Site, Localidade FROM Base WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                dr = cmd.ExecuteReader();

                Projetos p = null;

                if (dr.Read())
                {
                    p = new Projetos();

                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.OS = Convert.ToString(dr["Num_OS"]);
                    p.UF = Convert.ToString(dr["UF"]);
                    p.Site = Convert.ToString(dr["Site"]);
                    p.Localidade = Convert.ToString(dr["Localidade"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Projeto não encontrado!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

    }
}