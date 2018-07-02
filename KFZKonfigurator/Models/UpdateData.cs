using System;

namespace KFZKonfigurator.Models
{
    public class UpdateData
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; }
        public object NewValue { get; set; }
    }
}