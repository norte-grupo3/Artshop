using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ArtistProcess : ProcessComponent
    {
        public List<Artist> ListarTodos()
        {
            var response = HttpGet<List<Artist>>("api/Artist/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Artist AgregarAtista(Artist artist)
        {
            var response = HttpPost<Artist>("api/Artist/Agregar", artist, MediaType.Json);
            return response;
        }

        public void EliminarAtista(int id)
        {
            HttpDelete<Artist>("api/Artist/Eliminar?id=" + id, MediaType.Json);
        }
    }
}
