using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;

namespace ArtShop.UI.Process
{
    public class CartProcess : ProcessComponent
    {
        public Cart AgregarCarrito(Cart cart)
        {
            var response = HttpPost<Cart>("api/Cart/Agregar", cart, MediaType.Json);
            return response;
        }

        public List<Cart> ListarTodos()
        {
            var response = HttpGet<List<Cart>>("api/Cart/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Cart EditarCarrito(Cart cart)
        {
            var response = HttpPut<Cart>("api/Cart/Editar", cart, MediaType.Json);
            return response;
        }

        public Cart ListarUno(int Id)
        {
            var response = HttpGet<Cart>("api/Cart/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }
    }
}
