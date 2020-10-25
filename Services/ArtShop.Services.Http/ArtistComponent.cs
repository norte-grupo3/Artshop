using ArtShop.Data;
using ArtShop.Entities.Model;
using System.Collections.Generic;

namespace ArtShop.Services.Http
{
    public partial class ArtistComponent
    {
        public Artist Add(Artist artist)
        {
            Artist result = default(Artist);
            var artistDAC = new ArtistDAC();

            result = artistDAC.Create(artist);
            return result;
        }

        public void Remove(int id)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.DeleteById(id);
        }

        public List<Artist> List()
        {
            List<Artist> result = default(List<Artist>);
            var artistDAC = new ArtistDAC();
            result = artistDAC.Select();
            return result;
        }

        public Artist Find(int id)
        {
            Artist result = default(Artist);
            var artistDAC = new ArtistDAC();
            result = artistDAC.SelectById(id);
            return result;
        }

        public void Edit(Artist artist)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.UpdateById(artist);
        }
    }
}