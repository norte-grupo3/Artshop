using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;
using ArtShop.Data;

namespace ArtShop.Business
{
    public partial class ProductComponent
    {
        public Product Add(Product product)
        {
            Product result = default(Product);
            var productDAC = new ProductDAC();

            result = productDAC.Create(product);
            return result;
        }

        public List<Product> List()
        {
            List<Product> result = default(List<Product>);
            var productDAC = new ProductDAC();
            result = productDAC.Select();
            return result;
        }

        public void Remove(int id)
        {
            var productDAC = new ProductDAC();
            productDAC.DeleteById(id);
        }
    }
}
