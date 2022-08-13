using SampleApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.DTOs.Order
{
    public class OrderItemResponse
    {
        public int ID { get; set; }
        public int? IDOrder { get; set; }
        public int? IDProduct { get; set; }
        public int? Quantity { get; set; }
    }
}
