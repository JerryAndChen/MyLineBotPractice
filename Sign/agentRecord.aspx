<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="agentRecord.aspx.cs" Inherits="Sign_agentRecord" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater" runat="server" OnItemDataBound="Repeater_ItemDataBound">
        <HeaderTemplate>
            <div class="tbDiv h_center">
        </HeaderTemplate>
        <ItemTemplate>
            <div>
                <span>姓名:</span>
                <span><%#Eval("userName") %></span>
            </div>
            <div>
                <span>性別:</span>
                <asp:Label ID="lbSexType" runat="server" Text='<%#Eval("sexType") %>' />
            </div>
            <div>
                <span>所屬門市:</span>
                <asp:HiddenField ID="hfCity" runat="server" Value='<%#Eval("cityId") %>' />
                <asp:HiddenField ID="hfDistrict" runat="server" Value='<%#Eval("districtId") %>' />
                <asp:Label ID="lbStore" runat="server" Text='<%#Eval("storeId") %>' />
            </div>
            <div>
                <span>電話:</span>
                <span><%#Eval("phone") %></span>
            </div>
            <hr />
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

