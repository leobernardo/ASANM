﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ANSDNPM.Gestao.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Bootstrap -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- styles -->
    <link href="css/styles.css" rel="stylesheet">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form runat="server">

    <div class="header">
	     <div class="container">
	        <div class="row">
	           <div class="col-md-12">
	              <!-- Logo -->
	              <div class="logo"><h1><a href="../Home/Default.aspx">ANSDNPM</a></h1></div>
	           </div>
	        </div>
	     </div>
	</div>

	<div class="page-content container">
		<div class="row">
			<div class="col-md-4 col-md-offset-4">
				<div class="login-wrapper">
			        <div class="box">
			            <div class="content-wrap">
			                <h6>Login</h6>
                            <asp:TextBox ID="txtLogin" CssClass="form-control" runat="server" />
                            <asp:TextBox ID="txtSenha" CssClass="form-control" TextMode="Password" runat="server" />
			                <div class="action">
                                <asp:Button ID="btnEntrar" CssClass="btn btn-primary signup" Text="Entrar" OnClick="Entrar" runat="server" />
			                    <%--<a class="btn btn-primary signup" href="index.html">Login</a>--%>
			                </div>                
			            </div>
			        </div>
			    </div>
			</div>
		</div>
	</div>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://code.jquery.com/jquery.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="js/custom.js"></script>

    <script>
        $(function () {
            $("#txtLogin").attr("placeholder", "Login");
            $("#txtSenha").attr("placeholder", "Senha");
        });
    </script>

    </form>
</body>
</html>