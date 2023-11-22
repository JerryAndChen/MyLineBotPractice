<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="applRecordQ.aspx.cs" Inherits="Sign_applRecordQ" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc" TagName="ucPage" Src="~/ucPage.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc:ucPage ID="ucPage" runat="server" />
    <asp:Repeater ID="Repeater" runat="server" OnItemDataBound="Repeater_ItemDataBound" OnItemCommand="Repeater_ItemCommand">
        <HeaderTemplate>
            <div class="tbDiv h_center">
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("id") %>' />
            <div>
                <span>標題:</span>
                <span><%#Eval("title") %></span>
            </div>
            <div>
                <span>門市:</span>
                <asp:HiddenField ID="hfCity" runat="server" Value='<%#Eval("cityId") %>' />
                <asp:HiddenField ID="hfDistrict" runat="server" Value='<%#Eval("districtId") %>' />
                <asp:Label ID="lbStore" runat="server" Text='<%#Eval("storeId") %>' />
            </div>
            <div>
                <span>職務:</span>
                <asp:Label ID="lbRole" runat="server" Text='<%#Eval("roleId") %>' />
            </div>
            <div>
                <span>需求人數:</span>
                <span><%#Eval("roleCnt") %></span>
            </div>
            <div>
                <span>起始日期:</span>
                <span><%#Eval("agtStartDate","{0:g}") %></span>
            </div>
            <div>
                <span>結束日期:</span>
                <span><%#Eval("agtEndDate","{0:g}") %></span>
            </div>
            <div align="center">
                <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="hyper_btn" CommandName="update" />
                <asp:Button ID="btnViewDetail" runat="server" Text="申請狀態" CssClass="hyper_btn" CommandName="viewDetail" />
                <asp:Button ID="btnChkSupport" runat="server" Text="支援人員" CssClass="hyper_btn" CommandName="chkSupport" />
            </div>
            <hr />
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

