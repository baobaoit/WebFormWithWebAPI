<%@ Page Title="" Language="C#" MasterPageFile="~/ContactManager.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <h2>Contacts - Using Code behind HttpClient</h2>

    <asp:GridView runat="server" ID="gvContacts" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Company" HeaderText="Company" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
        </Columns>
    </asp:GridView>

</asp:Content>
