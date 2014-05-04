using DownloaderDomain.Abstract;
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

    public class ImdbAdapter
    {
        private string urlGetByTitleTemplate = "http://www.omdbapi.com/?t={0}&y={1}";
        private string urlSearchTemplate = "http://www.omdbapi.com/?s={0}&y={1}";
        private string urlGetByIDTemplate = "http://www.omdbapi.com/?i={0}";

        private ImdbMapper mapper;

        public IMovieExtendedInfo GetExtendedInfo(IMovieTorrentInfo movieInfo) 
        {
            mapper = new ImdbMapper();

            if (movieInfo.IsValidForMetadataSearch) 
            {
                JsonDeserializer json = GetMovie(movieInfo);

                if (!json.IsNull)
                {
                    return mapper.ParseJson(movieInfo, json);
                }
            }
            return mapper.GetBlankExtendedInfo(movieInfo);        
        } 
        
        private JsonDeserializer GetMovie(IMovieTorrentInfo movieInfo)
        {
            var query = new ImdbQuery();            
            return query.GetMovieDetails(movieInfo.Title,movieInfo.Year);
        }

    }
    
    public class JsonDeserializer
    {
        private IDictionary<string, object> jsonData { get; set; }
        public bool IsNull { get; private set; }

        public JsonDeserializer(string json)
        {
            var json_serializer = new JavaScriptSerializer();

            jsonData = (IDictionary<string, object>)json_serializer.DeserializeObject(json);
            IsNull = false;
        }

        public JsonDeserializer()
        {
            IsNull = true;
            jsonData = new Dictionary<string, object>();
        }

        public string GetString(string path)
        {
            return (string)GetObject(path);
        }

        public int? GetInt(string path)
        {
            int? result = null;

            object o = GetObject(path);
            if (o == null)
            {
                return result;
            }

            if (o is string)
            {
                result = Int32.Parse((string)o);
            }
            else
            {
                result = (Int32)o;
            }

            return result;
        }

        public object GetObject(string path)
        {
            object result = null;

            var curr = jsonData;
            var paths = path.Split('.');
            var pathCount = paths.Count();

            try
            {
                for (int i = 0; i < pathCount; i++)
                {
                    var key = paths[i];
                    if (i == (pathCount - 1))
                    {
                        result = curr[key];
                    }
                    else
                    {
                        curr = (IDictionary<string, object>)curr[key];
                    }
                }
            }
            catch
            {
                // Probably means an invalid path (ie object doesn't exist)
            }

            return result;
        }
    }
}
