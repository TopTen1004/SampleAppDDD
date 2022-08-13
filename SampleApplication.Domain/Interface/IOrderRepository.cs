using SampleApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order AddOrder(Order order, List<OrderItem> orderItems);
        Order UpdateOrder(Order order, List<OrderItem> orderItems);
        IEnumerable<Order> GetByDate(DateTime from, DateTime to);
    }
}
