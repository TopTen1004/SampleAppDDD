using SampleApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.DTOs.Order
{
    public class OrderResponse
    {

        public int ID { get; set; }
        public int? IDCustomer { get; set; }
        public DateTime? InsertionDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public virtual List<OrderItemResponse> OrderItemsList { get; set; }
    }
}
