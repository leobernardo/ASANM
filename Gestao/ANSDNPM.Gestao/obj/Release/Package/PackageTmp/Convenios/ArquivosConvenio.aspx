<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArquivosConvenio.aspx.cs" Inherits="ANSDNPM.Gestao.Convenios.ArquivosConvenio" %>

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

    <!-- DataTables -->
    <link href="../vendors/datatables/css/dataTables.bootstrap.css" rel="stylesheet" />

    <style>
        body { overflow-x: hidden; }
    </style>
</head>
<body>
    <form runat="server">

    <div class="page-content">
        <div class="row">
            <div class="panel panel-default">
      			<div class="panel-heading"><h4>Arquivos do Convênio</h4></div>
  			    <div class="panel-body">
                    <asp:Button ID="btnCadastrarArquivoConvenio" CssClass="btn btn-primary btn-sm" Text="Cadastrar Arquivo do Convênio" OnClick="CadastrarArquivoConvenio" runat="server" />
                    <p>&nbsp;</p>
  					<table class="table table-striped table-bordered" id="dataTable">
						<thead>
							<tr>
								<th>Descrição</th>
								<th>Opções</th>
							</tr>
						</thead>
						<tbody>
                            <asp:Repeater ID="rptArquivosConvenio" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("DSArquivo")%></td>
                                        <td><a href="AlterarArquivoConvenio.aspx?idAcn=<%#Eval("IDArquivoConvenio")%>" data-toggle="tooltip" data-placement="top" title="Alterar Arquivo do Convênio"><span class="glyphicon glyphicon-pencil" style="margin-right:10px"></span></a><a href="ArquivosConvenio.aspx?act=exc&idAcn=<%#Eval("IDArquivoConvenio")%>" data-toggle="tooltip" data-placement="top" title="Excluir Arquivo do Convênio"><span class="glyphicon glyphicon-trash"></span></a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
						</tbody>
					</table>
  				</div>
            </div>
        </div>
    </div>

    </form>

    <script src="../vendors/bootbox/bootbox.min.js"></script>
    <script src="../vendors/datatables/js/jquery.dataTables.min.js"></script>
    <script src="../vendors/datatables/dataTables.bootstrap.js"></script>
    <script src="../js/custom.js"></script>
    <script src="../js/tables.js"></script>

    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();

            $('#dataTable').dataTable({
                "oLanguage": {
                    "oPaginate": {
                        "sFirst": "Primeira",
                        "sPrevious": "Anterior",
                        "sNext": "Próxima",
                        "sLast": "Última"
                    },
                    "sProcessing": "Processando...",
                    "sLengthMenu": "Mostrando _MENU_ registros por página",
                    "sZeroRecords": "Registro não encontrado",
                    "sInfo": "Mostrando _START_ até _END_ de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                    "sInfoFiltered": "(filtrados de _MAX_ registros)",
                    "sSearch": "Pesquisar: "
                },
                "bAutoWidth": false,
                "aoColumns": [
                  { "sWidth": "90%" },
                  { "sWidth": "10%" }
                ]
            });
        });
    </script>
</body>
</html>
