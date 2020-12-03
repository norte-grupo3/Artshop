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

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Ver()
        {
            return View();
        }

        public JsonResult GetProduct(int Id)
        {
            var ap = new ProductProcess();
            var prod = ap.ListarUno(Id);
            prod.art=prod.Artist.Id;
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditProduct (Product product)
        {
            product.SetArtistId(product.art);
            var ap = new ProductProcess();
            var list = ap.EditarProduct(product);
            return Json(list, JsonRequestBehavior.AllowGet);
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

        public void RemoveProduct(int id)
        {
            var ap = new ProductProcess();
            ap.EliminarProducto(id);
        }

    }
}