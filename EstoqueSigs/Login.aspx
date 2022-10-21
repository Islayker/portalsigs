<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EstoqueSigs.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" media="screen" />
    <style>

#bg {
  position: fixed; 
  top: 0; 
  left: 0; 
  
  /* Preserve aspet ratio */
  min-width: 100%;
  min-height: 80%;
}

</style>
</head>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        window.setTimeout(function () {
            $(".alert").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 2000);

    });
</script>
<body>
    <img src="img/backg.png" id="bg" alt="">
        <div class="container" style="margin-top:10%">
    <div class="modal-dialog" style="margin:0 auto !important; width:300px">
        <div class="modal-content">
                    <div class="panel-heading">
                        <h3 class="panel-title">Bem vindo, faça o login para acessar.</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form" runat="server">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control input-lg" Width="250px" TabIndex="1" placeholder="Login"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                     <asp:TextBox ID="txtSenha" TextMode="Password" runat="server" CssClass="form-control input-lg" Width="250px" TabIndex="2" placeholder="Senha"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblMsg" CssClass="alert alert-warning" runat="server" Visible="False" TabIndex="3"></asp:Label>
                                    </div>
                                <div class="form-group">
                                <asp:LinkButton ID="btnEntrar" CssClass="btn btn-sm btn-success" runat="server" OnClick="btnEntrar_Click" TabIndex="4">Login</asp:LinkButton>
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
    </div>
    </div>
</body>
</html>
