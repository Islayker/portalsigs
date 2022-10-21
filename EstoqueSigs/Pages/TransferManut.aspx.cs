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
    public partial class TransferManut : System.Web.UI.Page
    {
        Valida vld = new Valida();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PreencherGrid()
        {
            string estoque = ddlOrigem.SelectedValue;

            try
            {
                EstoqueDAL estDAL = new EstoqueDAL();

                var dr = estDAL.BuscaEstoque(estoque);

                if (dr.HasRows == false)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = "Nenhum material encontrado!";
                }
                else
                {
                    txtProtocolo.Text = DateTime.Today.Day + "" + DateTime.Today.Month + "" + DateTime.Today.Year + "." + DateTime.Now.Millisecond;

                    PanelSaida.Visible = true;
                    grdEstoque.DataSource = dr;
                    grdEstoque.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsgW.Visible = true;
                lblMsgW.Text = ex.Message;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.PreencherGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

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