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
    public partial class reportOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblprotocolo.Text = Request.QueryString["send"].ToString();

            if ((Request.QueryString["send"] != null) && (Request.QueryString["uf"] != null))
            {
                string UF = Request.QueryString["uf"].ToString();
                if (UF == "ES")
                {
                    this.BuscaES();
                }
                else if (UF == "MG")
                {
                    this.BuscaMG();
                }
                else if (UF == "MA")
                {
                    this.BuscaMA();
                }
                else if (UF == "PA")
                {
                    this.BuscaPA();
                }
                else if (UF == "RJ")
                {
                    this.BuscaRJ();
                }
            }
            else
            {
                Response.Redirect("../Index.aspx");
            }
        }

        public void BuscaES()
        {
            string protocolo = Request.QueryString["send"].ToString();
            int ID = Convert.ToInt32(Request.QueryString["id"].ToString());

                ProjetosDAL pjd = new ProjetosDAL();
                Projetos p = pjd.MG(ID);

                if (p != null)
                {
                    txtID.Text = Convert.ToString(p.ID);
                    txtOS.Text = Convert.ToString(p.OS);
                    txtSite.Text = p.UF + " - " + p.Site;
                    txtLocalidade.Text = p.Localidade;
                }

                Saida s = new Saida();
                s.NumPedido = protocolo;

                SaidaDAL sDal = new SaidaDAL();
                var dr = sDal.reportES(protocolo);
                                
                grdReport.DataSource = dr;
                grdReport.DataBind();

                txtAprovador.Text = Request.QueryString["apr"].ToString();
                txtRecebedor.Text = Request.QueryString["rec"].ToString();
                txtProtocolo.Text = protocolo;  
        }

        public void BuscaMG()
        {
            string protocolo = Request.QueryString["send"].ToString();
            int ID = Convert.ToInt32(Request.QueryString["id"].ToString());

            ProjetosDAL pjd = new ProjetosDAL();
            Projetos p = pjd.MG(ID);

            if (p != null)
            {
                txtID.Text = Convert.ToString(p.ID);
                txtOS.Text = Convert.ToString(p.OS);
                txtSite.Text = p.UF + " - " + p.Site;
                txtLocalidade.Text = p.Localidade;
            }

            Saida s = new Saida();
            s.NumPedido = protocolo;

            SaidaDAL sDal = new SaidaDAL();
            var dr = sDal.reportMG(protocolo);

            grdReport.DataSource = dr;
            grdReport.DataBind();

            txtAprovador.Text = Request.QueryString["apr"].ToString();
            txtRecebedor.Text = Request.QueryString["rec"].ToString();
            txtProtocolo.Text = protocolo;
        }

        public void BuscaMA()
        {
            string protocolo = Request.QueryString["send"].ToString();
            int ID = Convert.ToInt32(Request.QueryString["id"].ToString());

            ProjetosDAL pjd = new ProjetosDAL();
            Projetos p = pjd.MG(ID);

            if (p != null)
            {
                txtID.Text = Convert.ToString(p.ID);
                txtOS.Text = Convert.ToString(p.OS);
                txtSite.Text = p.UF + " - " + p.Site;
                txtLocalidade.Text = p.Localidade;
            }

            Saida s = new Saida();
            s.NumPedido = protocolo;

            SaidaDAL sDal = new SaidaDAL();
            var dr = sDal.reportMA(protocolo);

            grdReport.DataSource = dr;
            grdReport.DataBind();

            txtAprovador.Text = Request.QueryString["apr"].ToString();
            txtRecebedor.Text = Request.QueryString["rec"].ToString();
            txtProtocolo.Text = protocolo;
        }

        public void BuscaPA()
        {
            string protocolo = Request.QueryString["send"].ToString();
            int ID = Convert.ToInt32(Request.QueryString["id"].ToString());

            ProjetosDAL pjd = new ProjetosDAL();
            Projetos p = pjd.MG(ID);

            if (p != null)
            {
                txtID.Text = Convert.ToString(p.ID);
                txtOS.Text = Convert.ToString(p.OS);
                txtSite.Text = p.UF + " - " + p.Site;
                txtLocalidade.Text = p.Localidade;
            }

            Saida s = new Saida();
            s.NumPedido = protocolo;

            SaidaDAL sDal = new SaidaDAL();
            var dr = sDal.reportPA(protocolo);

            grdReport.DataSource = dr;
            grdReport.DataBind();

            txtAprovador.Text = Request.QueryString["apr"].ToString();
            txtRecebedor.Text = Request.QueryString["rec"].ToString();
            txtProtocolo.Text = protocolo;
        }

        public void BuscaRJ()
        {
            string protocolo = Request.QueryString["send"].ToString();
            int ID = Convert.ToInt32(Request.QueryString["id"].ToString());

            ProjetosDAL pjd = new ProjetosDAL();
            Projetos p = pjd.MG(ID);

            if (p != null)
            {
                txtID.Text = Convert.ToString(p.ID);
                txtOS.Text = Convert.ToString(p.OS);
                txtSite.Text = p.UF + " - " + p.Site;
                txtLocalidade.Text = p.Localidade;
            }

            Saida s = new Saida();
            s.NumPedido = protocolo;

            SaidaDAL sDal = new SaidaDAL();
            var dr = sDal.reportRJ(protocolo);

            grdReport.DataSource = dr;
            grdReport.DataBind();

            txtAprovador.Text = Request.QueryString["apr"].ToString();
            txtRecebedor.Text = Request.QueryString["rec"].ToString();
            txtProtocolo.Text = protocolo;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}