using System;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime? Created { get; set; }

        public virtual User User { get; set; }
        public virtual Configuration Configuration { get; set; }
    }
}