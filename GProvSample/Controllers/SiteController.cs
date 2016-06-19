using GProvSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GProvSample.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SiteMaster()
        {
            Site s = new Site();
            List<Site> ls = s.GetSite();
            return View(ls);
        }
    }
}