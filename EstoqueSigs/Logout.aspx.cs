using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstoqueSigs
{
    public partial class Logout : System.Web.UI.Page
    {
        public static void Verifica()
        {
            if (HttpContext.Current.Session["autenticado"] == null || HttpContext.Current.Session["autenticado"].ToString() != "OK")
            {
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Redirect("Login.aspx?msg=Por favor, faça o login!");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Verifica();

            if (Request.Cookies["Acesso"] != null)

                Response.Cookies["Acesso"].Expires = DateTime.Now.AddDays(-1);
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}