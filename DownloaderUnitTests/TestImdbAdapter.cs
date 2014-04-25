﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DownloaderDomain.Concrete;
using DownloaderDomain.Entities;
using DownloaderDomain.Abstract;
using DownloaderUnitTests.MockObjects;

namespace DownloaderUnitTests
{
    [TestClass]
    public class TestImdbAdapter
    {
        private MockObjectHelper mocks = new MockObjectHelper();      

        [TestMethod]
        public void Test_Lookup_Single_Films_Details()
        {
            var testMovie = new MovieInfo();
            testMovie.Title = "Lethal Weapon";
            testMovie.Year = "1987";
            testMovie.IsValidForMetadataSearch = true;

            var target = new ImdbAdapter();
            var result = target.GetExtendedInfo(testMovie);

            Assert.IsInstanceOfType(result, typeof(IMovieExtendedInfo));
            Assert.AreEqual("7.6",result.ReviewScore );
        }

        [TestMethod]
        public void Test_That_Search_Still_Populates()
        {
            var testMovie = new MovieInfo();
            testMovie.Title = "Anchorman 2 The Legend Continues";
            testMovie.Year = "2013";
            testMovie.IsValidForMetadataSearch = true;

            var target = new ImdbAdapter();
            var result = target.GetExtendedInfo(testMovie);

            Assert.AreEqual("R", result.Rating);
            Assert.AreEqual("119 min", result.RunTime);
            Assert.AreEqual("Comedy", result.Genre);

            Assert.AreEqual("Anchorman 2 The Legend Continues", result.Title);
            Assert.AreEqual("2013", result.Year);
        }
               
        [TestMethod]
        public void Test_Imdb_Mapper_Populates_Extended_Info()
        {
            var testMovie = new MovieInfo();
            testMovie.Title = "Lethal Weapon";
            testMovie.Year = "1987";
            testMovie.IsValidForMetadataSearch = true;

            var target = new ImdbMapper();
            var result = target.ParseJson(testMovie, mocks.GetTestJson());

            Assert.AreEqual("R", result.Rating);
            Assert.AreEqual("110 min", result.RunTime);
            Assert.AreEqual("Action, Thriller", result.Genre);

            Assert.AreEqual("Lethal Weapon", result.Title);
            Assert.AreEqual("1987", result.Year);
        }

        
    }
}
