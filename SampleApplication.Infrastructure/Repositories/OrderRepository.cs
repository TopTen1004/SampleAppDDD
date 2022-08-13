using Microsoft.EntityFrameworkCore;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using SampleApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(SampleDbContext _dbContext) : base(_dbContext)
        {
        }

        public Order AddOrder(Order order, List<OrderItem> orderItems)
        {
            try
            {
                _dbContext.Orders.Add(order);

                foreach(var item in orderItems)
                {
                    _dbContext.OrderItems.Add(item);
                }

                _dbContext.SaveChanges();
                return order;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Order> GetByDate(DateTime from, DateTime to)
        {
            return _dbContext.Orders.Where(x => x.InsertionDate >= from && x.InsertionDate <= to).ToList();
        }

        public Order UpdateOrder(Order order, List<OrderItem> orderItems)
        {
            try
            {
                _dbContext.Entry(order).State = EntityState.Modified;
                _dbContext.OrderItems.RemoveRange(orderItems);
                _dbContext.OrderItems.AddRange(orderItems);
                _dbContext.SaveChanges();

                return order;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
