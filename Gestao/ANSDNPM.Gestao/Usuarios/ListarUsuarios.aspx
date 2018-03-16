<%@ Page Title="[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="ANSDNPM.Gestao.Usuarios.ListarUsuarios" %>

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
      				<div class="panel-heading"><h4>Usuários</h4></div>
  			    	<div class="panel-body">
                        <asp:Button ID="btnCadastrarUsuario" CssClass="btn btn-primary btn-sm" Text="Cadastrar Usuário" OnClick="CadastrarUsuario" runat="server" />
                        <p>&nbsp;</p>
  					    <table class="table table-striped table-bordered" id="dataTable">
						    <thead>
							    <tr>
								    <th>Nome</th>
								    <th>Login</th>
                                    <th>Ativo</th>
								    <th>Opções</th>
							    </tr>
						    </thead>
						    <tbody>
                                <asp:Repeater ID="rptUsuarios" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("DSNome")%></td>
                                            <td><%#Eval("DSLogin")%></td>
                                            <td><%#getAtivo(Convert.ToBoolean(Eval("BTAtivo")))%></td>
                                            <td><a href="AlterarSenhaUsuario.aspx?idUsr=<%#Eval("IDUsuario")%>" data-toggle="tooltip" data-placement="top" title="Alterar Senha do Usuário"><span class="glyphicon glyphicon-lock" style="margin-right:10px"></span></a><a href="AlterarUsuario.aspx?idUsr=<%#Eval("IDUsuario")%>" data-toggle="tooltip" data-placement="top" title="Alterar Usuário"><span class="glyphicon glyphicon-pencil" style="margin-right:10px"></span></a><a href="#" onclick="return confirmaExclusao(this, <%#Eval("IDUsuario")%>);" data-toggle="tooltip" data-placement="top" title="Excluir Usuário"><span class="glyphicon glyphicon-trash"></span></a></td>
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
                message: 'Você tem certeza que deseja excluir este usuário?',
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
                        window.location.href = "ListarUsuarios.aspx?act=exc&idUsr=" + id;
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
                  { "sWidth": "40%" },
                  { "sWidth": "40%" },
                  { "sWidth": "10%" },
                  { "sWidth": "10%" }
                ]
            });
        });
    </script>

</asp:Content>