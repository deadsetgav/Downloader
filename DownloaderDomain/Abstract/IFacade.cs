using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Abstract
{
    public interface IFacade 
    {
        IExtendedMovieTorrentRepository GetLatestUploaded();
        IExtendedMovieTorrentRepository GetMostPopular();

        IMovieTorrentRepository GetLatestUploadedTorrents();
        IMovieTorrentRepository GetMostPopularTorrents();
    }
}
