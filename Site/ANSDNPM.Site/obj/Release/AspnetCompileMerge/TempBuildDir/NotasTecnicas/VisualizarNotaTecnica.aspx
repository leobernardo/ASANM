<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpANSDNPM.Master" AutoEventWireup="true" CodeBehind="VisualizarNotaTecnica.aspx.cs" Inherits="ANSDNPM.Site.NotasTecnicas.VisualizarNotaTecnica" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">
    <style type="text/css">
        ul.listaArquivos { list-style-type: square; }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin latest posts -->
    <div class="box">
        <div class="buffer">
            <h2>Notas Técnicas</h2>
            <div class="content">
                <h3>NOTA TÉCNICA INFORMATIVA Nº <asp:Literal ID="litNumeroAno" runat="server" /></h3>

                <h2 style="padding:0px;"><asp:Literal ID="litTitulo" runat="server" /></h2>

                <p>&nbsp;</p>
                
                <p><asp:Literal ID="litCorpo" runat="server" /></p>

                <p>&nbsp;</p>

                <h2 style="padding:0px;">Arquivos relacionados:</h2>

                <p>&nbsp;</p>

                <ul class="listaArquivos">
                    <asp:Repeater ID="rptArquivosNotaTecnica" runat="server">
                        <ItemTemplate>
                            <%#getArquivo(Convert.ToInt32(Eval("IDArquivoNotaTecnica")))%>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!-- end latest posts -->

</asp:Content>