﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarArquivoNotaTecnica.aspx.cs" Inherits="ASANM.Gestao.NotasTecnicas.CadastrarArquivoNotaTecnica" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Bootstrap -->
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- styles -->
    <link href="../css/styles.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->

    <style>
        body { overflow-x: hidden; }
    </style>
</head>
<body>
    <form runat="server">

    <div class="page-content">
        <div class="row">
            <div class="panel panel-default">
                    <div class="panel-heading"><h4>Cadastrar Arquivo da Nota Técnica</h4></div>
			  	    <div class="panel-body">

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
        							<label>Descrição <asp:RequiredFieldValidator ID="rfvDescricao" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtDescricao" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtDescricao" CssClass="form-control" runat="server" />
				        		</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Arquivo</label>
				                    <asp:FileUpload ID="txtArquivo" runat="server" />
                                </div>
                            </div>
                        </div>

					    <div><asp:Button ID="btnCadastrar" CssClass="btn btn-primary" Text="Cadastrar" CausesValidation="true" OnClick="Cadastrar" runat="server" /></div>
			  	    </div>
                </div>
        </div>
    </div>

    </form>

    <script src="../js/custom.js"></script>
    <script src="../js/tables.js"></script>
</body>
</html>
