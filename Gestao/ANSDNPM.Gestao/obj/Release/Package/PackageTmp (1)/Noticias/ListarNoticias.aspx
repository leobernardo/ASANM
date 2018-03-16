<%@ Page Title="[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="ListarNoticias.aspx.cs" Inherits="ANSDNPM.Gestao.Noticias.ListarNoticias" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">

    <!-- DataTables -->
    <link href="../vendors/datatables/css/dataTables.bootstrap.css" rel="stylesheet" />

</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2"><div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div></div>
        <div class="col-md-10">
            <div class="content-box-large">
                <div class="panel panel-default">
      				<div class="panel-heading"><h4>Notícias</h4></div>
  			    	<div class="panel-body">
                        <asp:Button ID="btnCadastrarNoticia" CssClass="btn btn-primary btn-sm" Text="Cadastrar Notícia" OnClick="CadastrarNoticia" runat="server" />
                        <p>&nbsp;</p>
  					    <table class="table table-striped table-bordered" id="dataTable">
						    <thead>
							    <tr>
								    <th>Título</th>
								    <th>Ativo</th>
								    <th>Opções</th>
							    </tr>
						    </thead>
						    <tbody>
                                <asp:Repeater ID="rptNoticias" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("DSTitulo")%></td>
                                            <td><%#getAtivo(Convert.ToBoolean(Eval("BTAtivo")))%></td>
                                            <td><a href="AlterarNoticia.aspx?idNtc=<%#Eval("IDNoticia")%>" data-toggle="tooltip" data-placement="top" title="Alterar Notícia"><span class="glyphicon glyphicon-pencil" style="margin-right:10px"></span></a><a href="#" onclick="return confirmaExclusao(this, <%#Eval("IDNoticia")%>);" data-toggle="tooltip" data-placement="top" title="Excluir Notícia"><span class="glyphicon glyphicon-trash"></span></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
						    </tbody>
					    </table>
  				    </div>
                </div>
  			</div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" runat="server">

    <script src="../vendors/bootbox/bootbox.min.js"></script>
    <script src="../vendors/datatables/js/jquery.dataTables.min.js"></script>
    <script src="../vendors/datatables/dataTables.bootstrap.js"></script>
    <script src="../js/custom.js"></script>
    <script src="../js/tables.js"></script>

    <script>
        function confirmaExclusao(sender, id) {
            if ($(sender).attr("confirmed") == "true") { return true; }

            bootbox.confirm({
                title: 'Confirmar exclusão',
                message: 'Você tem certeza que deseja excluir esta notícia?',
                buttons: {
                    'cancel': {
                        label: 'Não',
                        className: 'btn-primary pull-left'
                    },
                    'confirm': {
                        label: 'Sim',
                        className: 'btn-danger pull-right'
                    }
                },
                callback: function (result) {
                    if (result) {
                        window.location.href = "ListarNoticias.aspx?act=exc&idNtc=" + id;
                    }
                }
            });

            return false;
        }

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
                    "sInfoFiltered": "(filtered from _MAX_ total records)",
                    "sSearch": "Pesquisar: "
                },
                "bAutoWidth": false,
                "aoColumns": [
                  { "sWidth": "80%" },
                  { "sWidth": "10%" },
                  { "sWidth": "10%" }
                ]
            });
        });
    </script>

</asp:Content>