using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Abstract
{
    public interface IMovieTorrentInfo
    {
        string Raw { get;}
        string Title { get; }
        string Year { get; }
        string Resolution { get; }
        string RipType { get; }
        string Link { get; }
        
        string Size { get; }
        string Seeds { get; }
        string Peers { get; }

        DateTime Date { get; }
        bool IsValidForMetadataSearch { get; set; }

    }
}

