using DownloaderDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DownloaderDomain.Concrete
{
    class TorrentzMovieInfo : IMovieTorrentInfo
    {

        public string Raw { get; private set; }
        public string Title { get; private set; }
        public string Year { get; private set; }
        public string Resolution { get; private set; }
        public string RipType { get; private set; }
        public string Link { get; private set; }
        public string Size { get; private set; }
        public string Seeds { get; private set; }
        public string Peers { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsValidForMetadataSearch { get; set; }

        private string summary;

        public TorrentzMovieInfo(SyndicationItem item)
        {
            Link = item.Id;
            Date = item.PublishDate.DateTime;
            Raw = item.Title.Text;

            ParseTitle(item.Title.Text);
    
            summary = item.Summary.Text;
            ParseSummary();
            
        }
        
        private void ParseTitle(string syndicationTitle)
        {
            var year = GetYear(syndicationTitle);
            if (year == string.Empty)
            {
                IsValidForMetadataSearch = false;
                SetEmptyValues(syndicationTitle);
            }
            else
            {
                IsValidForMetadataSearch = true;
                Year = year;
                PopulateFields(syndicationTitle);
            }
        }

        private string GetYear(string titleText)
        {
            var reg = new Regex(@"\b\d{4}\b");

            var matches = reg.Matches(titleText);
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

        private void PopulateFields(string syndicationTitle)
        {
            Title = syndicationTitle.Substring(0, syndicationTitle.IndexOf(Year)).Trim();
            var detail = syndicationTitle.Replace(Year, "").Replace(Title, "").Trim();

            //TODO - Resolution
            //TODO - RipType
            SetEmptyValues(syndicationTitle);
        }

        private void SetEmptyValues(string syndicationTitle)
        {
            if (Title == null) Title = syndicationTitle;
            if (Year == null) Year = string.Empty;
            if (Resolution == null) Resolution = string.Empty;
            if (RipType == null) RipType = string.Empty;
        }

        private void ParseSummary()
        {
            try
            {
                GetSummaryItem("Hash:");
                Peers = GetSummaryItem("Peers:");
                Seeds = GetSummaryItem("Seeds:");
                Size = GetSummaryItem("Size:");
            }
            catch
            {
                if (Peers == null) Peers = string.Empty;
                if (Seeds == null) Seeds = string.Empty;
                if (Size == null) Size = string.Empty;
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


}
