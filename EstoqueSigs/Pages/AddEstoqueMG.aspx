<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AddEstoqueMG.aspx.cs" Inherits="EstoqueSigs.Pages.AddEstoqueMG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <form id="Form" class="form-horizontal" data-toggle="validator" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 class="text-center">ENTRADA DE MATERIAIS - ESTOQUE MG</h3>
        <br />
        <br />
        <fieldset>
            <div class="col-md-6 col-md-offset-3">
    <div class="form-group">
      <label class="control-label col-md-2">Filtrar</label>
      <div class="col-md-8">
          <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" placeholder="Filtrar Material" Width="350px" data-error="Por favor, informe uma descrição." required></asp:TextBox>
          <div class="help-block with-errors"></div>
          </div>
        <div class="col-md-2">
          <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-sm btn-success" runat="server" TabIndex="6" OnClick="btnFiltrar_Click"><span class="glyphicon glyphicon-filter">&emsp;Filtrarr</span></asp:LinkButton>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Material</label>
      <div class="col-md-6">
          <asp:DropDownList ID="ddlMaterial" runat="server" CssClass="form-control" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterial_SelectedIndexChanged"></asp:DropDownList>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Marca</label>
      <div class="col-md-10">
        <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" Width="200px" Enabled="false"></asp:TextBox>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Modelo</label>
      <div class="col-md-10">
        <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" Width="200px" Enabled="false"></asp:TextBox>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Qtd</label>
      <div class="col-md-10">
        <asp:TextBox ID="txtQtd" runat="server" CssClass="somenteNumero form-control" MaxLength="8" onkeyup="formataInteiro(this,event)" Width="100px"></asp:TextBox>
      </div>
        </div>
    <div class="form-group">
              <label class="control-label col-md-2">NF</label>
      <div class="col-md-4">
        <asp:TextBox ID="txtNF" runat="server" CssClass="form-control" Width="200px" MaxLength="20" data-error="Informe a Nota fiscal." required></asp:TextBox>
          <div class="help-block with-errors"></div>
      </div>
        </div>
    <div class="form-group">
              <label class="control-label col-md-2">Origem</label>
      <div class="col-md-10">
          <asp:DropDownList ID="ddlOrigem" runat="server" CssClass="form-control" Width="400px">
              <asp:ListItem Selected="True">Selecione a Origem do Equipamento</asp:ListItem>
              <asp:ListItem>DESINSTALAÇÃO</asp:ListItem>
              <asp:ListItem>EMPRÉSTIMO</asp:ListItem>
              <asp:ListItem>ESTOQUE ES</asp:ListItem>
              <asp:ListItem>ESTOQUE MA</asp:ListItem>
              <asp:ListItem>ESTOQUE MG</asp:ListItem>
              <asp:ListItem>ESTOQUE PA</asp:ListItem>
              <asp:ListItem>ESTOQUE RJ</asp:ListItem>
              <asp:ListItem>FORNECEDOR</asp:ListItem>
          </asp:DropDownList>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Projeto</label>
      <div class="col-md-10">
          <asp:DropDownList ID="ddlID" runat="server" CssClass="form-control" Width="400px">
          </asp:DropDownList>
      </div>
        </div>
    <div class="form-group">
      <label class="control-label col-md-2">Data</label>
      <div class="col-md-10">
          <asp:TextBox ID="txtData" runat="server" CssClass="form-control" Width="150px" MaxLength="10" placeholder="MM/DD/AAAA" onkeyup="formataData(this,event)" data-error="Informe a Data." required TextMode="Date"></asp:TextBox>
          <div class="help-block with-errors"></div>
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
