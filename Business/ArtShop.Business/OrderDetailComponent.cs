using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;
using ArtShop.Data;

namespace ArtShop.Business
{
   public class OrderDetailComponent
    {
        public OrderDetail Add(OrderDetail item)
        {
            OrderDetail result = default(OrderDetail);
            var itemDAC = new OrderDetailDAC();

            result = itemDAC.Create(item);
            return result;
        }

        public List<OrderDetail> List()
        {
            List<OrderDetail> result = default(List<OrderDetail>);
            var itemDAC = new OrderDetailDAC();
            result = itemDAC.Select();
            return result;
        }

        public void Remove(int id)
        {
            var itemDAC = new OrderDetailDAC();
            itemDAC.DeleteById(id);
        }

        public OrderDetail Find(int id)
        {
            OrderDetail result = default(OrderDetail);
            var itemDAC = new OrderDetailDAC();
            result = itemDAC.SelectById(id);
            return result;
        }

        public OrderDetail Edit(OrderDetail item)
        {
            OrderDetail result = default(OrderDetail);
            var itemDAC = new OrderDetailDAC();
            result = itemDAC.UpdateById(item);
            return result;
        }
    }
}
