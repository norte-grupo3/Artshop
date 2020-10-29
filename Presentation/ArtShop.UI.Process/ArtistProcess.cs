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
    }
}
