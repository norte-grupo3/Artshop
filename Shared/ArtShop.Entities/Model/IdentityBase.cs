using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    [Serializable]
    [DataContract]
    public class IdentityBase
    {
        [Key]
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }


        //Muestra los valores de las propiedades con fines de depuración.
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join(",", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }

    }
}
