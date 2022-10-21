<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="OutEstoqueMG.aspx.cs" Inherits="EstoqueSigs.Pages.OutEstoqueMG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <form id="Form" class="form-horizontal" data-toggle="validator" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 class="text-center">SÁIDA DE MATERIAIS - ESTOQUE MG</h3>
        <br />
        <br />
        <fieldset>
            <div class="col-md-8 col-md-offset-2">
    <div class="form-group">
      <label class="control-label col-md-2">Projetos</label>
      <div class="col-md-10">
          <asp:DropDownList ID="ddlID" runat="server" CssClass="form-control" Width="500px" OnSelectedIndexChanged="ddlID_SelectedIndexChanged">
          </asp:DropDownList>
      </div>
        </div>
        <div class="form-group">
        <div class="col-md-6 col-md-offset-5">
          <asp:LinkButton ID="btnBuscar" CssClass="btn btn-sm btn-success" runat="server" TabIndex="6" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search">&emsp;Buscar</span></asp:LinkButton>
      </div>
        </div>
            <div class="form-group">
      <div class="col-md-6 col-md-offset-4">
            <asp:Label ID="lblMsgS" CssClass="alert alert-success" runat="server" Visible="False"></asp:Label>
          <asp:Label ID="lblMsgW" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
      </div>
        </div>
                <br />
       <asp:Panel runat="server" ID="PanelSaida" CssClass="panel" Visible="false" Width="100%">
           <div class="row">
            <fieldset>
                    <legend class="text-center">Informações do Projeto</legend>
    <div class="form-group">
        <label class="control-label col-md-1"></label>
      <div class="col-md-2">
          <asp:TextBox ID="txtID" runat="server" CssClass="form-control text-center" Width="100px" Enabled="false"></asp:TextBox>
      </div>
      <div class="col-md-2">
          <asp:TextBox ID="txtOS" runat="server" CssClass="form-control text-center" Width="100px" Enabled="false"></asp:TextBox>
      </div>
      <div class="col-md-7">
          <asp:TextBox ID="txtSite" runat="server" CssClass="form-control text-center" Width="350px" Enabled="false"></asp:TextBox>
      </div>
        </div>
    <div class="form-group">
        <label class="control-label col-md-1"></label>
      <div class="col-md-11">
          <asp:TextBox ID="txtLocalidade" runat="server" CssClass="form-control text-center" Width="620px" Enabled="false"></asp:TextBox>
      </div>
    </div>
                <br />
                <br />
                <legend class="text-center">Dados Liberação</legend>
    <div class="form-group">
              <label class="control-label col-md-4">Aprovador</label>
      <div class="col-md-8">
          <asp:DropDownList ID="ddlAprovador" runat="server" CssClass="form-control" Width="300px">
              <asp:ListItem Selected="True">-- Selecione o aprovador da saída  --</asp:ListItem>
              <asp:ListItem>ANDRÉ SALVESTRONI</asp:ListItem>
              <asp:ListItem>ADRIANO LIMA</asp:ListItem>
              <asp:ListItem>DANIEL MOREIRA</asp:ListItem>
              <asp:ListItem>EDIVAL JUNIOR</asp:ListItem>
              <asp:ListItem>WELLINGTON ANTONIO</asp:ListItem>
              <asp:ListItem>LEONARDO CRESPO</asp:ListItem>
              <asp:ListItem>MICHELL LIMA</asp:ListItem>
          </asp:DropDownList>
      </div>
        </div>
    <div class="form-group">
              <label class="control-label col-md-4">Recebedor</label>
      <div class="col-md-8">
          <asp:DropDownList ID="ddlRecebedor" runat="server" CssClass="form-control" Width="300px" DataSourceID="sqlRecebedor" DataTextField="RECEBEDOR" DataValueField="PK_RECEBEDOR">
          </asp:DropDownList>
<%--          <asp:SqlDataSource ID="sqlAzureRecebedorMG" runat="server" ConnectionString="<%$ ConnectionStrings:portalsigsdbAzure %>" SelectCommand="SELECT [PK_RECEBEDOR], [RECEBEDOR] FROM [TB_RECEBEDOR] WHERE ([ESTADO] = @ESTADO) ORDER BY [RECEBEDOR]">
              <SelectParameters>
                  <asp:Parameter DefaultValue="MG" Name="ESTADO" Type="String" />
              </SelectParameters>
          </asp:SqlDataSource>--%>
          <asp:SqlDataSource ID="sqlRecebedor" runat="server" ConnectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=portalsigsdb;Persist Security Info=True;User ID=sa;Password=Portal@2022" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [PK_RECEBEDOR], [RECEBEDOR] FROM [TB_RECEBEDOR] WHERE ([ESTADO] = @ESTADO)">
              <SelectParameters>
                  <asp:Parameter DefaultValue="MG" Name="ESTADO" Type="String" />
              </SelectParameters>
          </asp:SqlDataSource>
      </div>
        </div>
    <div class="form-group">
              <label class="control-label col-md-4">Protocolo</label>
      <div class="col-md-8">
            <asp:TextBox ID="txtProtocolo" runat="server" CssClass="form-control text-center" Width="250px" Enabled="false"></asp:TextBox>
      </div>
        </div>
                <br />
                <br />
                    </fieldset>
           </div>
    <div class="row">
        <legend class="text-center">Materiais Disponíveis</legend>
      <div class="col-md-12">
          <div class="table-responsive">
<asp:GridView ID="grdSaida" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover" DataKeyNames="PK_ENTRADA,Codigo" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="PK_ENTRADA" HeaderText="IDENTRADA" Visible="False"/>
                                    <asp:BoundField DataField="Codigo" HeaderText="IDPRODUTO" Visible="False" />
                                    <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO" />
                                    <asp:BoundField DataField="MODELO" HeaderText="MODELO" />
                                    <asp:BoundField DataField="Marca" HeaderText="MARCA" />
                                    <asp:BoundField DataField="QTD" HeaderText="QTD" />
                                    <asp:TemplateField HeaderText="QTD SAÍDA">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQtd" runat="server" Width="40px" onkeyup="formataInteiro(this,event)" MaxLength="4"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Selecione">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSeleciona" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
            <div class="form-group">
      <div class="col-md-6 col-md-offset-4">
        <asp:LinkButton ID="btnAdd" CssClass="btn btn-sm btn-success" runat="server" TabIndex="6" OnClick="btnAdd_Click"><span class="glyphicon glyphicon-ok">&emsp;Inserir</span></asp:LinkButton>
        <asp:LinkButton ID="btnLimpar" CssClass="btn btn-sm btn-default" runat="server" TabIndex="7" OnClick="btnLimpar_Click"><span class="">Limpar</span></asp:LinkButton>
          <asp:LinkButton ID="btnVoltar" CssClass="btn btn-sm btn-info" runat="server" TabIndex="7" OnClick="btnVoltar_Click"><span class="">Voltar</span></asp:LinkButton>
      </div>
        </div>
                    </asp:Panel>
                </div>
        </fieldset>
    </form>
        </div>
</asp:Content>
