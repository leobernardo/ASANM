<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenu.ascx.cs" Inherits="ANSDNPM.Gestao.UserControls.ucMenu" %>

<ul class="nav">
<!-- Main menu -->
    <li class="current"><a href="../Home/Default.aspx"><i class="glyphicon glyphicon-home"></i> Página inicial</a></li>
    <li><a href="../Artigos/ListarArtigos.aspx"><i class="glyphicon glyphicon-file"></i> Artigos</a></li>
    <li><a href="../Convenios/ListarConvenios.aspx"><i class="glyphicon glyphicon-link"></i> Convênios</a></li>
    <li><a href="../Galerias/ListarGalerias.aspx"><i class="glyphicon glyphicon-camera"></i> Galerias</a></li>
    <li><a href="../NotasTecnicas/ListarNotasTecnicas.aspx"><i class="glyphicon glyphicon-file"></i> Notas Técnicas</a></li>
    <li><a href="../Noticias/ListarNoticias.aspx"><i class="glyphicon glyphicon-file"></i> Notícias</a></li>
    <li><a href="../Usuarios/ListarUsuarios.aspx"><i class="glyphicon glyphicon-user"></i> Usuários</a></li>
    <li><a href="../Login.aspx?log=0"><i class="glyphicon glyphicon-off"></i> Sair</a></li>
</ul>