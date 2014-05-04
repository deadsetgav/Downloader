using DownloaderDomain.Abstract;
using DownloaderDomain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Entities
{
    public class TorrentzParser : IRssParser
    {
        public IMovieTorrentInfo Parse(SyndicationItem item)
        {
            return Parse(new SyndicationItemWrapper(item));
        }
        public IMovieTorrentInfo Parse(ISyndicationItem item)
        {
            return new TorrentzMovieInfo(item);
        }

    }

    class SyndicationItemWrapper : ISyndicationItem
    {
        SyndicationItem item;

        public SyndicationItemWrapper(SyndicationItem syndicationItem)
        {
            item = syndicationItem;
        }
        public string Id
        {
            get { return item.Id; }
        }
        public string Title
        {
            get { return item.Title.Text; }
        }
        public string Summary
        {
            get { return item.Summary.Text; }
        }
        public DateTime PublishDate
        {
            get { return item.PublishDate.DateTime; }
        }

    }
}
