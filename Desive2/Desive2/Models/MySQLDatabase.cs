using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using System.Text;

namespace Desive2.Models
{
    public class Database
    {
        const string key = "!@#$%^&*";
        const string API = "http://www.desive2.com/php/DBConnect.php";
        public static int CheckUser(string mail, string token)
        {
            string postData = $"mail={mail}" + $"&token={token}";
            int responseString = int.Parse(apiCall("validUser", postData));
            if (responseString > 0)
            {


                return responseString;
            }
            else
            {
                return -1;
            }
        }


        public static bool UploadPicture(string user, string picture)
        {
            string postData = $"idAppUser={user}&picture={picture}";
            int responseString = int.Parse(apiCall("uploadPicture", postData));
            if (responseString > 0)
            {


                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UploadVoicemail(string user, string picture)
        {
            string postData = $"idAppUser={user}&voiceMail={picture}";
            int responseString = int.Parse(apiCall("uploadVoiceMail", postData));
            if (responseString > 0)
            {


                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Survey> GetCurrentSurvey(string userId)
        {
            string requestString = API + "?action=getCurrentSurvey";
            WebRequest request = WebRequest.Create(requestString);
            request.Method = "POST";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            
            List<Survey> survey = JsonConvert.DeserializeObject<List<Survey>>(responseString);
            return survey;
        }

        private static string apiCall(string action, string postData)
        {
            string requestString = API + "?action=" + action;
            byte[] data = Encoding.UTF8.GetBytes(postData);

            WebRequest request = WebRequest.Create(requestString);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

    }
}
