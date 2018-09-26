using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebForm.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            try
            {
                gvContacts.DataSource = MyHelper.GetListContact();
                gvContacts.DataBind();
            }
            catch
            {
                MyHelper.WriteLine("GET Error");
                Response.Write(MyHelper.GetAlertDanger("Some thing was wrong."));
            }
        }
    }
}