using DownloaderDomain.Abstract;
using DownloaderDomain.Concrete;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;

namespace DownloaderDomain.Entities
{
    public class RssFeedMapper
    {
        public IMovieTorrentInfo ParseMovie(SyndicationItem movieItem)
        {
            MovieInfo returnMovie = new MovieInfo();

            returnMovie.Link = movieItem.Id;
            returnMovie.Date = movieItem.PublishDate.DateTime;

            var titleParser = new TitleParser(movieItem.Title.Text);
            titleParser.Parse(returnMovie);

            var summaryParser = new SummaryParser(movieItem.Summary.Text);
            summaryParser.ParseSummary(returnMovie);
            
            return returnMovie;
        }
    }

    public class SummaryParser
    {
        private string summary;

        public SummaryParser(string summaryText){
            summary = summaryText;
        }

        public void ParseSummary(MovieInfo movie)
        {
            try
            {
                GetSummaryItem("Hash:");
                movie.Peers = GetSummaryItem("Peers:");
                movie.Seeds = GetSummaryItem("Seeds:");
                movie.Size = GetSummaryItem("Size:");
            }
            catch 
            {
                if (movie.Peers == null) movie.Peers = string.Empty;
                if (movie.Seeds == null) movie.Seeds = string.Empty;
                if (movie.Size == null) movie.Size = string.Empty;
            }
        }

        private string GetSummaryItem(string searchTerm)
        {
            var index = summary.IndexOf(searchTerm);
            var searchValue = summary.Substring(index, summary.Length - index);
            this.summary = summary.Replace(searchValue, string.Empty);

            return searchValue.Replace(searchTerm, string.Empty).Trim();
        }
    
    }

    public class TitleParser
    {
        private string raw;      

        public TitleParser(string titleText)
        {
            raw = titleText;
        }

        public void Parse(MovieInfo movieInfo)
        {
            movieInfo.Raw = raw;

            var year = GetYear();
            if (year == string.Empty)
            {
                movieInfo.IsValidForMetadataSearch = false;
                SetEmptyValues(movieInfo);
            }
            else
            {
                movieInfo.IsValidForMetadataSearch = true;
                movieInfo.Year = year;
                PopulateFields(movieInfo);
            }             
        }
   
        private string GetYear()
        {
            var reg = new Regex(@"\b\d{4}\b");

            var matches = reg.Matches(raw);
            if (matches.Count > 0)
            {
                var validYears = new List<string>();
                foreach (var match in matches)
                {
                    if (IsValidYear(match.ToString())) 
                        validYears.Add(match.ToString());
                }

                if (validYears.Count == 1) return validYears[0];
            }
            return string.Empty;
        }

        private bool IsValidYear(string number)
        {
            var year = Convert.ToInt16(number);
            return (year > 1950 && year <= DateTime.Now.Year + 1);
        }

        private void PopulateFields(MovieInfo movieInfo)
        {
            movieInfo.Title = raw.Substring(0, raw.IndexOf(movieInfo.Year)).Trim();
            var detail = raw.Replace(movieInfo.Year, "").Replace(movieInfo.Title, "").Trim();
            
            //TODO - Resolution
            //TODO - RipType
            SetEmptyValues(movieInfo);
        }

        private void SetEmptyValues(MovieInfo movieInfo)
        {
            if (movieInfo.Title == null) movieInfo.Title = raw;
            if (movieInfo.Year == null) movieInfo.Year = string.Empty;
            if (movieInfo.Resolution == null) movieInfo.Resolution = string.Empty;
            if (movieInfo.RipType == null) movieInfo.RipType = string.Empty;
        }
    }



   
}
