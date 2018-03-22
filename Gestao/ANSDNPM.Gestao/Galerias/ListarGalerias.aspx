<%@ Page Title="[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="ListarGalerias.aspx.cs" Inherits="ASANM.Gestao.Galerias.ListarGalerias" %>

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
      				<div class="panel-heading"><h4>Galerias</h4></div>
  			    	<div class="panel-body">
                        <asp:Button ID="btnCadastrarGaleria" CssClass="btn btn-primary btn-sm" Text="Cadastrar Galeria" OnClick="CadastrarGaleria" runat="server" />
                        <p>&nbsp;</p>
  					    <table class="table table-striped table-bordered" id="dataTable">
						    <thead>
							    <tr>
								    <th>Descrição</th>
								    <th>Ativa</th>
								    <th>Opções</th>
							    </tr>
						    </thead>
						    <tbody>
                                <asp:Repeater ID="rptGalerias" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("DSGaleria")%></td>
                                            <td><%#getAtivo(Convert.ToBoolean(Eval("BTAtiva")))%></td>
                                            <td><a href="FotosGaleria.aspx?idGlr=<%#Eval("IDGaleria")%>" class="fotosGaleria"><span class="glyphicon glyphicon-camera" style="margin-right:10px"></span></a><a href="AlterarGaleria.aspx?idGlr=<%#Eval("IDGaleria")%>" data-toggle="tooltip" data-placement="top" title="Alterar Galeria"><span class="glyphicon glyphicon-pencil" style="margin-right:10px"></span></a><a href="#" onclick="return confirmaExclusao(this, <%#Eval("IDGaleria")%>);" data-toggle="tooltip" data-placement="top" title="Excluir Galeria"><span class="glyphicon glyphicon-trash"></span></a></td>
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
                message: 'Você tem certeza que deseja excluir esta galeria?',
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
                        window.location.href = "ListarGalerias.aspx?act=exc&idGlr=" + id;
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
                  { "sWidth": "80%" },
                  { "sWidth": "10%" },
                  { "sWidth": "10%" }
                ]
            });
        });

        $(".fotosGaleria").fancybox({
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