﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %><%--建立對主板類別的參考--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <span id="spWelcome" class="center" runat="server"></span>
    </div>
</asp:Content>

