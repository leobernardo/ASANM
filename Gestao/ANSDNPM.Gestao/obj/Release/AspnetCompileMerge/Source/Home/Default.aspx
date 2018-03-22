<%@ Page Title="[GESTÃO] ANSDNPM - Associação Nacional dos Servidores do DNPM" Language="C#" MasterPageFile="~/MasterPages/mpASANM.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASANM.Gestao.Home.Default" %>

<%@ Register Src="~/UserControls/ucMenu.ascx" TagPrefix="uc" TagName="ucMenu" %>

<asp:Content ContentPlaceHolderID="cphHEAD" runat="server">



</asp:Content>

<asp:Content ContentPlaceHolderID="cphCONTEUDO" runat="server">

    <div class="row">
        <div class="col-md-2">
            <div class="sidebar content-box" style="display: block;"><uc:ucMenu runat="server" id="ucMenu" /></div>
        </div>
        <div class="col-md-10">&nbsp;</div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="cphFOOTER" runat="server">



</asp:Content>