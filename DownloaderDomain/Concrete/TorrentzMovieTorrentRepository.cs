using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;
using System.Collections.Generic;
using System.ServiceModel.Syndication;


namespace DownloaderDomain.Concrete
{
    public class TorrentzMovieTorrentRepository : IMovieTorrentRepository
    {

        private List<IMovieTorrentInfo> movies;

        public TorrentzMovieTorrentRepository(SyndicationFeed feed, IRssParser parser)
        {
            movies = new List<IMovieTorrentInfo>();

            foreach (var feedItem in feed.Items)
            {
                var movieInfo = parser.Parse(feedItem);
                movies.Add(movieInfo);
            }

        }

        public IEnumerable<IMovieTorrentInfo> MovieTorrents
        {
            get { return movies.ToArray(); }
        }
              
    }
}
