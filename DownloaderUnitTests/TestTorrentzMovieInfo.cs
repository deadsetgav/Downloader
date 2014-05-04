using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using DownloaderUnitTests.MockObjects;
using DownloaderDomain.Abstract;
using DownloaderDomain.Entities;

namespace DownloaderUnitTests
{
    [TestClass]
    public class TestTorrentzMovieInfo
    {
        [TestMethod]
        public void TestCreateNewTorrentzMovieInfo()
        {

            SyndicationFeed feed = new MockObjectHelper().GetSyndicationFeed();
            var item = feed.Items.FirstOrDefault();

            IRssParser parser = new TorrentzParser();

            //The Machine 2014 DVDRIP XVID AC3 ACAB
            //http://torrentz.eu/61a13b0974742f8f2f2e0c610a352a50ebb0f9fb
            //07/04/2014 18:20:18 +00:00
            //Size: 1544 MB Seeds: 15,036 Peers: 9,770 Hash: 61a13b0974742f8f2f2e0c610a352a50ebb0f9fb

            var target = parser.Parse(item);

            Assert.AreEqual("The Machine", target.Title);
            Assert.AreEqual("1544 MB", target.Size);
            Assert.AreEqual("15,036", target.Seeds);
            Assert.AreEqual("9,770", target.Peers);
            Assert.AreEqual("2014", target.Year);
            Assert.AreEqual(new DateTime(2014,4,7,18,20,18), target.Date);
            Assert.AreEqual("The Machine 2014 DVDRIP XVID AC3 ACAB", target.Raw);

        }
    }
}
