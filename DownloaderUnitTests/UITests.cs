using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DownloaderUI.TestData;
using System.Linq;

namespace DownloaderUnitTests
{
    [TestClass]
    public class UITests
    {
        [TestMethod]
        public void TestFakeRepository()
        {
            var repo = new TestRepository();

            var movie = repo.MovieTorrents.ToArray()[0];
            
            Assert.IsNotNull(movie);
            Assert.AreEqual("The Machine",movie.Title);

        }
    }
}
