using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Diagnostics;
using System.Text.RegularExpressions;
using WebForm.Models;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebForm
{
    public class MyHelper
    {
        public static string GetMyBaseAddress()
        {
            return "http://localhost:53362/";
        }
        /// <summary>
        /// Print messages for debugging
        /// </summary>
        /// <param name="messages"></param>
        public static void WriteLine(string messages)
        {
            Debug.WriteLine(messages);
        }
        public static string RemoveAllExtraWhiteSpace(string Text)
        {
            return Regex.Replace(Text.Trim(), @"\s+", " ");
        }

        #region Communicate with the Web API
        /// <summary>
        /// Calling GET method on the Web API
        /// </summary>
        /// <returns></returns>
        public static List<Contact> GetListContact()
        {
            List<Contact> listContact = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetMyBaseAddress());

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respone = client.GetAsync("api/Contacts").Result;

                if (respone.IsSuccessStatusCode)
                {
                    var contacts = respone.Content.ReadAsStringAsync().Result;
                    listContact = (new JavaScriptSerializer()).Deserialize<List<Contact>>(contacts);
                }
            }

            return listContact;
        }
        /// <summary>
        /// GET a contact and then add it to the list to use the data binding.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Contact> GetContactByIdToList(int id)
        {
            List<Contact> listContact = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetMyBaseAddress());

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respone = client.GetAsync("api/GetContactByID?id=" + id).Result;

                if (respone.IsSuccessStatusCode)
                {
                    var contact = respone.Content.ReadAsStringAsync().Result;
                    var deseriContact = JsonConvert.DeserializeObject<Contact>(contact);

                    listContact = new List<Contact>();
                    listContact.Add(deseriContact);
                }
            }

            return listContact;
        }
        /// <summary>
        /// GET a contact with id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Contact GetContactById(int id)
        {
            Contact _Contact = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetMyBaseAddress());

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respone = client.GetAsync("api/GetContactByID?id=" + id).Result;

                if (respone.IsSuccessStatusCode)
                {
                    var contact = respone.Content.ReadAsStringAsync().Result;
                    _Contact = JsonConvert.DeserializeObject<Contact>(contact);
                }
            }

            return _Contact;
        }
        /// <summary>
        /// If can't get list contact then it will return 0
        /// </summary>
        /// <returns></returns>
        public static int GenerateNextContactID()
        {
            int nextContactID = 0;

            nextContactID = GetListContact().Last().ContactID + 1;

            return nextContactID;
        }
        /// <summary>
        /// POST a new contact to the database
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static HttpResponseMessage PostContact(Contact contact)
        {
            HttpResponseMessage response = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetMyBaseAddress());
                var jsonContent = new StringContent(JsonConvert.SerializeObject(contact));
                jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = client.PostAsync("api/PostContact", jsonContent).Result;
            }

            return response;
        }
        /// <summary>
        /// DELETE a contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static HttpResponseMessage DeleteContact(int id)
        {
            HttpResponseMessage response = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetMyBaseAddress());
                client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.DeleteAsync("api/DeleteContact?id=" + id).Result;
            }

            return response;
        }
        /// <summary>
        /// PUT a contact has changed the information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ModifiedContact"></param>
        /// <returns></returns>
        public static HttpResponseMessage PutContact(int id, Contact ModifiedContact)
        {
            HttpResponseMessage response = null;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(ModifiedContact));
            jsonContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetMyBaseAddress());
                response = client.PutAsync("api/PutContact?id=" + id, jsonContent).Result;
            }

            return response;
        }
        #endregion

        #region Alert by div tag
        public static string GetAlertWarning(string messages = "")
        {
            return "<div class=\"alert alert-warning alert-dismissible\" style=\"margin-top: 60px;\">" +
                   "<a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>" +
                   "<strong>Warning!</strong> " + messages + "</div>";
        }
        public static string GetAlertSuccess(string messages = "")
        {
            return "<div class=\"alert alert-success alert-dismissible\" style=\"margin-top: 60px;\">" +
                   "<a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>" +
                   "<strong>Success!</strong> " + messages + "</div>";
        }
        public static string GetAlertDanger(string messages = "")
        {
            return "<div class=\"alert alert-danger alert-dismissible\" style=\"margin-top: 60px;\">" +
                   "<a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>" +
                   "<strong>Danger!</strong> " + messages + "</div>";
        } 
        #endregion
    }
}