using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAL.Model
{
    public class Valida
    {
        public void VerificaLogin()
        {
            if (HttpContext.Current.Session["autenticado"] == null || HttpContext.Current.Session["autenticado"].ToString() != "OK")
            {
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Redirect("../Login.aspx?msg=Por favor, faça o login!");
            }
        }

        public string Sessao
        {
            set
            {
                HttpContext.Current.Session.Add("ID", value);
                HttpContext.Current.Session.Add("Nome_User", value);
                HttpContext.Current.Session.Add("Estado", value);
                HttpContext.Current.Session.Add("Controle", value);
            }
        }

        public string Logar()
        {
            string a = string.Empty;

            if (HttpContext.Current.Session["autenticado"] != null && HttpContext.Current.Session["autenticado"].ToString() == "OK")
            {
                a = string.Format("{0} / {1}",
                    HttpContext.Current.Session["Nome_User"].ToString(),
                    HttpContext.Current.Session["Controle"].ToString());
            }
            return a;
        }

        public void LimparCampos(Control controle)
        {
            foreach (Control cte in controle.Controls)
            {
                if (cte is TextBox)
                {
                    ((TextBox)cte).Text = string.Empty;
                }
                else if (cte.Controls.Count > 0)
                {
                    LimparCampos(cte);
                }
            }
        }
    }
}