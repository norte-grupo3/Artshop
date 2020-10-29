using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.UI.WebSite.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetArtists()
        {
            var ap = new ArtistProcess();
            var list = ap.ListarTodos();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}