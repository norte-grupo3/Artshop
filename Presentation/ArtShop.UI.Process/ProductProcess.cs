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
    }
}
