using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DownloaderDomain.Abstract;
using WebApplication1.Models;
using DownloaderUI.Models;
using DownloaderDomain.Entities;
using DownloaderDomain.Concrete;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private IRepositoryFactory repoFactory;
        private int PageSize = 10;
    

        public MoviesController()
        {
            // need to use Ninject here
            repoFactory = new DownloaderDomain.Concrete.RespositoryFactory();
        }

        public MoviesController(IRepositoryFactory repos)
        {
            repoFactory = repos;
        }

        private ImdbCache cache;

        public ActionResult ListPopular(ImdbCache imdbcache, int page = 1)
        {
            cache = imdbcache;
            var repo = repoFactory.GetMostPopularTorrents();
            return PopulateModel(page, repo);

        }

        public ActionResult ListRecent(ImdbCache imdbcache, int page = 1)
        {
            cache = imdbcache;
            var repo = repoFactory.GetLatestUploadedTorrents();
            return PopulateModel(page, repo);
        }
               

        private ActionResult PopulateModel(int page, IMovieTorrentRepository repo)
        {
            var torrents = repo.MovieTorrents
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

        private IList<IExtendedMovieInfo> PopulateExtendedInfoList(IEnumerable<IMovieTorrentInfo> movieTorrents)
        {
            var detailedTorrents = new List<IExtendedMovieInfo>();
            foreach (var movie in movieTorrents)
            {
                if (movie.IsValidForMetadataSearch)
                {
                    if (cache.Contains(movie.Title, movie.Year))
                    {
                        var json = cache.GetDetails(movie.Title, movie.Year);
                        detailedTorrents.Add(new ExtendedMovieInfo(movie, json));
                    }
                    else
                    {
                        var query = new ImdbQuery();
                        JsonDeserializer json = query.GetMovieDetails(movie.Title, movie.Year);
                        cache.Add(movie.Title, movie.Year, json);

                        detailedTorrents.Add(new ExtendedMovieInfo(movie, json));
                    }
                }
                else
                {
                    detailedTorrents.Add(new ExtendedMovieInfo(movie, new JsonDeserializer()));
                }
                
                
            }
            return detailedTorrents;
        }

       
	}

   
}