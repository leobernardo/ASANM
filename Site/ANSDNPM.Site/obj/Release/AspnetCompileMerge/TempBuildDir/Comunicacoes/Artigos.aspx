<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="Artigos.aspx.cs" Inherits="ANSDNPM.Site.Comunicacoes.Artigos" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">



</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Artigos</h2>
            <div class="content">
                <ul class="homelist">
                    <asp:Repeater ID="rptArtigos" runat="server">
                        <ItemTemplate>
                            <li> <p>&nbsp;</p><a href="VisualizarArtigo.aspx?idArt=<%#Eval("IDArtigo")%>" class="title"><%#Eval("DSTitulo")%></a><p>&nbsp;</p><hr /></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>