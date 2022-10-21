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
    public partial class OutEstoqueMA : System.Web.UI.Page
    {
        Valida vld = new Valida();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsgW.Visible = false;
            lblMsgS.Visible = false;
            PanelSaida.Visible = false;

            if (!IsPostBack)
            {
                try
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    var dt = pjd.DDLMA();

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
            int ID = Convert.ToInt32(ddlID.SelectedValue.ToString());
            int protocolo;

            try
            {
                ProdutoDAL pd = new ProdutoDAL();

                var dr = pd.SaidaMA(ID);

                if (dr.HasRows == false)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = "Nenhum material encontrado!";
                }
                else
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    Projetos p = pjd.MG(ID);

                    if (p != null)
                    {
                        txtID.Text = Convert.ToString(p.ID);
                        txtOS.Text = Convert.ToString(p.OS);
                        txtSite.Text = p.UF + " - " + p.Site;
                        txtLocalidade.Text = p.Localidade;
                    }

                    PedidoDAL pedD = new PedidoDAL();
                    Pedido ped = pedD.PesquisarPedidoMA();
                    protocolo = ped.NumPedido += 1;
                    txtProtocolo.Text = DateTime.Today.Year + "." + Convert.ToString(p.ID) + "." + protocolo;

                    PanelSaida.Visible = true;
                    grdSaida.DataSource = dr;
                    grdSaida.DataBind();

                }
            }
            catch (Exception ex)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (ddlAprovador.SelectedIndex == 0 || ddlID.SelectedIndex == 0)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = "Preencha todos os campos!";
                PanelSaida.Visible = true;
            }
            else
            {
                foreach (GridViewRow row in grdSaida.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[7].FindControl("chkSeleciona") as CheckBox);
                        if (chkRow.Checked)
                        {

                            int identrada = int.Parse(grdSaida.DataKeys[row.RowIndex].Values["PK_ENTRADA"].ToString());
                            int idproduto = int.Parse(grdSaida.DataKeys[row.RowIndex].Values["Codigo"].ToString());
                            int qtd = int.Parse(row.Cells[5].Text);
                            var valor = (TextBox)(grdSaida.Rows[row.RowIndex].Cells[6].FindControl("txtQtd"));
                            int qtdR = int.Parse(valor.Text.ToString());

                            if ((qtdR > 0) && (qtd > 0) && (qtdR <= qtd))
                            {
                                try
                                {
                                    Saida s = new Saida();
                                    s.Cod_Entrada = identrada;
                                    s.Cod_Produto = idproduto;
                                    s.QtdS = qtdR;
                                    s.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                                    s.Usuario = HttpContext.Current.Session["Nome_User"].ToString();
                                    s.NumPedido = txtProtocolo.Text;
                                    s.Liberador = ddlAprovador.SelectedValue.ToString();
                                    s.Recebedor = ddlRecebedor.SelectedValue;
                                    s.Autorizado = "NAO";
                                    s.StatusPedido = "AGUARDANDO";

                                    SaidaDAL sdal = new SaidaDAL();
                                    sdal.GravarMA(s);

                                    Entrada en = new Entrada();
                                    en.Cod_Entrada = identrada;

                                    EntradaDAL enD = new EntradaDAL();
                                    var dr = enD.SelecionaQTDSMA(identrada);

                                    if (dr.HasRows == false)
                                    {
                                        lblMsgW.Visible = true;
                                        lblMsgW.Text = "Erro!";
                                    }
                                    else
                                    {
                                        int quantidade;
                                        while (dr.Read())
                                        {
                                            quantidade = int.Parse(dr[0].ToString());
                                            en.QtdS = quantidade + qtdR;
                                        }
                                        enD.AtualizarQTDSMA(en);
                                    }

                                    PedidoDAL pedD = new PedidoDAL();
                                    Pedido ped = pedD.PesquisarPedidoMA();
                                    int pedido = ped.NumPedido += 1;
                                    pedD.AtualizarPedidoMA(pedido);

                                    lblMsgS.Visible = true;
                                    lblMsgW.Visible = false;
                                    lblMsgS.Text = "Saída registrada com sucesso!";
                                    i++;
                                    btnAdd.Attributes.Add("onclick", "return printing()");
                                    PanelSaida.Visible = false;
                                    ddlID.SelectedIndex = -1;
                                    Response.AddHeader("REFRESH", "3;URL=../Pages/reportOut.aspx?send=" + txtProtocolo.Text + "&id=" + txtID.Text + "&uf=MA" + "&rec=" + ddlRecebedor.SelectedItem.ToString() + "&apr=" + ddlAprovador.SelectedItem.ToString());
                                }
                                catch (Exception ex)
                                {
                                    lblMsgW.Visible = true;
                                    lblMsgW.Text = ex.Message;
                                    PanelSaida.Visible = true;
                                }
                            }
                            else
                            {
                                lblMsgW.Visible = true;
                                lblMsgW.Text = "Quantidade incorreta!";
                                PanelSaida.Visible = true;
                            }
                        }
                        else if (i < 1)
                        {
                            lblMsgW.Visible = true;
                            lblMsgW.Text = "Nenhum item selecionado!";
                            PanelSaida.Visible = true;
                        }
                    }
                }
            }
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