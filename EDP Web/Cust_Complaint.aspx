<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cust_Complaint.aspx.cs" Inherits="EDP_Web.Cust_Complaint" %>
<asp:Content ID="CustEmailPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <p><asp:Label runat="server"><b>Customer Complaint Form</b></asp:Label></p>
        <p><asp:Label runat="server">Please feel in the form below to send the complaint to our Customer Service Agent:</asp:Label></p>

        <form id="Cust_complaint" runat="server">
            <p><asp:Label ID="titleName" runat="server" Text="Title:"/></p>
            <asp:TextBox ID="title" runat="server" />
            <p><asp:Label ID="subjectName" runat="server" Text="Subject:"/></p>
            <asp:DropDownList ID="category" runat="server" DataTextField="Status">
                <asp:ListItem Selected="True">-Select one of the options-</asp:ListItem>
                <asp:ListItem>Purchased the wrong package</asp:ListItem>
                <asp:ListItem>Wrong booking date/time</asp:ListItem>
                <asp:ListItem>Not able to redeem membership points to get discount</asp:ListItem>
                <asp:ListItem>Others...</asp:ListItem>
            </asp:DropDownList><br />
            <p><asp:Label ID="bodyName" runat="server" Text="Body:"/> </p>
            <asp:TextBox ID="body" runat="server" Height="233px" Width="667px" TextMode="MultiLine" />
            <p><asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" /></p>

        </form>
        
    </div>

</asp:Content>
