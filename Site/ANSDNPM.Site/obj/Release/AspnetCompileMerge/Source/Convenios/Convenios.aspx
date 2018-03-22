<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="Convenios.aspx.cs" Inherits="ASANM.Site.Convenios.Convenios" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">

    <!-- jvectormap -->
    <link rel="stylesheet" href="../plugins/jvectormap/main.css" type="text/css" media="screen" />

</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <!-- begin featured content -->
    <div class="box">
        <div class="buffer">
            <h2>Convênios</h2>
            <div class="content">
                <div id="brazil-map"></div><br /><br />

                <div id="divUFConvenio" visible="false" runat="server">
                    <h3>CONVÊNIOS DA UF <asp:Literal ID="litUFConvenio" runat="server" /></h3>

                    <p>&nbsp;</p>

                    <asp:Repeater ID="rptConveniosUF" runat="server">
                        <ItemTemplate>
                            <h2 style="padding:0px;"><a href="VisualizarConvenio.aspx?idCnv=<%#Eval("IDConvenio")%>" class="title"><%#Eval("NMConvenio")%></a></h2><p>&nbsp;</p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <h3>CONVÊNIOS NACIONAIS</h3>

                <p>&nbsp;</p>

                <asp:Repeater ID="rptConveniosNacionais" runat="server">
                    <ItemTemplate>
                        <h2 style="padding:0px;"><a href="VisualizarConvenio.aspx?idCnv=<%#Eval("IDConvenio")%>" class="title"><%#Eval("NMConvenio")%></a></h2><p>&nbsp;</p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <!-- end featured content -->

    <!-- jvectormap -->
    <script type="text/javascript" src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script type="text/javascript" src="../plugins/jvectormap/brazil.js"></script>
    <script type="text/javascript">
      $(function () {
          var map_settings = {
              map: 'brazil',
              zoomButtons: false,
              zoomMax: 1,
              regionStyle: {
                  initial: {
                      'fill-opacity': 0.9,
                      stroke: '#000',
                      'stroke-width': 100,
                      'stroke-opacity': 1
                  },
                  hover: {
                      fill: '#ABBCCB'
                  }
              },
              backgroundColor: '#fff',
              series: {
                  regions: [{
                      values: {
                          // Região Norte
                          ac: '#587998',
                          am: '#587998',
                          ap: '#587998',
                          pa: '#587998',
                          ro: '#587998',
                          rr: '#587998',
                          to: '#587998',
                          // Região Nordeste
                          al: '#587998',
                          ba: '#587998',
                          ce: '#587998',
                          ma: '#587998',
                          pb: '#587998',
                          pe: '#587998',
                          pi: '#587998',
                          rn: '#587998',
                          se: '#587998',
                          // Região Centro-Oeste
                          df: '#587998',
                          go: '#587998',
                          ms: '#587998',
                          mt: '#587998',
                          // Região Sudeste
                          es: '#587998',
                          mg: '#587998',
                          rj: '#587998',
                          sp: '#587998',
                          // Região Sul
                          pr: '#587998',
                          rs: '#587998',
                          sc: '#587998'
                      },
                      attribute: 'fill'
                  }]
              },
              container: $('#brazil-map'),
              onRegionClick: function (event, code) {
                  //$('#clicked-region span').text(code);
                  window.location.href = "Convenios.aspx?uf=" + code
              },
              onRegionOver: function (event, code) {
                  //$('#hovered-region span').text(code);
                  document.body.style.cursor = 'pointer';
              }
          };

          map = new jvm.WorldMap($.extend(true, {}, map_settings));
      });
    </script>

</asp:Content>