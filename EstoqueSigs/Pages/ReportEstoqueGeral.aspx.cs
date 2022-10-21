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
    public partial class ReportEstoqueGeral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
        }

        public void PreencherGrid()
        {
            try
            {
                string desc = ddlOrigem.SelectedValue.ToString();

                EstoqueDAL pd = new EstoqueDAL();
                var dt = pd.Inventario(desc);

                if (dt.HasRows == true)
                {
                    grvEstoque.DataSource = dt;
                    grvEstoque.DataBind();
                    btnPrint.Visible = true;
                }
                else
                {
                    grvEstoque.DataSource = null;
                    grvEstoque.DataBind();
                    btnPrint.Visible = false;
                    lblMsgW.Visible = true;
                    lblMsgW.Text = "Nenhum produto encontrado!";
                }
            }
            catch (Exception ex)
            {
                btnPrint.Visible = false;
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