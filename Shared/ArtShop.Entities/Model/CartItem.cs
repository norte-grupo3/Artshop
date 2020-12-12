//====================================================================================================
// Código base generado con Visual Studio: (Build 1.0.1973)
// Unidad 4 - Layered Architecture
// Generado por vcontreras - MCGA
//====================================================================================================


using System;
using System.Runtime.Serialization;

namespace ArtShop.Entities.Model

{
    [Serializable]
    public class CartItem : IdentityBase
    {
        [DataMember]
        public int CartId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}