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
    public partial class AddTeam : System.Web.UI.Page
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
            if(txtNome.Text == string.Empty || ddlCargo.SelectedIndex == 0 || ddlEstado.SelectedIndex == 0)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = "Preencha todos os campos!";
            }
            else
            {
                try
                {
                    Time t = new Time();
                    t.Recebedor = txtNome.Text.ToUpper();
                    t.Cargo = ddlCargo.SelectedValue;
                    t.UF = ddlEstado.SelectedValue;
                    TimeDAL tDal = new TimeDAL();
                    tDal.GravarRecebedor(t);

                    lblMsgS.Visible = true;
                    lblMsgS.Text = "Recebedor registrado com sucesso!";
                    vld.LimparCampos(this);
                    ddlCargo.SelectedIndex = -1;
                    ddlEstado.SelectedIndex = -1;
                }
                catch(Exception ex)
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