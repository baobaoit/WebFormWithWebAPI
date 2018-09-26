using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebForm.Models;

namespace WebForm
{
    public partial class EditContact : System.Web.UI.Page
    {
        Contact editContact;
        bool IsFind;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ToggleEditTools();
                IsFind = false;
            }
            else
            {
                editContact = Session["editContact"] as Contact;
            }
        }

        protected void btnFindContactById_ServerClick(object sender, EventArgs e)
        {
            int findContactID = Convert.ToInt32(txtContactID.Text);

            var findContact = MyHelper.GetContactById(findContactID);

            editContact = new Contact();

            editContact.ContactID = findContact.ContactID;
            editContact.Name = findContact.Name;
            editContact.Company = findContact.Company;
            editContact.Email = findContact.Email;
            editContact.Address = findContact.Address;

            Session["editContact"] = editContact;

            IsFind = true;
   
            if (IsFind)
            {
                if (!txtName.Enabled)
                {
                    ToggleEditTools();
                }
                txtName.Text = editContact.Name;
                txtCompany.Text = editContact.Company;
                txtEmail.Text = editContact.Email;
                txtAddress.Text = editContact.Address;
            }
        }

        protected void ToggleEditTools()
        {
            txtName.Enabled = !txtName.Enabled;
            txtCompany.Enabled = !txtCompany.Enabled;
            txtEmail.Enabled = !txtEmail.Enabled;
            txtAddress.Enabled = !txtAddress.Enabled;
            btnSave.Disabled = !btnSave.Disabled;
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (IsModified(editContact))
            {
                var ModifiedContact = new Contact()
                {
                    ContactID = editContact.ContactID,
                    Name = MyHelper.RemoveAllExtraWhiteSpace(txtName.Text),
                    Company = MyHelper.RemoveAllExtraWhiteSpace(txtCompany.Text),
                    Email = MyHelper.RemoveAllExtraWhiteSpace(txtEmail.Text),
                    Address = MyHelper.RemoveAllExtraWhiteSpace(txtAddress.Text)
                };

                var response = MyHelper.PutContact(ModifiedContact.ContactID, ModifiedContact);

                if (response.IsSuccessStatusCode)
                {
                    Response.Write(MyHelper.GetAlertSuccess("Contact has been edited."));
                    ToggleEditTools();
                    IsFind = false;

                    txtName.Text = string.Empty;
                    txtCompany.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                }
                else
                {
                    Response.Write(MyHelper.GetAlertWarning("Some thing was wrong."));
                }
            }
            else
            {
                Response.Write(MyHelper.GetAlertWarning("Nothing changes."));
            }
        }

        private bool IsModified(Contact _EditContact)
        {
            bool IsModified_Name = _EditContact.Name != MyHelper.RemoveAllExtraWhiteSpace(txtName.Text);
            bool IsModified_Company = _EditContact.Company != MyHelper.RemoveAllExtraWhiteSpace(txtCompany.Text);
            bool IsModified_Email = _EditContact.Email != MyHelper.RemoveAllExtraWhiteSpace(txtEmail.Text);
            bool IsModified_Address = _EditContact.Address != MyHelper.RemoveAllExtraWhiteSpace(txtAddress.Text);

            return IsModified_Name || IsModified_Company || IsModified_Email || IsModified_Address;
        }
    }
}