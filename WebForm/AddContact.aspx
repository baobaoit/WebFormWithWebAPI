<%@ Page Title="" Language="C#" MasterPageFile="~/ContactManager.Master" AutoEventWireup="true" CodeBehind="AddContact.aspx.cs" Inherits="WebForm.AddContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Contact</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <h2>Add Contact - Using Code behind HttpClient</h2>

    <div class="row">
        <asp:Label Text="Name:" CssClass="col-sm-2" runat="server"></asp:Label>
        <asp:TextBox runat="server" ID="txtName" ></asp:TextBox><br />
        <asp:Label Text="Company:" CssClass="col-sm-2" runat="server"></asp:Label>
        <asp:TextBox runat="server" ID="txtCompany" ></asp:TextBox><br />
        <asp:Label Text="Email:" CssClass="col-sm-2" runat="server"></asp:Label>
        <asp:TextBox runat="server" ID="txtEmail" ></asp:TextBox><br />
        <asp:Label Text="Address:" CssClass="col-sm-2" runat="server"></asp:Label>
        <asp:TextBox runat="server" ID="txtAddress" ></asp:TextBox><br />
        <asp:Label Text="" CssClass="col-sm-2" runat="server"></asp:Label>
        <button runat="server" class="btn btn-success" style="margin-top: 5px;" id="btnAdd" onserverclick="btnAdd_ServerClick">
            <span class="glyphicon glyphicon-plus"></span> Add</button>
    </div>
</asp:Content>
