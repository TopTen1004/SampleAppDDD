using System;
using System.Collections.Generic;

namespace SampleApplication.Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PostaCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
