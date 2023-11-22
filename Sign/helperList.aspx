<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="helperList.aspx.cs" Inherits="Sign_helperList" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc" TagName="ucPage" Src="~/ucPage.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc:ucPage ID="ucPage" runat="server" />
    <div align="center" style="padding:8px">
        <span>地區:</span>
        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_Change" />
        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_Change" />
        <asp:DropDownList ID="ddlStore" runat="server" />
        <asp:Button ID="btnSubmit" runat="server" Text="搜尋" OnClick="btnSubmit_Click" />
    </div>
    <asp:Repeater ID="Repeater" runat="server" OnItemDataBound="Repeater_ItemDataBound" OnItemCommand="Repeater_ItemCommand" >
        <HeaderTemplate>
            <div class="tbDiv h_center">
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("id") %>' />
            <div>
                <span>姓名:</span>
                <span><%#Eval("userName") %></span>
            </div>
            <div>
                <span>門市:</span>
                <asp:HiddenField ID="hfCity" runat="server" Value='<%#Eval("cityId") %>' />
                <asp:HiddenField ID="hfDistrict" runat="server" Value='<%#Eval("districtId") %>' />
                <asp:Label ID="lbStore" runat="server" Text='<%#Eval("storeId") %>' />
            </div>
            <div>
                <span>手機:</span>
                <span><%#Eval("phone") %></span>
            </div>
            <div>
                <span>Email:</span>
                <asp:Label ID="lbEmail" runat="server" Text='<%#Eval("email") %>' />
            </div>
            <div align="center">
                <asp:Button ID="btnInvite" runat="server" Text="送出邀請" CommandName="invite" />
            </div>
            <hr />
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

