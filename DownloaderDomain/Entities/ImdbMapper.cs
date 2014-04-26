using DownloaderDomain.Abstract;
using DownloaderDomain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Entities
{
    public class ImdbMapper
    {
       
        public IMovieExtendedInfo ParseJson(IMovieTorrentInfo baseMovie, JsonDeserializer jsonExtended)
        {
            return PopulateImdbValues(baseMovie, jsonExtended);
        }

        private IMovieExtendedInfo PopulateImdbValues(IMovieTorrentInfo baseMovie, JsonDeserializer jsonExtended)
        {
            var returnItem = new ExtendedMovieInfo(baseMovie);

            returnItem.RunTime = jsonExtended.GetString("Runtime");
            returnItem.Genre = jsonExtended.GetString("Genre");
            returnItem.Plot = jsonExtended.GetString("Plot");
            returnItem.PosterUrl = jsonExtended.GetString("Poster");
            returnItem.Rating = jsonExtended.GetString("Rated");
            returnItem.ReviewScore = jsonExtended.GetString("imdbRating");
            returnItem.ImdbId = jsonExtended.GetString("imdbID");
            
            return returnItem;
        }

        public IMovieExtendedInfo GetBlankExtendedInfo(IMovieTorrentInfo baseMovie)
        {
            var returnItem = new ExtendedMovieInfo(baseMovie);

            returnItem.RunTime = string.Empty;
            returnItem.Genre = string.Empty;
            returnItem.Plot = string.Empty;
            returnItem.PosterUrl = string.Empty;
            returnItem.Rating = string.Empty;
            returnItem.ReviewScore = string.Empty; 

            return returnItem;
        }
    }
}

       
