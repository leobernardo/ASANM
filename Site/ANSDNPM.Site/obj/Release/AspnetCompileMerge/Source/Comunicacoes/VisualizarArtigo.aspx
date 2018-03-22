<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="VisualizarArtigo.aspx.cs" Inherits="ASANM.Site.Comunicacoes.VisualizarArtigo" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Artigos</h2>
            <div class="content">
                <h3><asp:Literal ID="litTitulo" runat="server" /></h3>

                <p><asp:Literal ID="litCorpo" runat="server" /></p>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>