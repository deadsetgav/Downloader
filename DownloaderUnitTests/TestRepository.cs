using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;

namespace DownloaderUI.TestData
{

    public class TestRepository : IExtendedMovieTorrentRepository
    {

        private List<IMovieExtendedInfo> movies;

        public TestRepository()
        {
            movies = new List<IMovieExtendedInfo>();

            AddFakesToMovieList();

        }

        private void AddFakesToMovieList()
        {
            movies.Add(new Movie
            {
                Raw = "The Machine 2014 DVDRIP XVID AC3 ACAB",
                Title = "The Machine",
                Year = "2013",
                RunTime = "91 min",
                Genre = "Sci-fi, Thriller",
                Plot = "Two artificial intelligence engineers come together as they work to create the first ever self-aware artificial intelligence. A veteran AI engineer secretly hopes to develop technology to ...",
                PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUwMDg1NTk1OV5BMl5BanBnXkFtZTgwMzAyNDczMTE@._V1_SY317_CR0,0,214,317_.jpg",
                Rating = "15",
                ReviewScore = "6.4",
                Size = "1544 MB",
                Seeds = "15,223",
                Peers = "9,612",
                Date = DateTime.Parse("Mon, 07 Apr 2014 18:20:18 +0000"),
                Link="http://torrentz.eu/61a13b0974742f8f2f2e0c610a352a50ebb0f9fb"
            });

            movies.Add(new Movie
            {
                Raw = "We Are Explorers 3D Printed Video",
                Title = "",
                Year = "",
                RunTime = "",
                Genre = "",
                Plot = "",
                PosterUrl = "",
                Rating = "",
                ReviewScore = "",
                Size = "327 MB",
                Seeds = "22,351",
                Peers = "46",
                Date = DateTime.Parse("Fri, 28 Mar 2014 23:41:05 +0000"),
                Link = "http://torrentz.eu/c022d271812e073eac52a8a389342172889f638e"
            }); 
            
            movies.Add(new Movie
            {
                Raw = "Sparks 2013 720p BrRip x264 YIFY",
                Title = "Sparks",
                Year = "2013",
                RunTime = "97 min",
                Genre = "Action, Thriller",
                Plot = "A masked vigilante who discovers the dark side to heroism. Going after the nation's most notorious super criminal leaves Sparks' life and reputation in ruins.",
                PosterUrl = "http://ia.media-imdb.com/images/M/MV5BOTAzNzU4NzY3OV5BMl5BanBnXkFtZTgwMTkzOTEyMTE@._V1_SX214_.jpg",
                Rating = "15",
                ReviewScore = "6.6",
                Size = "754 MB ",
                Seeds = "12,709",
                Peers = "5,548",
                Date = DateTime.Now,
                Link = "http://torrentz.eu/852a77b9a4e3a3c4a5b3abf1bfc47fb7e5035095"
            }); 
            
            movies.Add(new Movie
            {
                Raw = "Frozen 2013 1080p BrRip x264 YIFY",
                Title = "Frozen",
                Year = "2013",
                RunTime = "102 min",
                Genre = "Animation, Adventure, Comedy",
                Plot = "Fearless optimist Anna teams up with Kristoff in an epic journey, encountering Everest-like conditions, and a hilarious snowman named Olaf in a race to find Anna's sister Elsa, whose icy powers have trapped the kingdom in eternal winter.",
                PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTQ1MjQwMTE5OF5BMl5BanBnXkFtZTgwNjk3MTcyMDE@._V1_SX214_.jpg",
                Rating = "PG",
                ReviewScore = "7.9",
                Size = "1673 MB",
                Seeds = "14,335",
                Peers = "1,769",
                Date = DateTime.Parse("Thu, 27 Feb 2014 06:40:37"),
                Link = "http://torrentz.eu/4956a4e976ea948025c3c3554567ca2820f65f64"
            }); 

            movies.Add(new Movie
            {
                Raw = "The Hobbit The Desolation of Smaug 2013 1080p BrRip x264 YIFY",
                Title = "The Hobbit The Desolation of Smaug",
                Year = "2013",
                RunTime = "161 min",
                Genre = "Adventure, Fantasy",
                Plot = "The dwarves, along with Bilbo Baggins and Gandalf the Grey, continue their quest to reclaim Erebor, their homeland, from Smaug. Bilbo Baggins is in possession of a mysterious and magical ring.",
                PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMzU0NDY0NDEzNV5BMl5BanBnXkFtZTgwOTIxNDU1MDE@._V1_SY317_CR0,0,214,317_.jpg",
                Rating = "12a",
                ReviewScore = "8.1",
                Size = "2106 MB",
                Seeds = "12,646",
                Peers = "2,383",
                Date = DateTime.Parse("Wed, 19 Mar 2014 06:57:01 +0000"),
                Link="http://torrentz.eu/d61abdbd6a17d5fa2f116078a2fa20f02b07af8f"
            });

        }
        
        public IEnumerable<IMovieExtendedInfo> MovieTorrents
        {
            get { return movies; }
        }

        private class Movie : IMovieExtendedInfo 
        {
            public string Raw { get; set; }
            public string RunTime { get; set; }
            public string Genre { get; set; }
            public string Plot { get; set; }
            public string PosterUrl { get; set; }
            public string Rating { get; set; }
            public string ReviewScore { get; set; }
            public string Title { get; set; }
            public string Year { get; set; }
            public string Resolution { get { return string.Empty; } }
            public string RipType { get { return string.Empty; } }
            public string Link { get; set; }
            public string Size { get; set; }
            public string Seeds { get; set; }
            public string Peers { get; set; }
            public DateTime Date { get; set; }
            public string ImdbId { get; set; }

            public bool IsValidForMetadataSearch { get { return true; } set{} }
        }
    }
}