<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="ASANM.Site.Contato.Contato" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin featured content -->
    <div class="box">
        <div class="buffer">
            <h2>Contato</h2>
            <div class="content">
                <p><b>Associação Nacional dos Servidores do DNPM</b></p>
                <p><b>Endereço:</b> Setor de Autarquias Norte, Quadra 01, Bloco B, Subsolo, Espaço Antônio Eleuterio de Souza<br /><b>CEP:</b> 70041-903</p>
                <p><b>Telefones:</b> (61)3312-6707 / (61)3312-6781<br /><b>Fax:</b> (61)3312-6781</p>
                <p><b>Presidente:</b> Andre Elias Marques<br /><b>E-mail:</b> presidencia@ansdnpm.org.br</p>
                <p>&nbsp;</p>
                <p>Preencha o formulário abaixo para entrar em contato com a ANSDNPM:</p>
                <p>&nbsp;</p>
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
                <p><asp:Button ID="btnEnviar" Text="Enviar" CausesValidation="true" OnClick="Enviar" runat="server" /></p>
            </div>
        </div>
    </div>
    <!-- end featured content -->

</asp:Content>
