using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;

namespace ArtShop.UI.Process
{
    public class OrderProcess:ProcessComponent
    {
        public List<Order> ListarTodos()
        {
            var response = HttpGet<List<Order>>("api/Order/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Order AgregarOrden(Order order)
        {
            var response = HttpPost<Order>("api/Order/Agregar", order, MediaType.Json);
            return response;
        }

        public void EliminarOrdero(int id)
        {
            HttpDelete<Order>("api/Order/Eliminar?id=" + id, MediaType.Json);
        }

        public Order EditarOrder(Order order)
        {
            var response = HttpPut<Order>("api/Order/Editar", order, MediaType.Json);
            return response;
        }

        public Order ListarUno(int Id)
        {
            var response = HttpGet<Order>("api/Order/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }
    }
}
