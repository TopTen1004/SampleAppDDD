using System;
using System.Collections.Generic;

namespace SampleApplication.Domain.Entities
{
    public partial class OrderItem
    {
        public int ID { get; set; }
        public int? IDOrder { get; set; }
        public int? IDProduct { get; set; }
        public int? Quantity { get; set; }

        public virtual Order? IDOrderNavigation { get; set; }
        public virtual Product? IDProductNavigation { get; set; }
    }
}
