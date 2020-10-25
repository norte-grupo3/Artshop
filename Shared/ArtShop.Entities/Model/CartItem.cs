//====================================================================================================
// Código base generado con Visual Studio: (Build 1.0.1973)
// Unidad 4 - Layered Architecture
// Generado por vcontreras - MCGA
//====================================================================================================


namespace ArtShop.Entities.Model
{
    public class CartItem : IdentityBase
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}