using DownloaderDomain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Abstract
{
    public interface IRssParser
    {
        IMovieTorrentInfo Parse(SyndicationItem item);
    }
}
