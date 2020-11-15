//====================================================================================================
// Código base generado con Visual Studio: (Build 1.0.1973)
// Unidad 4 - Layered Architecture
// Generado por vcontreras - MCGA
//====================================================================================================


using System.ComponentModel.DataAnnotations;

namespace ArtShop.Entities.Model
{
    public class Rating : IdentityBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Stars { get; set; }
    }
}