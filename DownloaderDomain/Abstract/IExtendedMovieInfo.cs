using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Abstract
{
    public interface IExtendedMovieInfo : IMovieTorrentInfo
    {
        string RunTime { get; }
        string Genre { get; }
        string Plot { get; }
        string PosterUrl { get; }
        string Rating { get; }
        string ReviewScore { get; }
        string ImdbId { get; }
        string ImdbUrl { get; }
    }
}
