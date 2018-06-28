using System;
using System.Collections.Generic;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders {get; set;}
    }
}