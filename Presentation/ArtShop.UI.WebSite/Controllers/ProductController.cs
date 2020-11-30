using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtShop.Entities.Model;
using ArtShop.UI.Process;


namespace ArtShop.UI.WebSite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexFront()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public JsonResult GetProducts()
        {
            var ap = new ProductProcess();
            var list = ap.ListarTodos();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddProduct(Product product)
        {
            product.SetArtistId(product.art);
            var ap = new ProductProcess();
            var list = ap.AgregarProducto(product);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}