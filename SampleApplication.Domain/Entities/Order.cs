using System;
using System.Collections.Generic;

namespace SampleApplication.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ID { get; set; }
        public int? IDCustomer { get; set; }
        public DateTime? InsertionDate { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Customer? IDCustomerNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
