<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="ASANM.Site.Noticias.Noticias" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Notícias</h2>
            <div class="content">
                <ul class="homelist">
                    <asp:Repeater ID="rptNoticias" runat="server">
                        <ItemTemplate>
                            <li> <p>&nbsp;</p><a href="VisualizarNoticia.aspx?idNtc=<%#Eval("IDNoticia")%>" class="title"><%#Eval("DSTitulo")%></a><p>&nbsp;</p><hr /></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>