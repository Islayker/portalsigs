<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReportEstoqueGeral.aspx.cs" Inherits="EstoqueSigs.Pages.ReportEstoqueGeral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function PrintPage() {
            var printContent = document.getElementById
            ('<%= pnlGridView.ClientID %>');
            var printWindow = window.open("All Records", 
            "Print Panel", 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="bill">
    <form id="Form" class="form-horizontal" data-toggle="validator" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 class="text-center">RELATÓRIO ESTOQUE GERAL</h3>
        <br />
        <br />
        <fieldset>
            <div class="col-md-10 col-md-offset-2">
                <div class="row">
    <div class="form-group">
      <label class="control-label col-md-2">Filtrar</label>
      <div class="col-md-5">
           <asp:DropDownList ID="ddlOrigem" runat="server" CssClass="form-control" Width="350px">
              <asp:ListItem Selected="True">Selecione a Estoque</asp:ListItem>
              <asp:ListItem>ESTOQUE ES</asp:ListItem>
              <asp:ListItem>ESTOQUE MA</asp:ListItem>
              <asp:ListItem>ESTOQUE MG</asp:ListItem>
              <asp:ListItem>ESTOQUE PA</asp:ListItem>
              <asp:ListItem>ESTOQUE RJ</asp:ListItem>
          </asp:DropDownList>
          </div>
        <div class="col-md-2">
          <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-sm btn-success" runat="server" TabIndex="6" OnClick="btnFiltrar_Click"><span class="glyphicon glyphicon-filter">&emsp;Filtrarr</span></asp:LinkButton>
      </div>
        </div>
            <div class="form-group">
      <div class="col-md-6 col-md-offset-4">
            <asp:Label ID="lblMsgS" CssClass="alert alert-success" runat="server" Visible="False"></asp:Label>
          <asp:Label ID="lblMsgW" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
      </div>
        </div>
                <br />
                    </div>
            </div>
      <div class="col-md-12">
                    <asp:LinkButton ID="btnPrint" CssClass="btn btn-sm btn-success" runat="server" TabIndex="6" onclientclick="PrintPage()"><span class="glyphicon glyphicon-ok">&emsp;Imprimir</span></asp:LinkButton>
          <asp:Panel runat="server" ID="pnlGridView">
         <div class="table-responsive">
<asp:GridView ID="grvEstoque" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" PageIndex="25">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO" />
                                    <asp:BoundField DataField="QTD" HeaderText="QTD" />
                                </Columns>
                                <EditRowStyle BackColor="#1C5E55" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#007c7a" Font-Bold="True" Font-Names="Calibri" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>

      </div>
              </asp:Panel>
    </div>
            </form>
</div>
</asp:Content>
