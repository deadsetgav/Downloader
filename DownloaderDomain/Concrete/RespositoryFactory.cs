using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Concrete
{
    public class RespositoryFactory : IRepositoryFactory
    {
        private string torrentzMostPopular = "http://torrentz.eu/feed_verifiedP?q=movies";
        private string torrentzLatest = "http://torrentz.eu/feed_verified?q=movies";

        public IMovieTorrentRepository GetLatestUploadedTorrents()
        {
            var feed = new RssHelper();
            return new TorrentzMovieTorrentRepository(feed.GetFeedFromSite(torrentzLatest), new TorrentzParser());
        }

        public IMovieTorrentRepository GetMostPopularTorrents()
        {
            var feed = new RssHelper();
            return new TorrentzMovieTorrentRepository(feed.GetFeedFromSite(torrentzMostPopular), new TorrentzParser());
        }

    }
}
