using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Controllers;
using DownloaderUI;
using System.Web.Mvc;
using WebApplication1.Models;

namespace DownloaderUI.Infrastructure.Binders
{

    public class ImdbCacheBinder : IModelBinder
    {
        private const string sessionKey = "ImdbCache";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ImdbCache cache = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cache = (ImdbCache)controllerContext.HttpContext.Session[sessionKey];
            }

            if (cache == null)
            {
                cache = new ImdbCache();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cache;
                }
            }
            return cache;
        }
    }
    
}