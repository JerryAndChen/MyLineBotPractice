<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="agentList.aspx.cs" Inherits="Sign_agentList" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater" runat="server" OnItemDataBound="Repeater_ItemDataBound" OnItemCommand="Repeater_ItemCommand">
        <HeaderTemplate>
            <div class="tbDiv h_center">
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("id") %>' />
            <div>
                <h3><%#Eval("title") %></h3>
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
                <span>起始日期:</span>
                <span><%#Eval("agtStartDate","{0:g}") %></span>
            </div>
            <div>
                <span>結束日期:</span>
                <span><%#Eval("agtEndDate","{0:g}") %></span>
            </div>
            <div align="center">
                <asp:Button ID="btnApply" runat="server" Text="查看內容" CssClass="hyper_btn" />
            </div>
            <hr />
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

