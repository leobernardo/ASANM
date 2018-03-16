<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="Galerias.aspx.cs" Inherits="ANSDNPM.Site.Galerias.Galerias" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Galerias</h2>
            <div class="content">
                <ul class="homelist">
                    <asp:Repeater ID="rptGalerias" runat="server">
                        <ItemTemplate>
                            <li> <p>&nbsp;</p><a href="VisualizarGaleria.aspx?idGlr=<%#Eval("IDGaleria")%>" class="title"><%#Eval("DSGaleria")%></a><p>&nbsp;</p><hr /></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>