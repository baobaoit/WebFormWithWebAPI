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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53362/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage respone = client.GetAsync("api/Contacts").Result;

            if (respone.IsSuccessStatusCode)
            {
                var contacts = respone.Content.ReadAsStringAsync().Result;
                gvContacts.DataSource = (new JavaScriptSerializer()).Deserialize<List<Contact>>(contacts);
                gvContacts.DataBind();
            }
        }
    }
}