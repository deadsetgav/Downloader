using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DownloaderDomain.Abstract;
using Moq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Collections.Generic;
using DownloaderDomain.Concrete;
using DownloaderUnitTests.MockObjects;
using DownloaderDomain.Entities;
using System.Linq;

namespace DownloaderUnitTests
{
    [TestClass]
    public class TestTorrentzMovieTorrentRepository
    {
        private MockObjectHelper mocks = new MockObjectHelper();        

        [TestMethod]
        public void Test_Aquire_Torrents_From_Web()
        {
            var target = new TorrentzMovieTorrentRepository(mocks.GetSyndicationFeed(), new TorrentzParser());

            var result = (IEnumerable<IMovieTorrentInfo>)target.MovieTorrents;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);

        }
        
        [TestMethod]
        public void Test_Can_Parse_Rss_Feed()
        {
            var feed = mocks.GetSyndicationFeed();

            var target = new TorrentzParser();
            IMovieTorrentInfo result = target.Parse(feed.Items.ToArray()[0]);

            Assert.IsNotNull(result);
            Assert.AreEqual("The Machine", result.Title);
            Assert.AreEqual("2014", result.Year);
            //Assert.AreEqual("DVDRIP", result.RipType);
            Assert.AreEqual("", result.Resolution);
            Assert.AreEqual("The Machine 2014 DVDRIP XVID AC3 ACAB", result.Raw);
           
        }
  
        [TestMethod]
        public void Test_Can_Parse_Torrentz_Title()
        {          
            Mock<ISyndicationItem> item = new Mock<ISyndicationItem>();
            item.Setup(s => s.Summary).Returns("Size: 1109 MB Seeds: 5,350 Peers: 2,432 Hash: d1e5cf113336c8a10f3e50c154504bdd4965cd21");
            item.Setup(s => s.Title).Returns("The Hobbit The Desolation of Smaug 2013 720p BrRip x264 YIFY");

            var parser = new TorrentzParser();
            var testMovieInfo = parser.Parse(item.Object);

            Assert.AreEqual(testMovieInfo.Title, "The Hobbit The Desolation of Smaug");
            Assert.IsTrue(testMovieInfo.IsValidForMetadataSearch);
            Assert.AreEqual(testMovieInfo.Year, "2013");   
        }

        [TestMethod]
        public void Test_Fail_Title_Parse_Gracefully()
        {
            Mock<ISyndicationItem> item = new Mock<ISyndicationItem>();
            item.Setup(s => s.Summary).Returns("Size: 1109 MB Seeds: 5,350 Peers: 2,432 Hash: d1e5cf113336c8a10f3e50c154504bdd4965cd21");
            item.Setup(s => s.Title).Returns("We Are Explorers 3D Printed Video");

            var parser = new TorrentzParser();
            var testMovieInfo = parser.Parse(item.Object);

            Assert.AreEqual(testMovieInfo.Title, "We Are Explorers 3D Printed Video");
            Assert.IsFalse(testMovieInfo.IsValidForMetadataSearch);
            Assert.AreEqual(testMovieInfo.Year, string.Empty);
            Assert.AreEqual(testMovieInfo.RipType, string.Empty);
            Assert.AreEqual(testMovieInfo.Resolution, string.Empty);
 
        }

        [TestMethod]
        public void Test_Can_Parse_Torrentz_Summary()
        {
            Mock<ISyndicationItem> item = new Mock<ISyndicationItem>();
            item.Setup(s => s.Summary).Returns("Size: 1109 MB Seeds: 5,350 Peers: 2,432 Hash: d1e5cf113336c8a10f3e50c154504bdd4965cd21");
            item.Setup(s => s.Title).Returns("The Film 2013 DVDRIP ASBO");

            var parser = new TorrentzParser();
            var testMovieInfo = parser.Parse(item.Object);

            Assert.AreEqual("1109 MB", testMovieInfo.Size);
            Assert.AreEqual("5,350", testMovieInfo.Seeds);
            Assert.AreEqual("2,432", testMovieInfo.Peers);
     
        }
       
        [TestMethod]
        public void Test_Fail_Summary_Parse_Gracefully()
        {

            Mock<ISyndicationItem> item = new Mock<ISyndicationItem>();
            item.Setup(s => s.Summary).Returns("Size: 1109 MB seed: 5,350 Peers: 2,432 unknown: d1e5cf113336c8a10f3e50c154504bdd4965cd21");
            item.Setup(s => s.Title).Returns("The Film 2013 DVDRIP ASBO");

            var parser = new TorrentzParser();
            var testMovieInfo = parser.Parse(item.Object);

            Assert.AreEqual(string.Empty, testMovieInfo.Size);
            Assert.AreEqual(string.Empty, testMovieInfo.Seeds);
            Assert.AreEqual(string.Empty, testMovieInfo.Peers);
     
        }

        

    }
}
