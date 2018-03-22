<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="CadastrarConvenio.aspx.cs" Inherits="ASANM.Gestao.Convenios.CadastrarConvenio" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">



</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2"><div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div></div>
        <div class="col-md-10">
            <div class="content-box-large">
                <div class="panel panel-default">
                    <div class="panel-heading"><h4>Cadastrar Convênio</h4></div>
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
        							<label>Descrição <asp:RequiredFieldValidator ID="rfvDescricao" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtDescricao" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtDescricao" CssClass="form-control" TextMode="MultiLine" Height="350" runat="server" />
				        		</div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group">
        							<label>UF</label>
                                    <asp:DropDownList ID="ddlUF" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Nacional" Value="BR" />
                                        <asp:ListItem Text="AC" Value="AC" /><asp:ListItem Text="AL" Value="AL" />
                                        <asp:ListItem Text="AM" Value="AM" /><asp:ListItem Text="AP" Value="AP" />
                                        <asp:ListItem Text="BA" Value="BA" /><asp:ListItem Text="CE" Value="CE" />
                                        <asp:ListItem Text="DF" Value="DF" /><asp:ListItem Text="ES" Value="ES" />
                                        <asp:ListItem Text="GO" Value="GO" /><asp:ListItem Text="MA" Value="MA" />
                                        <asp:ListItem Text="MG" Value="MG" /><asp:ListItem Text="MS" Value="MS" />
                                        <asp:ListItem Text="MT" Value="MT" /><asp:ListItem Text="PA" Value="PA" />
                                        <asp:ListItem Text="PB" Value="PB" /><asp:ListItem Text="PE" Value="PE" />
                                        <asp:ListItem Text="PI" Value="PI" /><asp:ListItem Text="PR" Value="PR" />
                                        <asp:ListItem Text="RJ" Value="RJ" /><asp:ListItem Text="RN" Value="RN" />
                                        <asp:ListItem Text="RO" Value="RO" /><asp:ListItem Text="RR" Value="RR" />
                                        <asp:ListItem Text="RS" Value="RS" /><asp:ListItem Text="SC" Value="SC" />
                                        <asp:ListItem Text="SE" Value="SE" /><asp:ListItem Text="SP" Value="SP" />
                                        <asp:ListItem Text="TO" Value="TO" />
                                    </asp:DropDownList>
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

					    <div><asp:Button ID="btnCadastrar" CssClass="btn btn-primary" Text="Cadastrar" CausesValidation="true" OnClick="Cadastrar" runat="server" /></div>
			  	    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" runat="server">

    

</asp:Content>