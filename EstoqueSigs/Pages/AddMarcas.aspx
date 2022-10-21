<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AddMarcas.aspx.cs" Inherits="EstoqueSigs.Pages.AddMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
    <form id="Form" class="form-horizontal" data-toggle="validator" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 class="text-center">CADASTRO DE MARCAS</h3>
        <br />
        <br />
        <fieldset>
            <div class="col-md-6 col-md-offset-3 text-center">
    <div class="form-group">
      <label class="control-label col-md-3">Marca</label>
      <div class="col-md-9">
          <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" placeholder="Marca" Width="300px" data-error="Por favor, informe uma marca." required></asp:TextBox>
          <div class="help-block with-errors"></div>
      </div>
        </div>
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
        </fieldset>
        </form>
        </div>
</asp:Content>
