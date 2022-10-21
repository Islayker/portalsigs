using DAL.Persistense;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstoqueSigs.Pages
{
    public partial class EstoqueGeral : System.Web.UI.Page
    {
        Valida vld = new Valida();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            ddlMaterial.Items.Clear();

            try
            {
                string desc = txtDesc.Text;

                ProdutoDAL pd = new ProdutoDAL();
                var dt = pd.Drop(desc);

                if (pd != null)
                {
                    ddlMaterial.Items.Insert(0, new ListItem("-- Selecione um Equipamento --", "0"));

                    while (dt.Read())
                    {
                        ListItem listItem = new ListItem();

                        listItem.Text = dt[2].ToString();
                        listItem.Value = dt[0].ToString();

                        ddlMaterial.Items.Add(listItem);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = ex.Message;
            }
        }

        protected void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(ddlMaterial.SelectedValue.ToString());

            ProdutoDAL pd = new ProdutoDAL();
            Produto p = pd.PesquisarporCodigo(codigo);

            if (p != null)
            {
                txtMarca.Text = p.Marca;
                txtModelo.Text = p.Modelo;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlMaterial.SelectedIndex == 0 || ddlDestino.SelectedIndex == 0 || ddlOrigem.SelectedIndex == 0 || txtData.Text == string.Empty)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = "Preencha todos os campos!";
            }
            else if (txtQtd.Text == "0" || txtQtd.Text == string.Empty)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = "Campo Qtd não pode ficar vazio ou zerado!";
            }
            else
            {
                try
                {
                    Estoque es = new Estoque();
                                        
                    es.FK_PRODUTO = Convert.ToInt32(ddlMaterial.SelectedValue.ToString());
                    es.QTDE = Convert.ToInt32(txtQtd.Text);
                    es.QTDS = 0;
                    es.Data = Convert.ToDateTime(txtData.Text);
                    es.Origem = ddlOrigem.SelectedValue.ToString();
                    es.Destino = ddlDestino.SelectedValue.ToString();
                    es.Usuario = HttpContext.Current.Session["Nome_User"].ToString();
                    es.Status = "EM ESTOQUE";
                    es.Obs = txtObs.Text;

                    EstoqueDAL esDAL = new EstoqueDAL();
                    esDAL.GravarGeral(es);

                    lblMsgS.Visible = true;
                    lblMsgS.Text = "Entrada cadastrada com sucesso!";
                    vld.LimparCampos(this);
                    ddlMaterial.Items.Clear();
                    ddlDestino.SelectedIndex = -1;
                    ddlOrigem.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = ex.Message;
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