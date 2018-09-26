using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class DeleteContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnFindContactById_ServerClick(object sender, EventArgs e)
        {
            int findContactID = Convert.ToInt32(txtContactID.Text);

            lblGridViewAlt.Visible = false;
            gvContacts.DataSource = MyHelper.GetContactById(findContactID);
            gvContacts.DataBind();
        }

        protected void gvContacts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DeleteContact"))
            {
                var row = gvContacts.Rows[0];
                var getContactId = Convert.ToInt32(row.Cells[0].Text);


                var respone = MyHelper.DeleteContact(getContactId);

                if (respone.IsSuccessStatusCode)
                {
                    Response.Write(MyHelper.GetAleartSuccess("Contact was deleted."));
                }
                else
                {
                    Response.Write(MyHelper.GetAleartWarning("Some thing was wrong."));
                }
            }
        }
    }
}