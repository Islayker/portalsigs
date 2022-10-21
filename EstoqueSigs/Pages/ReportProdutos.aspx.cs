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
    public partial class ReportProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreencherGrid();
        }

        public void PreencherGrid()
        {
            try
            {
                string desc = txtDesc.Text;

                ProdutoDAL pd = new ProdutoDAL();
                var dt = pd.Drop(desc);

                if (pd != null)
                {
                    grvProd.DataSource = dt;
                    grvProd.DataBind();
                }
                else
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = "Nenhum produto encontrado!";
                }
            }
            catch (Exception ex)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = ex.Message;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.PreencherGrid();
        }
    }
}