using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Concrete
{
    public class ExtendedTorrentRepository : IExtendedMovieTorrentRepository
    {
        private IMovieTorrentRepository rawTorrents;
        private List<IMovieExtendedInfo> detailedTorrents;

        public ExtendedTorrentRepository(IMovieTorrentRepository torrents)
        {
            rawTorrents = torrents;
            PopulateExtendedInfoList();
        }

        private void PopulateExtendedInfoList()
        {
            detailedTorrents = new List<IMovieExtendedInfo>();

            var imdbAdapter = new ImdbAdapter();
            foreach (var movie in rawTorrents.MovieTorrents)
            {
                detailedTorrents.Add(imdbAdapter.GetExtendedInfo(movie));
            }

        }

        public IEnumerable<IMovieExtendedInfo> MovieTorrents
        {
            get { return detailedTorrents.ToArray(); }
        }
    }
}
