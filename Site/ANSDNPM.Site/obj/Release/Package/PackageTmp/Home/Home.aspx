<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASANM.Site.Home.Home" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin featured content -->
    <div class="box">
        <div class="buffer">
            <h2>Notícias</h2>
            <asp:Literal ID="litImagemNoticia" runat="server" />
            <p><h2 class="title"><asp:Literal ID="litTituloNoticia" runat="server" /></h2></p>
        </div>
    </div>
    <!-- end featured content -->
    <!-- begin latest posts -->
    <div class="box">
        <ul class="homelist">
            <asp:Repeater ID="rptUltimasNoticias" runat="server">
                <ItemTemplate>
                    <%#getNoticia(Convert.ToInt32(Eval("IDNoticia")))%>
                </ItemTemplate>
            </asp:Repeater>

            <p>&nbsp;</p>

        </ul>
    </div>
    <!-- end latest posts -->

</asp:Content>