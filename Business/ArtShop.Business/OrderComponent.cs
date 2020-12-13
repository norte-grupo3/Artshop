using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;
using ArtShop.Data;

namespace ArtShop.Business
{
    public partial class OrderComponent
    {
        public Order Add(Order order)
        {
            Order result = default(Order);
            var orderDAC = new OrderDAC();

            result = orderDAC.Create(order);
            return result;
        }

        public List<Order> List()
        {
            List<Order> result = default(List<Order>);
            var orderDAC = new OrderDAC();
            result = orderDAC.Select();
            return result;
        }

        public void Remove(int id)
        {
            var orderDAC = new OrderDAC();
            orderDAC.DeleteById(id);
        }

        public Order Find(int id)
        {
            Order result = default(Order);
            var orderDAC = new OrderDAC();
            result = orderDAC.SelectById(id);
            return result;
        }

        public Order Edit(Order order)
        {
            Order result = default(Order);
            var orderDAC = new OrderDAC();
            result = orderDAC.UpdateById(order);
            return result;
        }
    }
}
