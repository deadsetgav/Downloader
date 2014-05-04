using DownloaderDomain.Abstract;
using DownloaderDomain.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DownloaderDomain.Entities
{
    public class ImdbQuery 
    {
        private string urlGetByTitleTemplate = "http://www.omdbapi.com/?t={0}&y={1}";
        private string urlSearchTemplate = "http://www.omdbapi.com/?s={0}&y={1}";
        private string urlGetByIDTemplate = "http://www.omdbapi.com/?i={0}";

        public JsonDeserializer GetMovieDetails(string title, string year)
        {
            var url = string.Format(urlGetByTitleTemplate, title, year);
            var request =  SendRequest(url);
            var json = new JsonDeserializer(request);

            if (found(json))
                return json;

            else
                return SearchTitle(title,year);
        }

        private bool found(JsonDeserializer json)
        {
            return (json.GetString("Response") == "True");
        }
       
        public JsonDeserializer SearchTitle(string title, string year)
        {
            var url = string.Format(urlSearchTemplate, title, year);
            var request = SendRequest(url);
            var response =  new JsonDeserializer(request);

            var search = (object[])response.GetObject("Search");
            if (search != null)
            {
                foreach (Dictionary<string, object> result in search)
                {
                    if (result["Type"].ToString() == "movie")
                    {
                        var Id = result["imdbID"].ToString();
                        return GetTtile(Id);
                    }
                }
            }
            // Null object
            return new JsonDeserializer();
        }
        
        private JsonDeserializer GetTtile(string imdbId)
        {
            var url = string.Format(urlGetByIDTemplate, imdbId);
            var request = SendRequest(url);
            return new JsonDeserializer(request);
        }

        private string SendRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);

            //fake the request from IE or we get blocked!
            ((System.Net.HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
     
    }
}
