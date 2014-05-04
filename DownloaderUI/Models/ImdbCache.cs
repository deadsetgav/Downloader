using DownloaderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ImdbCache
    {
        private Dictionary<string, JsonDeserializer> lookup = new Dictionary<string, JsonDeserializer>();

        public bool Contains(string title, string year)
        {
            return lookup.ContainsKey(GetKey(title, year));
        }

        private string GetKey(string title, string year)
        {
            return string.Format("{0}_{1}", title.ToLower().Trim(), year.ToLower().Trim());
        }

        public void Add(string title, string year, JsonDeserializer details)
        {
            lookup.Add(GetKey(title, year), details);
        }

        public JsonDeserializer GetDetails(string title, string year)
        {
            return lookup[GetKey(title, year)];
        }
    }
}