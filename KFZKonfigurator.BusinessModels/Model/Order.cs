using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFZKonfigurator.BusinessModels
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime? Created { get; set; }

        public virtual User User { get; set; }
        public virtual Configuration Configuration { get; set; }
    }
}