<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPage.ascx.cs" Inherits="ucPage" %>
<asp:Repeater ID="rptPage" runat="server">
    <HeaderTemplate>
        <div align="center">
    </HeaderTemplate>
    <ItemTemplate>
        <%--<asp:LinkButton ID="lbPage" runat="server" CommandArgument="<%# Container.DataItem %>" OnClick="lbPage_Click">
            <%# Container.DataItem %>
        </asp:LinkButton>--%>
        <%--<asp:HyperLink ID="hyPage" runat="server" NavigateUrl='<%# Request.Path+"?index="+Container.DataItem %>' >
            <%# Container.DataItem %>
        </asp:HyperLink>--%>
        <%--<asp:PlaceHolder ID="phContainer" runat="server" />--%>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>