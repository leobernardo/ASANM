<%@ Page Title="[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="ListarConvenios.aspx.cs" Inherits="ANSDNPM.Gestao.Convenios.ListarConvenios" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">

    <!-- DataTables -->
    <link href="../vendors/datatables/css/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- FancyBox -->
    <link href="../vendors/fancybox/jquery.fancybox.css?v=2.1.5" media="screen" rel="stylesheet" />

</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2"><div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div></div>
        <div class="col-md-10">
            <div class="content-box-large">
                <div class="panel panel-default">
      				<div class="panel-heading"><h4>Convênios</h4></div>
  			    	<div class="panel-body">
                        <asp:Button ID="btnCadastrarConvenio" CssClass="btn btn-primary btn-sm" Text="Cadastrar Convênio" OnClick="CadastrarConvenio" runat="server" />
                        <p>&nbsp;</p>
  					    <table class="table table-striped table-bordered" id="dataTable">
						    <thead>
							    <tr>
								    <th>Nome</th>
                                    <th>UF</th>
								    <th>Ativo</th>
								    <th>Opções</th>
							    </tr>
						    </thead>
						    <tbody>
                                <asp:Repeater ID="rptConvenios" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("NMConvenio")%></td>
                                            <td><%#Eval("UFConvenio")%></td>
                                            <td><%#getAtivo(Convert.ToBoolean(Eval("BTAtivo")))%></td>
                                            <td><a href="ArquivosConvenio.aspx?idCnv=<%#Eval("IDConvenio")%>" class="arquivosConvenio"><span class="glyphicon glyphicon-file" style="margin-right:10px"></span></a><a href="AlterarConvenio.aspx?idCnv=<%#Eval("IDConvenio")%>" data-toggle="tooltip" data-placement="top" title="Alterar Convênio"><span class="glyphicon glyphicon-pencil" style="margin-right:10px"></span></a><a href="#" onclick="return confirmaExclusao(this, <%#Eval("IDConvenio")%>);" data-toggle="tooltip" data-placement="top" title="Excluir Convênio"><span class="glyphicon glyphicon-trash"></span></a></td>
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

    <!-- FancyBox -->
    <script src="../vendors/fancybox/jquery.fancybox.js?v=2.1.5"></script>

    <script>
        function confirmaExclusao(sender, id) {
            if ($(sender).attr("confirmed") == "true") { return true; }

            bootbox.confirm({
                title: 'Confirmar exclusão',
                message: 'Você tem certeza que deseja excluir este convênio?',
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
                        window.location.href = "ListarConvenios.aspx?act=exc&idCnv=" + id;
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
                    "sInfoFiltered": "(filtrados de _MAX_ registros)",
                    "sSearch": "Pesquisar: "
                },
                "bAutoWidth": false,
                "aoColumns": [
                  { "sWidth": "70%" },
                  { "sWidth": "10%" },
                  { "sWidth": "10%" },
                  { "sWidth": "10%" }
                ]
            });
        });

        $(".arquivosConvenio").fancybox({
            'width': 950,
            'height': 600,
            'padding': 10,
            'autoScale': false,
            'type': 'iframe',
            autoSize: false,
            closeClick: false,
            openEffect: 'none',
            closeEffect: 'none',
            helpers: {
                overlay: {
                    opacity: 0.5,
                    css: { 'background': 'rgba(0, 0, 0, 0.5)' }
                }
            }
        });
    </script>

</asp:Content>