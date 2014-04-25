using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Concrete
{
    public class DownloaderDomainFacade : IFacade
    {
        private string torrentzMostPopular = "http://torrentz.eu/feed_verifiedP?q=movies";
        private string torrentzLatest = "http://torrentz.eu/feed_verified?q=movies";

        public IExtendedMovieTorrentRepository GetLatestUploaded()
        {
            return GetRepository(torrentzLatest);
        }

        public IExtendedMovieTorrentRepository GetMostPopular()
        {
            return GetRepository(torrentzMostPopular);
        }

        private IExtendedMovieTorrentRepository GetRepository(string url)
        {
            var feed = new RssHelper();
            var torrentRepo = new TorrentzMovieTorrentRepository(feed.GetFeedFromSite(url));
            return new ExtendedTorrentRepository(torrentRepo);
        }
    }
}
