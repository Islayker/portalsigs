<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportOut.aspx.cs" Inherits="EstoqueSigs.Pages.reportOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" media="screen" />
</head>
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script language="javascript" type="text/javascript">
    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=100,toolbar=0,scrollbars=0,status=0,dir=ltr');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
</script>
<body>
<div class="container" id="bill">
    <form id="Form" class="form-horizontal" data-toggle="validator" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 class="text-center">RELATÓRIO DE SÁIDA DE MATERIAIS - PROTOCOLO <asp:Label ID="lblprotocolo" runat="server"></asp:Label></h3>
            <div class="col-md-8 col-md-offset-2">
                <br />
           <div class="row">
            <fieldset>
                    <legend class="text-center">Informações Gerais</legend>
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
                </fieldset>
                </div>
                <div class="row">
                <br />
                <br />
                    <fieldset>
                <legend class="text-center">Dados Liberação</legend>
    <div class="form-group">
              <label class="control-label col-md-4">Aprovador</label>
      <div class="col-md-8">
            <asp:TextBox ID="txtAprovador" runat="server" CssClass="form-control text-center" Width="250px" Enabled="false"></asp:TextBox>
      </div>
        </div>
    <div class="form-group">
              <label class="control-label col-md-4">Recebedor</label>
      <div class="col-md-8">
            <asp:TextBox ID="txtRecebedor" runat="server" CssClass="form-control text-center" Width="250px" Enabled="false"></asp:TextBox>
      </div>
        </div>
    <div class="form-group">
              <label class="control-label col-md-4">Protocolo</label>
      <div class="col-md-8">
            <asp:TextBox ID="txtProtocolo" runat="server" CssClass="form-control text-center" Width="250px" Enabled="false"></asp:TextBox>
      </div>
        </div>
                        </fieldset>
                    </div>
                <div class="row">
                <br />
                <br />          
                    <legend class="text-center">Materiais Retirados</legend>
      <div class="col-md-12">
          <div class="table-responsive">
<asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="false" CellPadding="4" CssClass="table table-striped table-bordered table-hover" DataKeyNames="PK_SAIDA,Codigo" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" Visible="true">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="PK_SAIDA" HeaderText="IDSAIDA" Visible="False"/>
                                    <asp:BoundField DataField="Codigo" HeaderText="IDPRODUTO" Visible="False" />
                                    <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO" />
                                    <asp:BoundField DataField="MODELO" HeaderText="MODELO" />
                                    <asp:BoundField DataField="Marca" HeaderText="MARCA" />
                                    <asp:BoundField DataField="QTDS" HeaderText="QTD" />
                                    <asp:BoundField DataField="LIBERADOR" HeaderText="LIBERADOR" Visible="False" />
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
                <br />
            <div class="form-group">
      <div class="col-md-6 col-md-offset-4">
          <asp:LinkButton ID="btnPrint" CssClass="btn btn-sm btn-success" runat="server" TabIndex="6" OnClick="btnPrint_Click" onclientclick="javascript:CallPrint('bill');"><span class="glyphicon glyphicon-ok">&emsp;Imprimir</span></asp:LinkButton>
        <asp:LinkButton ID="btnVoltar" CssClass="btn btn-sm btn-info" runat="server" TabIndex="6" OnClick="btnVoltar_Click"><span class="glyphicon glyphicon-ok">&emsp;Voltar</span></asp:LinkButton>
      </div>
        </div>
                
                 </div>
        </form>
        </div>
</body>
</html>
