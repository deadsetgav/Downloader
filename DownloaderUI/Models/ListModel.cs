using DownloaderDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DownloaderUI.Models
{
    public class ListModel
    {
        public IEnumerable<IMovieExtendedInfo> Torrents { get; set; }
    }
}