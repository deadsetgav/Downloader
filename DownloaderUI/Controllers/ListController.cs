using DownloaderUI.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DownloaderUI.Models;
using DownloaderDomain.Abstract;
using DownloaderDomain.Concrete;
using WebApplication1.Models;

namespace DownloaderUI.Controllers
{
    public class ListController : Controller
    {
        
        private IFacade facade = new DownloaderDomainFacade();
        private IExtendedMovieTorrentRepository repo;


        //
        // GET: /List/
        public ActionResult Index(Sort? sort)
        {
            if (sort == Sort.Recent)
            {
                repo = facade.GetLatestUploaded();
            }
            if (sort == Sort.Popular || repo == null)
            {
                repo = facade.GetMostPopular();
            }
            var model = new ListModel()
            {
                Torrents = repo.MovieTorrents
            };
            return View(model);
        }

        

        [HttpGet]
        public PartialViewResult Movie(ImdbDetails model)
        {
            return PartialView(model);
        }
	}
}