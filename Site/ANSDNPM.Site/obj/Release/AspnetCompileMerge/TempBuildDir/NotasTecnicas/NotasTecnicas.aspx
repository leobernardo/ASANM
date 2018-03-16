<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="NotasTecnicas.aspx.cs" Inherits="ANSDNPM.Site.NotasTecnicas.NotasTecnicas" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Notas Técnicas</h2>
            <div class="content">
                <ul class="homelist">
                    <asp:Repeater ID="rptNotasTecnicas" runat="server">
                        <ItemTemplate>
                            <li> <p>&nbsp;</p><a href="VisualizarNotaTecnica.aspx?idNtt=<%#Eval("IDNotaTecnica")%>" class="title">NOTA TÉCNICA INFORMATIVA Nº <%#Eval("NRNotaTecnica")%>/<%#Eval("NRAnoNotaTecnica")%></a><p><%#Eval("DSTitulo")%></p><p>&nbsp;</p><hr /></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>