using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Abstract
{
    public interface IRepositoryFactory 
    {
        IMovieTorrentRepository GetLatestUploadedTorrents();
        IMovieTorrentRepository GetMostPopularTorrents();
    }
}
