using System;
using KFZKonfigurator.Base.Attributes;
using KFZKonfigurator.BusinessModels.Enum;

namespace KFZKonfigurator.BusinessModels.Utils
{
    public static class MappingExtensions
    {
        public static decimal GetPrice(this EquipmentEnum equipment)
        {
            var member = typeof(EquipmentEnum).GetMember(equipment.ToString());
            var attribute = member[0].GetCustomAttributes(typeof(PriceAttribute), false)[0] as PriceAttribute;

            return decimal.Parse(attribute?.Price ?? throw new ArgumentException());
        }

        public static decimal GetPrice(this RimsEnum? rims)
        {
            if (!rims.HasValue) return 0M;

            var member = typeof(RimsEnum).GetMember(rims.ToString());
            var attribute = member[0].GetCustomAttributes(typeof(PriceAttribute), false)[0] as PriceAttribute;

            return decimal.Parse(attribute?.Price ?? throw new ArgumentException("PriceAttribute is missing"));
        }

        public static decimal GetPrice(this VarnishEnum? varnish)
        {
            if (!varnish.HasValue) return 0M;

            var member = typeof(VarnishEnum).GetMember(varnish.ToString());
            var attribute = member[0].GetCustomAttributes(typeof(PriceAttribute), false)[0] as PriceAttribute;

            return decimal.Parse(attribute?.Price ?? throw new ArgumentException("PriceAttribute is missing"));
        }
    }
}