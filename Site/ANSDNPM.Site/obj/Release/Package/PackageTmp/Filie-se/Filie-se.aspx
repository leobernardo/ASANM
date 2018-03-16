<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="Filie-se.aspx.cs" Inherits="ANSDNPM.Site.Filie_se.Filie_se" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin featured content -->
    <div class="box">
        <div class="buffer">
            <h2>Filie-se</h2>
            <div class="content">
                <p>Para filiar-se a ANSDNPM faça o download da ficha de filiação (link abaixo), imprima o arquivo em papel, preencha seus dados - <b>assine</b> - e envie <b><u>por malote ou correio</u></b> para o endereço abaixo <b>junto com uma cópia do contra cheque</b>.</p>

                <p>&nbsp;</p>
                
                <%=getFicha()%>

                <p>&nbsp;</p>

                <p><b>ANSDNPM<br />Setor de Autarquias Norte, Quadra 01, Bloco B, sala 35-S<br />CEP: 70041-903<br />Brasília/DF</b></p>
            </div>
        </div>
    </div>
    <!-- end featured content -->

</asp:Content>