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
    public partial class ReportID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsgW.Visible = false;
            lblMsgS.Visible = false;
            btnPrint.Visible = false;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.PreencherGrid();
        }

        public void PreencherGrid()
        {
            try
            {
                int desc = Convert.ToInt32(ddlID.SelectedValue.ToString());

                EntradaDAL pd = new EntradaDAL();
                var dt = pd.InventarioProjetosMG(desc);

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

        protected void grvEstoque_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text.Equals("0"))
                    e.Row.Visible = false;
            }
        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlUF.SelectedValue == "Minas Gerais")
            {
                try
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    var dt = pjd.DDLMG();

                    ddlID.DataSource = dt;
                    ddlID.DataTextField = "Agregado";
                    ddlID.DataValueField = "ID";
                    ddlID.DataBind();
                    ddlID.Items.Insert(0, new ListItem("-- Selecione um ID/OS --", "0"));
                }
                catch (Exception ex)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = ex.Message;
                }
            }
            else if(ddlUF.SelectedValue == "Espirito Santo")
            {
                try
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    var dt = pjd.DDLES();

                    ddlID.DataSource = dt;
                    ddlID.DataTextField = "Agregado";
                    ddlID.DataValueField = "ID";
                    ddlID.DataBind();
                    ddlID.Items.Insert(0, new ListItem("-- Selecione um ID/OS --", "0"));
                }
                catch (Exception ex)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = ex.Message;
                }
            }
            else if (ddlUF.SelectedValue == "Maranhão")
            {
                try
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    var dt = pjd.DDLMA();

                    ddlID.DataSource = dt;
                    ddlID.DataTextField = "Agregado";
                    ddlID.DataValueField = "ID";
                    ddlID.DataBind();
                    ddlID.Items.Insert(0, new ListItem("-- Selecione um ID/OS --", "0"));
                }
                catch (Exception ex)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = ex.Message;
                }
            }
            else if (ddlUF.SelectedValue == "Pará")
            {
                try
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    var dt = pjd.DDLPA();

                    ddlID.DataSource = dt;
                    ddlID.DataTextField = "Agregado";
                    ddlID.DataValueField = "ID";
                    ddlID.DataBind();
                    ddlID.Items.Insert(0, new ListItem("-- Selecione um ID/OS --", "0"));
                }
                catch (Exception ex)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = ex.Message;
                }
            }
            else if (ddlUF.SelectedValue == "Rio de Janeiro")
            {
                try
                {
                    ProjetosDAL pjd = new ProjetosDAL();
                    var dt = pjd.DDLRJ();

                    ddlID.DataSource = dt;
                    ddlID.DataTextField = "Agregado";
                    ddlID.DataValueField = "ID";
                    ddlID.DataBind();
                    ddlID.Items.Insert(0, new ListItem("-- Selecione um ID/OS --", "0"));
                }
                catch (Exception ex)
                {
                    lblMsgW.Visible = true;
                    lblMsgW.Text = ex.Message;
                }
            }
            else
            {
                    ddlID.DataSource = null;
                    ddlID.DataBind();
            }
        }
    }
}