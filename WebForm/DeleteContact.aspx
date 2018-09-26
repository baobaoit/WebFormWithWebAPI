<%@ Page Title="" Language="C#" MasterPageFile="~/ContactManager.Master" AutoEventWireup="true" CodeBehind="DeleteContact.aspx.cs" Inherits="WebForm.DeleteContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Delete Contact</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <h2>Delete Contact - Using Code behind HttpClient</h2>

    <div class="row">
        <div class="col-md-4 col-sm-3">

            <h3>Find a contact by ContactID</h3>

            <div class="form-group">
                <label for="inpContactID">Input ContactID: </label>
                <asp:TextBox runat="server" ID="txtContactID" TextMode="Number" placeholder="Enter ContactID" CssClass="form-control" />
                <button runat="server" id="btnFindContactById" class="btn btn-info" title="Find Contact by Id" onserverclick="btnFindContactById_ServerClick">
                    <span class="glyphicon glyphicon-search"></span>
                </button>
            </div>

        </div>

        <div class="col-md-8 col-sm-5">

            <h3>Contact Information</h3>
            <asp:Label runat="server" ID="lblGridViewAlt" Text="Enter a Contact ID and click Find button to show!" Font-Bold="True" Font-Size="18pt" ForeColor="Red"></asp:Label>
            <asp:GridView runat="server" ID="gvContacts" AutoGenerateColumns="False" OnRowCommand="gvContacts_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Company" HeaderText="Company" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:ButtonField HeaderText="Delete" Text='<span class="glyphicon glyphicon-trash"></span>' ControlStyle-CssClass="btn btn-danger" CommandName="DeleteContact" />
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
