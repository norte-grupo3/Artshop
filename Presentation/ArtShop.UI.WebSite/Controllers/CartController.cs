using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System.Globalization;

namespace ArtShop.UI.WebSite.Controllers
{
    public class CartController : Controller

    {
        CartItemProcess cip = new CartItemProcess();
        ProductProcess pp = new ProductProcess();
        CartProcess cp = new CartProcess();

        // GET: Cart

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Items()
        {
            List<CartItem> listaItems = new List<CartItem>();
            if (Request.Cookies["cookieCart"] != null)
            {
                HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");               

                listaItems = cip.ListarTodos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                foreach (var item in listaItems)
                {
                    item._Product = pp.ListarUno(item.ProductId);
                }
              
            }
            return Json(listaItems, JsonRequestBehavior.AllowGet);

        }

       // [HttpPost]
        public void AddToCart(int Id)
        {
            Product oPaint = pp.ListarUno((Convert.ToInt32(Id)));

            if (Request.Cookies.Get("cookieCart") == null)
            {
                HttpCookie cookie = new HttpCookie("cookieCart");
                Cart oCart = new Cart();

                CartItem oCartItem = new CartItem()
                {
                    ProductId = Convert.ToInt32(Id),
                    Price = oPaint.Price,
                    Quantity = 1,
                    _Product = oPaint
                };

                //Seteo datos de cart
                oCart.ItemCount = 1;
                var format = "dd/MM/yyyy HH:mm:ss";
                var hoy = DateTime.Now.ToString(format);
                var dateTime = DateTime.ParseExact(hoy, format, CultureInfo.InvariantCulture);
                oCart.CartDate = dateTime;
                oCart.Cookie = "";

                    //Obtengo el id del carritoCreado
                    Cart oCartSave = cp.AgregarCarrito(oCart);

                    cookie.Value = oCartSave.Id.ToString();
                    oCartSave.Cookie = cookie.Value;

                    //Actualizo el carrito con la cookie
                    cp.EditarCarrito(oCartSave);

                    //Genero la cookie
                    Response.Cookies.Add(cookie);

                    //Guardo el id del carrito en el item
                    oCartItem.CartId = oCartSave.Id;

                    //Guardo el item
                    cip.Agregar(oCartItem);

            }
            else
            {
                HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
                List<CartItem> listaItems = cip.ListarTodos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                CartItem oCartItem = new CartItem()
                {
                    ProductId = Convert.ToInt32(Id),
                    Price = oPaint.Price,
                    Quantity = 1,
                    CartId = Convert.ToInt32(cookie.Value),
                    _Product = oPaint
                };

                //Actualizo cantidad de items del carrito 
                Cart oCart = cp.ListarUno(Convert.ToInt32(cookie.Value));
                oCart.ItemCount += 1;

                    cip.Agregar(oCartItem);
                    cp.EditarCarrito(oCart);

            }

        }

        public ActionResult getPrice()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            var precio = 0.0;
            if (cookie != null)
            {
                List<CartItem> listaItems = cip.ListarTodos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                foreach (var item in listaItems)
                {
                    precio = precio + item.Price;

                }
            }

            return Json(new { response = precio }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCantidad()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            var cantidad = 0;
            if (cookie != null)
            {
                Cart carrito = cp.ListarUno(Convert.ToInt32(cookie.Value));
                cantidad = carrito.ItemCount;

            }

            return Json(new { response = cantidad }, JsonRequestBehavior.AllowGet);
        }

    }
}