using DAL.Model;
using DAL.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstoqueSigs.Pages
{
    public partial class TransferID : System.Web.UI.Page
    {
        Valida vld = new Valida();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsgS.Visible = false;
            lblMsgW.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    var dt = pjd.DDLGERAL();

                    ddlID.DataSource = dt;
                    ddlID.DataTextField = "Agregado";
                    ddlID.DataValueField = "ID";
                    ddlID.DataBind();
                    ddlID.Items.Insert(0, new ListItem("-- Selecione um ID/OS --", "0"));

                }
                catch (Exception ex)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = ex.Message;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.PreencherGrid();
        }

        public void PreencherGrid()
        {
            string estoque = ddlOrigem.SelectedValue;

            try
            {
                EstoqueDAL estDAL = new EstoqueDAL();

                var dr = estDAL.BuscaEstoque(estoque);

                if (dr.HasRows == false)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = "Nenhum material encontrado!";
                }
                else
                {
                    txtProtocolo.Text = DateTime.Today.Day + "" + DateTime.Today.Month + "" + DateTime.Today.Year + "." + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second;

                    PanelSaida.Visible = true;
                    grdEstoque.DataSource = dr;
                    grdEstoque.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = ex.Message;
            }
        }

        public void ddlID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int chave = Convert.ToInt32(ddlID.SelectedValue);
            ProjetosDAL pjd = new ProjetosDAL();
            var dt = pjd.SelecionaUF(chave);
            while (dt.Read())
            {
                UFt.Value = dt[0].ToString();
            }
            lblMsgS.Visible = false;
            lblMsgW.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            int ID = Convert.ToInt32(ddlID.SelectedValue.ToString());
            if (ddlAprovador.SelectedIndex == 0 || ddlID.SelectedIndex == 0)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = "Preencha todos os campos!";
                PanelSaida.Visible = true;
            }
            else
            {
                foreach (GridViewRow row in grdEstoque.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[7].FindControl("chkSeleciona") as CheckBox);
                        if (chkRow.Checked)
                        {
                            int identrada = int.Parse(grdEstoque.DataKeys[row.RowIndex].Values["PK_GERAL"].ToString());
                            int idproduto = int.Parse(grdEstoque.DataKeys[row.RowIndex].Values["Codigo"].ToString());
                            int qtd = int.Parse(row.Cells[5].Text);
                            var valor = (TextBox)(grdEstoque.Rows[row.RowIndex].Cells[6].FindControl("txtQtd"));
                            int qtdR = int.Parse(valor.Text.ToString());

                            if ((qtdR > 0) && (qtd > 0) && (qtdR <= qtd))
                            {
                                try
                                {
                                    Entrada en = new Entrada();
                                    en.ID_Demanda = ID;
                                    en.ID_PRODUTO = idproduto;
                                    en.NF = "0000";
                                    en.QtdE = qtdR;
                                    en.QtdS = 0;
                                    en.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                                    en.Usuario = HttpContext.Current.Session["Nome_User"].ToString();
                                    en.Origem = ddlOrigem.SelectedValue.ToString();

                                    if (UFt.Value == "ES")
                                    {
                                        EntradaDAL enD = new EntradaDAL();
                                        enD.GravarES(en);
                                    }
                                    else if (UFt.Value == "MA")
                                    {
                                        EntradaDAL enD = new EntradaDAL();
                                        enD.GravarMA(en);
                                    }
                                    else if (UFt.Value == "MG")
                                    {
                                        EntradaDAL enD = new EntradaDAL();
                                        enD.GravarMG(en);
                                    }
                                    else if (UFt.Value == "PA")
                                    {
                                        EntradaDAL enD = new EntradaDAL();
                                        enD.GravarPA(en);
                                    }
                                    else if (UFt.Value == "RJ")
                                    {
                                        EntradaDAL enD = new EntradaDAL();
                                        enD.GravarRJ(en);
                                    }
                                    else if (UFt.Value == null || UFt.Value == string.Empty)
                                    {
                                        lblMsgW.Visible = true;
                                        lblMsgW.Text = "Algo saiu errado, favor conferir!";
                                    }
                                    
                                    Estoque est = new Estoque();
                                    est.PK_GERAL = identrada;
                                    est.Protocolo = txtProtocolo.Text;

                                    EstoqueDAL estDal = new EstoqueDAL();

                                    var dr = estDal.SelecionaQTDS(identrada);
                                    if (dr.HasRows == false)
                                    {
                                        lblMsgW.Visible = true;
                                        lblMsgW.Text = "Erro!";
                                    }
                                    else
                                    {
                                        string obs;
                                        int quantidade;
                                        while (dr.Read())
                                        {
                                            quantidade = int.Parse(dr[0].ToString());
                                            est.QTDS = quantidade + qtdR;
                                            obs = dr[1].ToString();
                                            est.Obs = obs + Convert.ToString(DateTime.Now.ToShortDateString()) + "-" + txtProtocolo.Text + " - Transferido " + qtdR + " un(s)/mt(s) para " + ddlID.SelectedValue.ToString() + " por: " + ddlAprovador.SelectedValue.ToString() + "; ";
                                        }
                                        estDal.AtualizaQTDGeral(est);
                                    }
                                    lblMsgW.Visible = false;
                                    lblMsgS.Visible = true;
                                    lblMsgS.Text = "Equipamento transferido com sucesso!";
                                }
                                catch (Exception ex)
                                {
                                    lblMsgS.Visible = false;
                                    lblMsgW.Visible = true;
                                    lblMsgW.Text = ex.Message;
                                    PanelSaida.Visible = true;
                                }
                            }
                            else
                            {
                                lblMsgS.Visible = false;
                                lblMsgW.Visible = true;
                                lblMsgW.Text = "Quantidade incorreta!";
                                PanelSaida.Visible = true;
                            }
                        }
                        else if (i < 1)
                        {
                            lblMsgS.Visible = false;
                            lblMsgW.Visible = true;
                            lblMsgW.Text = "Nenhum item selecionado!";
                            PanelSaida.Visible = true;
                        }
                    }
                }
            }
            ddlID.SelectedIndex = -1;
            ddlOrigem.SelectedIndex = -1;
            PanelSaida.Visible = false;
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            vld.LimparCampos(this);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}