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
            return new TorrentzMovieInfo(item);
        }

    }
}
