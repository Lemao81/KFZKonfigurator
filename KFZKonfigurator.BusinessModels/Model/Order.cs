using System;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime? Created { get; set; }
        public decimal? Price { get; set; }
        public User User { get; set; }
        public Configuration Configuration { get; set; }
    }
}