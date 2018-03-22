<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="CadastrarGaleria.aspx.cs" Inherits="ASANM.Gestao.Galerias.CadastrarGaleria" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">



</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2"><div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div></div>
        <div class="col-md-10">
            <div class="content-box-large">
                <div class="panel panel-default">
                    <div class="panel-heading"><h4>Cadastrar Galeria</h4></div>
			  	    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
        							<label>Descrição <asp:RequiredFieldValidator ID="rfvDescricao" ErrorMessage="<font style='color:red;'>*</font>" ControlToValidate="txtDescricao" SetFocusOnError="True" runat="server" /></label>
                                    <asp:TextBox ID="txtDescricao" CssClass="form-control" MaxLength="100" runat="server" />
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

    

</asp:Content>