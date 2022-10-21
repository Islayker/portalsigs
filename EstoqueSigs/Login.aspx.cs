using DAL.Persistense;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstoqueSigs
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Acesso"] != null && !IsPostBack)
            {
                txtLogin.Text = Request.Cookies["Acesso"]["Usuário"];
                txtSenha.Attributes.Add("value", Request.Cookies["Acesso"]["Senha"]);
            }

            if (Request.QueryString["msg"] != null)
            {
                lblMsg.Text = Request.QueryString["msg"];
            }

            txtLogin.Focus();
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;

            if (txtLogin.Text == string.Empty)
            {
                lblMsg.Text = "O campo Login é obrigatório!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtSenha.Text == string.Empty)
            {
                lblMsg.Text = "O campo Senha é obrigatório!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Usuarios user = new Usuarios();
                user.login = txtLogin.Text;
                user.senha = txtSenha.Text;

                UsuariosDAL userD = new UsuariosDAL();
                var dr = userD.SelecionaUsuario(user);

                if (dr.HasRows == false)
                {
                    lblMsg.Text = "Usuário não encontrado!";
                }
                else
                {
                    dr.Read();
                    Session["autenticado"] = "OK";
                    Session["Codigo_User"] = dr[0].ToString();
                    Session["Nome_User"] = dr[2].ToString();
                    Session["Controle"] = dr[5].ToString();
                    Server.Transfer("Index.aspx");
                }
            }
        }

    }
}