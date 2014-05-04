using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;
using System;

namespace DownloaderDomain.Concrete
{
    public class ExtendedMovieInfo : IExtendedMovieInfo
    {
        private IMovieTorrentInfo movie;

        #region Properties
        public string RunTime { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string PosterUrl { get; set; }
        public string Rating { get; set; }
        public string ReviewScore { get; set; }
        public string ImdbId { get; set; }

        public string Raw { get { return movie.Raw; } }
        public string Title { get { return movie.Title; } }
        public string Year { get { return movie.Year; } }
        public string Resolution { get { return movie.Resolution; } }
        public string RipType { get { return movie.RipType; } }
        public string Link { get { return movie.Link; } }
        public string Size { get { return movie.Size; } }
        public string Seeds { get { return movie.Seeds; } }
        public string Peers { get { return movie.Peers; } }
        public DateTime Date { get { return movie.Date; } }

        public bool IsValidForMetadataSearch
        {
            get { return movie.IsValidForMetadataSearch; }
            set { movie.IsValidForMetadataSearch = value; }
        }

        public string ImdbUrl { get { return string.Format("http://www.Imdb.com/title/{0}", ImdbId); } }

        #endregion

        public ExtendedMovieInfo(IMovieTorrentInfo baseMovie, JsonDeserializer json)
        {
            movie = baseMovie;
            if (json.IsNull)
            {
                PopuateEmptyValues();
            }
            else
            {
                PopuateImdbValues(json);
            }
        }

        private void PopuateEmptyValues()
        {
            RunTime = string.Empty;
            Genre = string.Empty;
            Plot = string.Empty;
            PosterUrl = string.Empty;
            Rating = string.Empty;
            ReviewScore = string.Empty;
            ImdbId = string.Empty;
        }

        private void PopuateImdbValues(JsonDeserializer json)
        {
            RunTime = json.GetString("Runtime");
            Genre = json.GetString("Genre");
            Plot = json.GetString("Plot");
            PosterUrl = json.GetString("Poster");
            Rating = json.GetString("Rated");
            ReviewScore = json.GetString("imdbRating");
            ImdbId = json.GetString("imdbID");
        }

    }

}
