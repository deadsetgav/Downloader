using DownloaderUI.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DownloaderUI.Models;
using DownloaderDomain.Abstract;

namespace DownloaderUI.Controllers
{
    public class ListController : Controller
    {
        //
        // GET: /List/
        public ActionResult Index()
        {
            var repo = new TestRepository();

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