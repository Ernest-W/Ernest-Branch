<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CustServiceAgentPage.aspx.cs" Inherits="EDP_Web.CustServiceAgentPage"%>
<asp:Content ID="CustServiceAgentPage" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <p><asp:Label runat="server"><b>Customer Service Agent Page</b></asp:Label></p>
        <p><asp:Label runat="server">Here are the list of pages that customer has complaints sent to you:</asp:Label></p>
        <br />
        <asp:HyperLink runat="server" NavigateUrl="~/CustServiceViewComplaint.aspx">List of complaints</asp:HyperLink>
    </div>

</asp:Content>
