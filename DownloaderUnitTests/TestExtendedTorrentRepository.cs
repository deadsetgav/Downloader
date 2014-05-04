using DownloaderDomain.Abstract;
using DownloaderDomain.Concrete;
using DownloaderDomain.Entities;
using DownloaderUnitTests.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderUnitTests
{
    [TestClass]
    public class TestExtendedTorrentRepository
    {
        private MockObjectHelper mocks = new MockObjectHelper();     

        //[TestMethod]
        //[TestCategory("Integration")]
        //[Ignore]
        //public void Test_Integration()
        //{
        //    var torrentzRepo = new TorrentzMovieTorrentRepository(mocks.GetSyndicationFeed(), new TorrentzParser());

        //    var target = new ExtendedTorrentRepository(torrentzRepo);
        //    var results = target.MovieTorrents;

        //    Assert.IsInstanceOfType(results, typeof(IEnumerable<IExtendedMovieInfo>));
        //    Assert.IsTrue(results.Count() > 0);
        //    Assert.AreEqual(torrentzRepo.MovieTorrents.Count(), target.MovieTorrents.Count());
            
        //}

        //[TestMethod]
        //[TestCategory("Integration")]
        //[Ignore]
        //public void Test_Live_Integration()
        //{
        //    var rssHelper = new RssHelper();
        //    var feed = rssHelper.GetFeedFromSite("http://torrentz.eu/feed_verifiedP?q=movies");

        //    var torrentzRepo = new TorrentzMovieTorrentRepository(feed, new TorrentzParser());

        //    var target = new ExtendedTorrentRepository(torrentzRepo);
        //    var results = target.MovieTorrents;

        //    OutputToConsole(results);

        //    Assert.IsInstanceOfType(results, typeof(IEnumerable<IExtendedMovieInfo>));
        //    Assert.IsTrue(results.Count() > 0);
        //    Assert.AreEqual(torrentzRepo.MovieTorrents.Count(), target.MovieTorrents.Count());
            
        //}

        [TestMethod]
        public void Test_Facade()
        {
            var facade = new RespositoryFactory();
            var latestRepo = facade.GetLatestUploadedTorrents();
            var popularRepo = facade.GetMostPopularTorrents();

            Assert.IsTrue(latestRepo.MovieTorrents.Count() > 0);
            Assert.IsTrue(popularRepo.MovieTorrents.Count() > 0);
        }

        private void OutputToConsole(IEnumerable<IExtendedMovieInfo> movies)
        {

            foreach (var movie in movies)
            {
                Console.WriteLine(string.Format("Raw: {0}; Title: {1}; Year:{2}; Rating:{3}",
                    movie.Raw, movie.Title, movie.Year, movie.Rating));
                
            }

        }
    }
}
