using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Http;
using System.Net.Http.Headers;
using WebForm.Models;
using Newtonsoft.Json;

namespace WebForm
{
    public partial class AddContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            if (IsFill())
            {
                string inpName = MyHelper.RemoveAllExtraWhiteSpace(txtName.Text);
                string inpCompany = MyHelper.RemoveAllExtraWhiteSpace(txtCompany.Text);
                string inpEmail = MyHelper.RemoveAllExtraWhiteSpace(txtEmail.Text);
                string inpAddress = MyHelper.RemoveAllExtraWhiteSpace(txtAddress.Text);

                Contact ct = new Contact()
                {
                    ContactID = MyHelper.GenerateNextContactID(),
                    Name = inpName,
                    Company = inpCompany,
                    Email = inpEmail,
                    Address = inpAddress
                };

                var respone = MyHelper.PostContact(ct);
                if (respone.IsSuccessStatusCode)
                {
                    MyHelper.WriteLine("POST Success");
                    Response.Write(MyHelper.GetAlertSuccess("Add new contact."));
                }
                else
                {
                    MyHelper.WriteLine("POST Error");
                    Response.Write(MyHelper.GetAlertDanger("Some thing was wrong."));
                }
            }
            else
            {
                MyHelper.WriteLine("Data is not filled out");
                Response.Write(MyHelper.GetAlertWarning("Data is not filled out."));
            }
        }

        protected bool IsFill()
        {
            bool fillName = !string.IsNullOrWhiteSpace(txtName.Text);
            bool fillCompany = !string.IsNullOrWhiteSpace(txtCompany.Text);
            bool fillEmail = !string.IsNullOrWhiteSpace(txtEmail.Text);
            bool fillAddress = !string.IsNullOrWhiteSpace(txtAddress.Text);

            return fillName && fillCompany && fillEmail && fillAddress;
        }
    }
}