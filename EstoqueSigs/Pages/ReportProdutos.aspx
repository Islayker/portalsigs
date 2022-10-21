<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReportProdutos.aspx.cs" Inherits="EstoqueSigs.Pages.ReportProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
    <form id="Form" class="form-horizontal" data-toggle="validator" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 class="text-center">RELATÓRIO DE PRODUTOS</h3>
        <br />
        <br />
        <fieldset>
            <div class="col-md-10 col-md-offset-2">
                <div class="row">
    <div class="form-group">
      <label class="control-label col-md-2">Filtrar</label>
      <div class="col-md-5">
          <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" placeholder="Filtrar Material" Width="350px"></asp:TextBox>
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
    <div class="row">
            </div>
            </div>
        <legend class="text-center">Listagem de Produtos</legend>
      <div class="col-md-12">
          <div class="table-responsive">
<asp:GridView ID="grvProd" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" PageIndex="25">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Codigo" HeaderText="CÓDIGO"/>
                                    <asp:BoundField DataField="Status" HeaderText="STATUS" />
                                    <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO" />
                                    <asp:BoundField DataField="Modelo" HeaderText="MODELO" />
                                    <asp:BoundField DataField="Marca" HeaderText="MARCA" />
                                    <asp:BoundField DataField="Tipo" HeaderText="TIPO" />
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
    </div>
</div>
                   <br />
                <br />
                </div>
        </fieldset>
    </form>
        </div>
</asp:Content>
