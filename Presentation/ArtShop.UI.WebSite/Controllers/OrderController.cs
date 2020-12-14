using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System.Web.Security;


namespace ArtShop.UI.WebSite.Controllers
{
    public class OrderController : Controller
    {
        CartProcess cp = new CartProcess();
        CartItemProcess cip = new CartItemProcess();
        OrderProcess op = new OrderProcess();
        OrderDetailProcess odp = new OrderDetailProcess();
        ProductProcess pp = new ProductProcess();



        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Pago()
        {
            return View();
        }

        public ActionResult CompraFinalizada()
        {
            return View();
        }

        public JsonResult GetOrders()
        {
            var ap = new OrderProcess();
            var list = ap.ListarTodos();
           
            foreach (Order item in list) 
            
            {
              item.Fecha = item.OrderDate.ToShortDateString();          
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CrearOrden()
        {

            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            Cart cart = new Cart();
            cart = cp.ListarUno(Convert.ToInt32(cookie.Value));

            List<CartItem> listaItems = cip.ListarTodos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

            double Total = 0;
            foreach (CartItem item in listaItems)         
            {
                Total = Total + item.Price; 
            }

            Order oOrder = new Order()
            {
                UserId = User.Identity.GetUserId(),
                OrderDate = DateTime.Now,
                OrderNumber = 1, 
                ItemCount = cart.ItemCount,
                TotalPrice = Total
             };

                Order oOrderSave;
                oOrderSave = op.AgregarOrden(oOrder);
                                  
                    foreach (var item in listaItems)
                    {
                        //Alta Detalles de orden
                        OrderDetail oDetail = new OrderDetail()
                        {
                            OrderId = oOrderSave.Id,
                            ProductId = item.ProductId,
                            Price = item.Price,
                            Quantity = item.Quantity
                        };

                        odp.AgregarItem(oDetail);
                    }
            Response.Cookies["cookieCart"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("CompraFinalizada");

        }
    }
}