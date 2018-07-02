using System;

namespace KFZKonfigurator.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PriceAttribute : Attribute
    {
        public PriceAttribute(string price)
        {
            Price = price;
        }

        public string Price { get; set; }
    }
}