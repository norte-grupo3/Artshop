//====================================================================================================
// Código base generado con Visual Studio: (Build 1.0.1973)
// Unidad 4 - Layered Architecture
// Generado por vcontreras - MCGA
//====================================================================================================


using System;

namespace ArtShop.Entities.Model
{
    [Serializable]
    public class CartItem : IdentityBase
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}