<%@ Page Title="" Language="C#" MasterPageFile="~/ContactManager.Master" AutoEventWireup="true" CodeBehind="EditContact.aspx.cs" Inherits="WebForm.EditContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit Contact</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <h2>Edit Contact - Using Code behind HttpClient</h2>

    <div class="row">
        <div class="col-md-4 col-sm-3">

            <h3>Find a contact by ContactID</h3>

            <div class="form-group">
                <label for="inpContactID">Input ContactID: </label>
                <asp:TextBox runat="server" ID="txtContactID" TextMode="Number" placeholder="Enter ContactID" CssClass="form-control" />
                <button runat="server" id="btnFindContactById" style="margin-top: 5px;" class="btn btn-info" title="Find Contact by Id" onserverclick="btnFindContactById_ServerClick">
                    <span class="glyphicon glyphicon-search"></span>
                </button>
            </div>

        </div>

        <div class="col-md-8 col-sm-5">

            <h3>Contact Information</h3>
            <div class="form-group">
                <label for="inpName">Name: </label>
                <asp:TextBox runat="server" ID="txtName" placeholder="Enter Name" CssClass="form-control" />
                <label for="inpCompany">Company: </label>
                <asp:TextBox runat="server" ID="txtCompany" placeholder="Enter Company" CssClass="form-control" />
                <label for="inpEmail">Email: </label>
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Enter Email" CssClass="form-control" />
                <label for="inpAddress">Address: </label>
                <asp:TextBox runat="server" ID="txtAddress" placeholder="Enter Address" CssClass="form-control" />
                <button runat="server" id="btnSave" class="btn btn-success" style="margin-top: 5px;" title="Save changes" onserverclick="btnSave_ServerClick">
                    <span class="glyphicon glyphicon-pencil"></span>
                </button>
            </div>

        </div>
    </div>

</asp:Content>
