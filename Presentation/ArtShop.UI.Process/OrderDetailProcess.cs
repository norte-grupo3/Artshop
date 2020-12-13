using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;

namespace ArtShop.UI.Process
{
    public class OrderDetailProcess:ProcessComponent
    {
        public List<OrderDetail> ListarTodos()
        {
            var response = HttpGet<List<OrderDetail>>("api/OrderDetail/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public OrderDetail AgregarItem(OrderDetail item)
        {
            var response = HttpPost<OrderDetail>("api/OrderDetail/Agregar", item, MediaType.Json);
            return response;
        }

        public void EliminarOrderDetailo(int id)
        {
            HttpDelete<OrderDetail>("api/OrderDetail/Eliminar?id=" + id, MediaType.Json);
        }

        public OrderDetail EditarItem(OrderDetail item)
        {
            var response = HttpPut<OrderDetail>("api/OrderDetail/Editar", item, MediaType.Json);
            return response;
        }

        public OrderDetail ListarUno(int Id)
        {
            var response = HttpGet<OrderDetail>("api/OrderDetail/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }
    }
}
