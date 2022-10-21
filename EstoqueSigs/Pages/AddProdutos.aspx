<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AddProdutos.aspx.cs" Inherits="EstoqueSigs.Pages.AddProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <form id="Form" class="form-horizontal" data-toggle="validator" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 class="text-center">CADASTRO DE PRODUTOS</h3>
        <br />
        <br />
        <fieldset>
            <div class="col-md-6 col-md-offset-3 text-center">
    <div class="form-group">
      <label class="control-label col-md-2">Descrição</label>
      <div class="col-md-10">
          <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" placeholder="Descrição" Width="400px" data-error="Por favor, informe uma descrição." required></asp:TextBox>
          <div class="help-block with-errors"></div>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Modelo</label>
      <div class="col-md-10">
          <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" placeholder="Modelo" Width="400px" data-error="Por favor, informe um modelo." required></asp:TextBox>
          <div class="help-block with-errors"></div>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Marca</label>
      <div class="col-md-10">
          <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" Width="400px" DataSourceID="SqlDataSource1" DataTextField="NOME_MARCA" DataValueField="NOME_MARCA">
          </asp:DropDownList>
<%--          <asp:SqlDataSource ID="sqlAzureMarca" runat="server" ConnectionString="<%$ ConnectionStrings:portalsigsdb %>" SelectCommand="SELECT [NOME_MARCA] FROM [TB_MARCAS] ORDER BY [NOME_MARCA]"></asp:SqlDataSource>--%>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=portalsigsdb;User ID=sa;Password=Portal@2022" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [NOME_MARCA] FROM [TB_MARCAS] ORDER BY [NOME_MARCA]"></asp:SqlDataSource>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Tipo</label>
      <div class="col-md-10">
          <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" Width="400px">
              <asp:ListItem Selected="True">Selecione o tipo</asp:ListItem>
              <asp:ListItem>Apoio</asp:ListItem>
              <asp:ListItem>Alarme</asp:ListItem>
              <asp:ListItem>Cabo</asp:ListItem>
              <asp:ListItem>Controle de acesso</asp:ListItem>
              <asp:ListItem>Civil</asp:ListItem>
              <asp:ListItem>CFTV</asp:ListItem>
              <asp:ListItem>Energia</asp:ListItem>
              <asp:ListItem>Miscelanea</asp:ListItem>
              <asp:ListItem>OCR</asp:ListItem>
              <asp:ListItem>Infraestrutura</asp:ListItem>
              <asp:ListItem>Redes</asp:ListItem> 
          </asp:DropDownList>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Status</label>
      <div class="col-md-10">
          <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Width="400px">
              <asp:ListItem Value="A">Ativado</asp:ListItem>
              <asp:ListItem Value="D">Desativado</asp:ListItem>
          </asp:DropDownList>
      </div>
        </div>
                <br />
            <div class="form-group">
      <div class="col-lg-10 col-lg-offset-2">
            <asp:Label ID="lblMsgS" CssClass="alert alert-success" runat="server" Visible="False"></asp:Label>
          <asp:Label ID="lblMsgW" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
      </div>
        </div>
                <br />
            <div class="form-group">
      <div class="col-lg-10 col-lg-offset-2">
        <asp:LinkButton ID="btnAdd" CssClass="btn btn-sm btn-success" runat="server" TabIndex="6" OnClick="btnAdd_Click"><span class="glyphicon glyphicon-ok">&emsp;Inserir</span></asp:LinkButton>
        <asp:LinkButton ID="btnLimpar" CssClass="btn btn-sm btn-default" runat="server" TabIndex="7" OnClick="btnLimpar_Click"><span class="">Limpar</span></asp:LinkButton>
          <asp:LinkButton ID="btnVoltar" CssClass="btn btn-sm btn-info" runat="server" TabIndex="7" OnClick="btnVoltar_Click"><span class="">Voltar</span></asp:LinkButton>
      </div>
        </div>
                </div>
        </fieldset>
    </form>
        </div>
</asp:Content>
