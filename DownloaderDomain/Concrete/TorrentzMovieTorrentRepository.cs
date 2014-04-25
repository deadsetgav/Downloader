using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;
using System.Collections.Generic;
using System.ServiceModel.Syndication;


namespace DownloaderDomain.Concrete
{
    public class TorrentzMovieTorrentRepository : IMovieTorrentRepository
    {

        private List<IMovieTorrentInfo> movies;

        public TorrentzMovieTorrentRepository(SyndicationFeed feed)
        {
            movies = new List<IMovieTorrentInfo>();

            foreach (var feedItem in feed.Items)
            {
                var parser = new RssFeedMapper();
                var movieInfo = parser.ParseMovie(feedItem);
                movies.Add(movieInfo);
            }

        }

        public IEnumerable<IMovieTorrentInfo> MovieTorrents
        {
            get { return movies.ToArray(); }
        }
              
    }
}
