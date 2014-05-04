using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DownloaderDomain.Entities
{
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
