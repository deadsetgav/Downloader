using DownloaderDomain.Abstract;
using System;

namespace DownloaderDomain.Concrete
{

    //TODO - Get rid of these classes.


    public class MovieInfo : IMovieTorrentInfo
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

    public class ExtendedMovieInfo : IMovieExtendedInfo 
    {
        private IMovieTorrentInfo movie;

        public ExtendedMovieInfo(IMovieTorrentInfo baseMovie) 
        {
            movie = baseMovie;
        }
        
        public string RunTime{ get; set; }
        public string Genre{ get; set; }
        public string Plot{ get; set; }
        public string PosterUrl{ get; set; }
        public string Rating{ get; set; }
        public string ReviewScore { get; set; }
        public string ImdbId { get; set; }

        public string Raw { get { return movie.Raw; } }
        public string Title{ get { return movie.Title; } }
        public string Year{ get { return movie.Year; } }
        public string Resolution{ get { return movie.Resolution; } }
        public string RipType{ get { return movie.RipType; } }
        public string Link{ get { return movie.Link; } }
        public string Size { get { return movie.Size; } }
        public string Seeds{ get { return movie.Seeds; } }
        public string Peers { get { return movie.Peers; } }
        public DateTime Date{ get { return movie.Date; } }
       
        public bool IsValidForMetadataSearch 
        { 
            get { return movie.IsValidForMetadataSearch; }
            set { movie.IsValidForMetadataSearch = value; } 
        }

        public string ImdbUrl { get { return string.Format("http://www.Imdb.com/title/{0}", ImdbId); } }
        
    }
}
