using DownloaderDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderUnitTests.MockObjects
{
    class MockMovieInfo: IMovieTorrentInfo
    {
        public string Raw { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Resolution { get; set; }
        public string RipType { get; set; }
        public string Size { get; set; }
        public string Seeds { get; set; }
        public string Peers { get; set; }
        public string Link { get; set; }

        public DateTime Date { get; set; }
        public bool IsValidForMetadataSearch { get; set; }
       
    }
}
