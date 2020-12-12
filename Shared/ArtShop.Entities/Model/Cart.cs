using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ArtShop.Entities.Model

{
    [Serializable]
    public class Cart : IdentityBase
    {
        public Cart()
        {
            this.CartItem = new HashSet<CartItem>();
        }
        [DataMember]
        public string Cookie { get; set; }
        [DataMember]
        public DateTime CartDate { get; set; }
        [DataMember]
        public int ItemCount { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
