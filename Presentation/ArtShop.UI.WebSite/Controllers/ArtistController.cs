using ArtShop.Entities.Model;
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
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexFront()
        {
            return View();
        }

        public JsonResult AddArtist(Artist artist)
        {
            var ap = new ArtistProcess();
            var list = ap.AgregarAtista(artist);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditArtist(Artist artist)
        {
            var ap = new ArtistProcess();
            var list = ap.EditarAtista(artist);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetArtist(int Id)
        {
            var ap = new ArtistProcess();
            var list = ap.ListarUno(Id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetArtists()
        {
            var ap = new ArtistProcess();
            var list = ap.ListarTodos();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public void RemoveArtist(int id)
        {
            var ap = new ArtistProcess();
            ap.EliminarAtista(id);
        }
    }
}