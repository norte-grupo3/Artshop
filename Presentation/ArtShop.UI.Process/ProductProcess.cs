using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;

namespace ArtShop.UI.Process
{
    public class ProductProcess:ProcessComponent
    {

        public List<Product> ListarTodos()
        {
            var response = HttpGet<List<Product>>("api/Product/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Product AgregarProducto(Product product)
        {
            var response = HttpPost<Product>("api/Product/Agregar", product, MediaType.Json);
            return response;
        }

        public void EliminarProducto(int id)
        {
            HttpDelete<Product>("api/Product/Eliminar?id=" + id, MediaType.Json);
        }

        public Product EditarProduct(Product product)
        {
            var response = HttpPut<Product>("api/Product/Editar", product, MediaType.Json);
            return response;
        }

        public Product ListarUno(int Id)
        {
            var response = HttpGet<Product>("api/Product/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }
    }
}
