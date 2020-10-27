using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Services.Http
{
    public partial class CartComponent
    {
        public Cart Add(Cart cart)
        {
            Cart result = default(Cart);
            var cartDAC = new CartDAC();

            result = cartDAC.Create(cart);
            return result;
        }

        public void Remove(int id)
        {
            var cartDAC = new CartDAC();
            cartDAC.DeleteById(id);
        }

        public List<Cart> List()
        {
            List<Cart> result = default(List<Cart>);
            var cartDAC = new CartDAC();
            result = cartDAC.Select();
            return result;
        }

        public Cart Find(int id)
        {
            Cart result = default(Cart);
            var cartDAC = new CartDAC();
            result = cartDAC.SelectById(id);
            return result;
        }

        public void Edit(Cart cart)
        {
            var cartDAC = new CartDAC();
            cartDAC.UpdateById(cart);
        }
    }
}
