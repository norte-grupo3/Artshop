using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;


namespace ArtShop.UI.Process
{
    public class CartItemProcess:ProcessComponent
    {

        public List<CartItem> ListarTodos()
        {
            var response = HttpGet<List<CartItem>>("api/CartItem/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public CartItem Agregar(CartItem Item)
        {
            var response = HttpPost<CartItem>("api/CartItem/Agregar", Item, MediaType.Json);
            return response;
        }
    }
}
