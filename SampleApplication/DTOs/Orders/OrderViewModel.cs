using SampleApplication.Domain.Entities;

namespace SampleApplication.DTOs.Orders
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int? IDCustomer { get; set; }
        public DateTime? InsertionDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public virtual List<OrderItemsViewModel> OrderItemsList { get; set; }
    }
}
