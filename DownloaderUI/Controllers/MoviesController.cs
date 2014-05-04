using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DownloaderDomain.Abstract;
using WebApplication1.Models;
using DownloaderUI.Models;
using DownloaderDomain.Entities;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private IRepositoryFactory repoFactory;
        private int PageSize = 10;

        public MoviesController()
        {
            repoFactory = new DownloaderDomain.Concrete.RespositoryFactory();
        }

        public MoviesController(IRepositoryFactory facade)
        {
            repoFactory = facade;
        }

        //
        // GET: /Movies/
        public ActionResult ListPopular(int page = 1)
        {
            var repo = repoFactory.GetMostPopularTorrents();

            var torrents = repo.MovieTorrents
                //.OrderBy(m => m.Seeds)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
           
            var model = new ListModel()
            {
                Torrents = PopulateExtendedInfoList(torrents),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    MoviesPerPage = PageSize,
                    TotalMovies = repo.MovieTorrents.Count()
                }
            };

            return View(model);
        }

        public ActionResult ListRecent(int page = 1)
        {
            var repo = repoFactory.GetLatestUploadedTorrents();

            var torrents = repo.MovieTorrents
                //.OrderBy(m => m.Seeds)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            var model = new ListModel()
            {
                Torrents = PopulateExtendedInfoList(torrents),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    MoviesPerPage = PageSize,
                    TotalMovies = repo.MovieTorrents.Count()
                }
            };

            return View(model);
        }


        private IList<IMovieExtendedInfo> PopulateExtendedInfoList(IEnumerable<IMovieTorrentInfo> movieTorrents)
        {
            var detailedTorrents = new List<IMovieExtendedInfo>();

            var imdbAdapter = new ImdbAdapter();
            foreach (var movie in movieTorrents)
            {
                detailedTorrents.Add(imdbAdapter.GetExtendedInfo(movie));
            }
            return detailedTorrents;
        }

       
	}
}