using DownloaderDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace DownloaderUI.Models
{
    public class ListModel
    {
        public IEnumerable<IExtendedMovieInfo> Torrents { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}