<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="Ouvidoria.aspx.cs" Inherits="ASANM.Site.Institucional.Ouvidoria" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin featured content -->
    <div class="box">
        <div class="buffer">
            <h2>Ouvidoria</h2>
            <div class="content">
                <p>O papel de Ouvidor da ANSDNPM, conforme apregoa seu estatuto, é exercido pela Vice Presidência.</p>
                <p>A Ouvidoria é responsável por acolher as críticas, sugestões e denúncias envolvendo os associados.</p>
                <p>Preencha o formulário abaixo para entrar em contato com a Ouvidoria da ANSDNPM:</p>
                <p>
                    <label for="txtNome">Nome: <asp:RequiredFieldValidator ID="rfvNome" ErrorMessage="<font style='color:red;'>campo obrigatório</font>" ControlToValidate="txtNome" SetFocusOnError="True" runat="server" /></label><br />
                    <asp:TextBox ID="txtNome" Width="400" runat="server" />
                </p>
                <p>
                    <label for="txtTelefone">Telefone:</label><br />
                    <asp:TextBox ID="txtTelefone" Width="400" runat="server" />
                </p>
                <p>
                    <label for="txtEmail">E-mail: <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="<font style='color:red;'>campo obrigatório</font>" ControlToValidate="txtEmail" SetFocusOnError="True" runat="server" /></label><br />
                    <asp:TextBox ID="txtEmail" Width="400" runat="server" />
                </p>
                <p>
                    <label for="txtMensagem">Mensagem: <asp:RequiredFieldValidator ID="rfvMensagem" ErrorMessage="<font style='color:red;'>campo obrigatório</font>" ControlToValidate="txtMensagem" SetFocusOnError="True" runat="server" /></label><br />
                    <asp:TextBox ID="txtMensagem" Width="400" Height="150" runat="server" />
                </p>
                <p><asp:Button ID="btnEnviar" Text="Enviar" OnClick="Enviar" runat="server" /></p>
            </div>
        </div>
    </div>
    <!-- end featured content -->

</asp:Content>
