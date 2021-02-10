<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResolvedComplaints.aspx.cs" Inherits="EDP_Web.ResolvedComplaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class ="container">
            <p>
                Resolved Complaints
            </p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="title_id" HeaderText="Title ID" ReadOnly="true" />
                    <asp:BoundField DataField="customer_id"  HeaderText="Customer ID" ReadOnly="true" />
                    <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="true" />
                    <asp:BoundField DataField="category" HeaderText="Subject Category" ReadOnly="true" />
                    <asp:BoundField DataField="body" HeaderText="Body" ReadOnly="true" />
                    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="true" />  
                </Columns>
            </asp:GridView>
            </div>
    </form>

</asp:Content>
