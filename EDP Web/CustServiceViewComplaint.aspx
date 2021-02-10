<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustServiceViewComplaint.aspx.cs" Inherits="EDP_Web.CustServiceViewComplaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="complainForm" runat="server">
        <div class ="container">
            <p><asp:Label runat="server"><b>List of Complaints</b></asp:Label></p>
            <asp:Label ID="Label1" runat="server" Text="Seach by Title : "></asp:Label>
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Filter by Status : "></asp:Label>
            <asp:DropDownList ID="ddlComplaint" runat="server">
                <asp:ListItem Selected="True">Unresolved</asp:ListItem>
                <asp:ListItem>Taking Action</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go" />
            <br /><br />

            <asp:Button ID="btnViewResolved" runat="server" Text="View Resolved Complaints" OnClick="btnViewResolved_Click" />
            <asp:GridView ID ="DisplayComplaints" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="title_id" HeaderText="Title ID" ReadOnly="true" />
                    <asp:BoundField DataField="customer_id"  HeaderText="Customer ID" ReadOnly="true" />
                    <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="true" />
                    <asp:BoundField DataField="category" HeaderText="Subject Category" ReadOnly="true" />
                    <asp:BoundField DataField="body" HeaderText="Body" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Status">
                        <EditItemTemplate>
                            <asp:Label ID="lblRowStatus" runat="server" Visible="false" Text='<%# Bind("status") %>'></asp:Label>
                            <asp:DropDownList  ID="ddlRowStatus" runat="server">
                                <asp:ListItem Value="Unresolved">Unresolved</asp:ListItem>
                                <asp:ListItem Value="Taking Action">Taking Action</asp:ListItem>
                                <asp:ListItem Value="Resolved">Resolved</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:CommandField HeaderText="Command" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>

</asp:Content>
