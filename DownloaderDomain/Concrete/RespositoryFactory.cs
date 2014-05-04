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

        //public IExtendedMovieTorrentRepository GetLatestUploaded()
        //{
        //    return GetRepository(torrentzLatest);
        //}

        //public IExtendedMovieTorrentRepository GetMostPopular()
        //{
        //    return GetRepository(torrentzMostPopular);
        //}

        //private IExtendedMovieTorrentRepository GetRepository(string url)
        //{
        //    var feed = new RssHelper();
        //    var torrentRepo = new TorrentzMovieTorrentRepository(feed.GetFeedFromSite(url), new TorrentzParser());
        //    return new ExtendedTorrentRepository(torrentRepo);
        //}

    }
}
