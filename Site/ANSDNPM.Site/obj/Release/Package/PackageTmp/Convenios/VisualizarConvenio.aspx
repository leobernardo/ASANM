<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="VisualizarConvenio.aspx.cs" Inherits="ANSDNPM.Site.Convenios.VisualizarConvenio" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">
    <style type="text/css">
        ul.listaArquivos { list-style-type: square; }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Convênios</h2>
            <div class="content">
                <h3><asp:Literal ID="litNome" runat="server" /></h3>

                <p>&nbsp;</p>
                
                <p><asp:Literal ID="litDescricao" runat="server" /></p>

                <p>&nbsp;</p>

                <h2 style="padding:0px;">Arquivos relacionados:</h2>

                <p>&nbsp;</p>

                <ul class="listaArquivos">
                    <asp:Repeater ID="rptArquivosConvenio" runat="server">
                        <ItemTemplate>
                            <%#getArquivo(Convert.ToInt32(Eval("IDArquivoConvenio")))%>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>