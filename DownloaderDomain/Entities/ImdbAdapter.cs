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

                if (found(json))
                    return mapper.ParseJson(movieInfo, json);

                else
                    return SearchTitle(movieInfo);
            }
            else
            {
                return mapper.GetBlankExtendedInfo(movieInfo);
            }         
        } 
        
        private JsonDeserializer GetMovie(IMovieTorrentInfo movieInfo)
        {
            var url = string.Format(urlGetByTitleTemplate, movieInfo.Title, movieInfo.Year);
            var request =  SendRequest(url);
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
     
        private bool found(JsonDeserializer json)
        {
            return (json.GetString("Response") == "True");
        }
     
        private IMovieExtendedInfo SearchTitle(IMovieTorrentInfo movieInfo)
        {
            var url = string.Format(urlSearchTemplate, movieInfo.Title, movieInfo.Year);
            var request = SendRequest(url);
            var response = new JsonDeserializer(request);

            var search = (object[])response.GetObject("Search");
            if (search != null)
            {
                foreach (Dictionary<string, object> result in search)
                {
                    if (result["Type"].ToString() == "movie")
                    {
                        var ID = result["imdbID"].ToString();
                        return GetTtile(movieInfo, ID);
                    }
                }
            }
            

            return mapper.GetBlankExtendedInfo(movieInfo);             
        }
  
        private IMovieExtendedInfo GetTtile(IMovieTorrentInfo movieInfo, string imdbId)
        {
            var url = string.Format(urlGetByIDTemplate, imdbId);
            var request = SendRequest(url);
            var json = new JsonDeserializer(request);
            return mapper.ParseJson(movieInfo, json);
        }

        
 
       

















        



    
    }
    
    public class JsonDeserializer
    {
        private IDictionary<string, object> jsonData { get; set; }

        public JsonDeserializer(string json)
        {
            var json_serializer = new JavaScriptSerializer();

            jsonData = (IDictionary<string, object>)json_serializer.DeserializeObject(json);
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
