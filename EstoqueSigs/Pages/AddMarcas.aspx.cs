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
    public partial class AddMarcas : System.Web.UI.Page
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
            if (txtMarca.Text == string.Empty)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = "Preencha o campo!";
            }
            else
            {
                try
                {
                    Marca m = new Marca();

                    m.NOME_MARCA = txtMarca.Text.ToUpper();

                    MarcaDAL md = new MarcaDAL();
                    md.Gravar(m);

                    lblMsgS.Visible = true;
                    lblMsgS.Text = "Marca cadastrado com sucesso!";
                    vld.LimparCampos(this);
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