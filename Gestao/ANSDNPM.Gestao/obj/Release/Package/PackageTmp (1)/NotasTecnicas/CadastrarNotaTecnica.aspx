﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="CadastrarNotaTecnica.aspx.cs" Inherits="ANSDNPM.Gestao.NotasTecnicas.CadastrarNotaTecnica" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">

    <link rel="stylesheet" type="text/css" href="../vendors/bootstrap-wysihtml5/src/bootstrap-wysihtml5.css" />

</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2"><div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div></div>
        <div class="col-md-10">
            <div class="content-box-large">
                <div class="panel panel-default">
                    <div class="panel-heading"><h4>Cadastrar Nota Técnica</h4></div>
			  	    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group">
        							<label>Ano</label>
                                    <asp:DropDownList ID="ddlAno" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="2015" Value="2015" />
                                        <asp:ListItem Text="2016" Value="2016" Selected="True" />
                                    </asp:DropDownList>
						        </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group">
        							<label>Número <asp:RequiredFieldValidator ID="rfvNumero" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtNumero" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" />
				        		</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
        							<label>Título <asp:RequiredFieldValidator ID="rfvTitulo" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtTitulo" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server" />
				        		</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
        							<textarea id="ckeditor_standard" name="ckeditor_standard"></textarea>
		        				</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group">
							        <label class="control-label">Ativa?</label><br />
                                    <label class="control-label radio-inline">
                                        <asp:RadioButton ID="radAtiva_N" GroupName="radAtiva" Text="Não" Checked="true" runat="server" />
                                    </label>
                                    <label class="control-label radio-inline">
                                        <asp:RadioButton ID="radAtiva_S" GroupName="radAtiva" Text="Sim" runat="server" />
                                    </label>
						        </div>
                            </div>
                        </div>

					    <div><asp:Button ID="btnCadastrar" CssClass="btn btn-primary" Text="Cadastrar" CausesValidation="true" OnClick="Cadastrar" runat="server" /></div>
			  	    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" runat="server">

    <script src="../vendors/bootstrap-wysihtml5/lib/js/wysihtml5-0.3.0.js"></script>
    <script src="../vendors/bootstrap-wysihtml5/src/bootstrap-wysihtml5.js"></script>

    <script src="../vendors/ckeditor/ckeditor.js"></script>
    <script src="../vendors/ckeditor/adapters/jquery.js"></script>

    <script src="../vendors/tinymce/js/tinymce/tinymce.min.js"></script>

    <script src="../js/custom.js"></script>
    <script src="../js/editors.js"></script>

</asp:Content>