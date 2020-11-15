using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Services.Http
{
    public partial class CartItemComponent
    {
        public CartItem Add(CartItem cartItem)
        {
            CartItem result = default(CartItem);
            var cartItemDAC = new CartItemDAC();

            result = cartItemDAC.Create(cartItem);
            return result;
        }

        public void Remove(int id)
        {
            var cartItemDAC = new CartItemDAC();
            cartItemDAC.DeleteById(id);
        }

        public List<CartItem> List()
        {
            List<CartItem> result = default(List<CartItem>);
            var cartItemDAC = new CartItemDAC();
            result = cartItemDAC.Select();
            return result;
        }

        public CartItem Find(int id)
        {
            CartItem result = default(CartItem);
            var cartItemDAC = new CartItemDAC();
            result = cartItemDAC.SelectById(id);
            return result;
        }

        public void Edit(CartItem cartItem)
        {
            var cartItemDAC = new CartItemDAC();
            cartItemDAC.UpdateById(cartItem);
        }
    }
}
