<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="VisualizarGaleria.aspx.cs" Inherits="ASANM.Site.Galerias.VisualizarGaleria" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Galerias</h2>
            <div class="content">
                <h3><asp:Literal ID="litDescricao" runat="server" /></h3>

                <p>&nbsp;</p>

                <p class="flickr"> 
                    <asp:Repeater ID="rptFotosGaleria" runat="server">
                        <ItemTemplate>
                            <%#getFoto(Convert.ToInt32(Eval("IDFotoGaleria")))%>
                        </ItemTemplate>
                    </asp:Repeater>
                </p>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>
