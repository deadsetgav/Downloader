using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DownloaderDomain.Entities;
using System.ServiceModel.Syndication;

namespace DownloaderUnitTests
{
	[TestClass]
	public class TestRssHelper
	{
		private string _popularTorrentzFeed = "http://torrentz.eu/feed_verifiedP?q=movies";
		//private string _pirateBayMovieFeed = "http://rss.thepiratebay.se/201";
		
		[TestMethod]
		public void Test_RssHelper_Read_From_Torrentz()
		{
			var target = new RssHelper();
			var feed = target.GetFeedFromSite(_popularTorrentzFeed);

			Assert.IsInstanceOfType(feed, typeof(SyndicationFeed));

		}

        //[TestMethod]
        //[Ignore]
        //public void Test_RssHelper_Read_From_PirateBay()
        //{
        //    var target = new RssHelper();
        //    var feed = target.GetFeedFromSite(_pirateBayMovieFeed);

        //    Assert.IsInstanceOfType(feed, typeof(SyndicationFeed));

        //    // aparently this needs the below setting on the XmlReader to work.
        //    // reader.Settings.DtdProcessing = DtdProcessing.Parse;

        //}

	}
}
