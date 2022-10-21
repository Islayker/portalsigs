using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Persistense;

namespace EstoqueSigs.Pages
{
    public partial class AddProdutos : System.Web.UI.Page
    {
        Valida vld = new Valida();
        string controle;
        protected void Page_Load(object sender, EventArgs e)
        {
            vld.VerificaLogin();
            controle = HttpContext.Current.Session["Controle"].ToString();
            if (controle != "Administrador")
            {
                Response.Redirect("../Index.aspx");
            }
            lblMsgS.Visible = false;
            lblMsgW.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text == string.Empty || txtModelo.Text == string.Empty || ddlTipo.SelectedValue == "Selecione o tipo")
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = "Preencha todos os campos!";
            }
            else
            {
                try
                {
                    Produto p = new Produto();

                    p.Status = ddlStatus.SelectedValue.ToString().ToUpper();
                    p.Descricao = txtDesc.Text.ToUpper();
                    p.Modelo = txtModelo.Text.ToUpper();
                    p.Marca = ddlMarca.SelectedValue.ToString().ToUpper();
                    p.Tipo = ddlTipo.SelectedValue.ToString().ToUpper();

                    ProdutoDAL pd = new ProdutoDAL();
                    pd.Gravar(p);

                    lblMsgS.Visible = true;
                    lblMsgS.Text = "Produto cadastrado com sucesso!";
                    vld.LimparCampos(this);
                    ddlMarca.SelectedIndex = -1;
                    ddlTipo.SelectedIndex = -1;
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