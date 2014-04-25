using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;

namespace DownloaderDomain.Entities
{

    public class RssHelper
    {
        public SyndicationFeed GetFeedFromSite(string url)
        {
            WebRequest request = WebRequest.Create(url);
            
            //fake the request from IE or we get blocked!
            ((System.Net.HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";

            using (WebResponse response = request.GetResponse())
            using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
            {
                return SyndicationFeed.Load(reader);
            }
         }  
    }

   
}
