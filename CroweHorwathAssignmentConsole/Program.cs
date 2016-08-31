using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using CroweHorwathAssignment.Data.Models.DTO;
using System.Runtime.Serialization.Json;

namespace CroweHorwathAssignmentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasDBAccess = false;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["HasDBAccess"], out hasDBAccess);
            string url = string.Format("{0}", System.Configuration.ConfigurationManager.AppSettings["DefaultURL"]);

            if (hasDBAccess)
            {
                url = string.Format("{0}/{1}", System.Configuration.ConfigurationManager.AppSettings["GetAPIUrl"], System.Configuration.ConfigurationManager.AppSettings["MessageId"]);
            }

            try
            {
                Console.WriteLine(GetMessage(url).tagDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            Console.Read();
        }

        public static tblTagDTO GetMessage(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";

            using (HttpWebResponse response = webrequest.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(tblTagDTO));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                tblTagDTO jsonResponse
                = objResponse as tblTagDTO;
                return jsonResponse;
            }
        }

    }
}
