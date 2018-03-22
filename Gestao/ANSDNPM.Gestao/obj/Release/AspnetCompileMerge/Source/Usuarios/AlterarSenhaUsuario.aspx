<%@ Page Title="[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="AlterarSenhaUsuario.aspx.cs" Inherits="ASANM.Gestao.Usuarios.AlterarSenhaUsuario" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">



</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2"><div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div></div>
        <div class="col-md-10">
            <div class="content-box-large">
                <div class="panel panel-default">
                    <div class="panel-heading"><h4>Alterar Senha do Usuário</h4></div>
			  	    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
        							<label>Nova senha <asp:RequiredFieldValidator ID="rfvNovaSenha" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtNovaSenha" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtNovaSenha" CssClass="form-control" MaxLength="15" TextMode="Password" runat="server" />
				        		</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
        							<label>Confirme a nova senha <asp:RequiredFieldValidator ID="rfvConfirmeNovaSenha" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtConfirmeNovaSenha" SetFocusOnError="True" runat="server" /><asp:CompareValidator ID="cvSenhas" ErrorMessage="<font style='color:red;'>Senhas não conferem</font>" ControlToValidate="txtNovaSenha" ControlToCompare="txtConfirmeNovaSenha" Type="String" runat="server" /></label>
                                    <asp:TextBox ID="txtConfirmeNovaSenha" CssClass="form-control" MaxLength="15" TextMode="Password" runat="server" />
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