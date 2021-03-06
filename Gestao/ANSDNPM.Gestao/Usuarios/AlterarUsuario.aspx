﻿<%@ Page Title="[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="AlterarUsuario.aspx.cs" Inherits="ASANM.Gestao.Usuarios.AlterarUsuario" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">



</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2"><div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div></div>
        <div class="col-md-10">
            <div class="content-box-large">
                <div class="panel panel-default">
                    <div class="panel-heading"><h4>Alterar Usuário</h4></div>
			  	    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
        							<label>Nome <asp:RequiredFieldValidator ID="rfvNome" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtNome" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtNome" CssClass="form-control" MaxLength="100" runat="server" />
				        		</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
        							<label>Login <asp:RequiredFieldValidator ID="rfvLogin" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtLogin" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtLogin" CssClass="form-control" MaxLength="15" runat="server" />
				        		</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group">
							        <label class="control-label">Ativo?</label><br />
                                    <label class="control-label radio-inline">
                                        <asp:RadioButton ID="radAtivo_N" GroupName="radAtivo" Text="Não" Checked="true" runat="server" />
                                    </label>
                                    <label class="control-label radio-inline">
                                        <asp:RadioButton ID="radAtivo_S" GroupName="radAtivo" Text="Sim" runat="server" />
                                    </label>
						        </div>
                            </div>
                        </div>

					    <div><asp:Button ID="btnAlterar" CssClass="btn btn-primary" Text="Alterar" CausesValidation="true" OnClick="Alterar" runat="server" /></div>
			  	    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" runat="server">



</asp:Content>