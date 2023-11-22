<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="applRecord.aspx.cs" Inherits="Sign_applRecord" %>
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
            <asp:HiddenField ID="hfAgtId" runat="server" Value='<%#Eval("agtId") %>' />
            <asp:HiddenField ID="hfApplNo" runat="server" Value='<%#Eval("applNo") %>' />
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
            <div>
                <span>申請時間:</span>
                <span><%#Eval("agtApplTime","{0:g}") %></span>
            </div>
            <div align="center">
                <asp:Button ID="btnApprove" runat="server" Text="核准" CssClass="hyper_btn" CommandName="approve" />
                <asp:Button ID="btnReject" runat="server" Text="婉拒" CssClass="hyper_btn" CommandName="reject" />
            </div>
            <hr />
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

