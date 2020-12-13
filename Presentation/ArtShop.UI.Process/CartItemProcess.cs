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

        public CartItem ListarUno(int Id)
        {
            var response = HttpGet<CartItem>("api/CartItem/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }

        public void EliminarItem(int Id)
        {
            HttpDelete<CartItem>("api/CartItem/Eliminar?id=" + Id, MediaType.Json);
        }
    }
}
