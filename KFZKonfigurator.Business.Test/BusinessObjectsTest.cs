using System;
using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.BusinessModels.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using KFZKonfigurator.Base.Attributes;

namespace KFZKonfigurator.Business.Test
{
    [TestClass]
    public class BusinessObjectsTest
    {
        [TestMethod]
        public void Test_that_enums_have_price_attribute()
        {
            //Arrange
            var equipmentType = typeof(EquipmentEnum);
            var actualEquipment = Enum.GetValues(equipmentType).OfType<EquipmentEnum>()
                .All(_ => equipmentType.GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>() != null);

            var rimsType = typeof(RimsEnum);
            var actualRims = Enum.GetValues(rimsType).OfType<RimsEnum>()
                .All(_ => rimsType.GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>() != null);

            var varnishType = typeof(VarnishEnum);
            var actualVarnish = Enum.GetValues(varnishType).OfType<VarnishEnum>()
                .All(_ => varnishType.GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>() != null);

            //Assert
            Assert.IsTrue(actualEquipment);
            Assert.IsTrue(actualRims);
            Assert.IsTrue(actualVarnish);
        }

        [TestMethod]
        public void Test_that_enums_have_display_attribute()
        {
            //Arrange
            var equipmentType = typeof(EquipmentEnum);
            var actualEquipment = Enum.GetValues(equipmentType).OfType<EquipmentEnum>()
                .All(_ => equipmentType.GetMember(_.ToString())[0].GetCustomAttribute<DisplayAttribute>() != null);

            var rimsType = typeof(RimsEnum);
            var actualRims = Enum.GetValues(rimsType).OfType<RimsEnum>()
                .All(_ => rimsType.GetMember(_.ToString())[0].GetCustomAttribute<DisplayAttribute>() != null);

            var varnishType = typeof(VarnishEnum);
            var actualVarnish = Enum.GetValues(varnishType).OfType<VarnishEnum>()
                .All(_ => varnishType.GetMember(_.ToString())[0].GetCustomAttribute<DisplayAttribute>() != null);

            //Assert
            Assert.IsTrue(actualEquipment);
            Assert.IsTrue(actualRims);
            Assert.IsTrue(actualVarnish);
        }

        [TestMethod]
        public void Test_that_price_strings_are_valid()
        {
            //Arrange
            var actualEquipment = Enum.GetValues(typeof(EquipmentEnum)).OfType<EquipmentEnum>()
                .All(_ =>
                {
                    var attribute = typeof(EquipmentEnum).GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>();
                    return decimal.TryParse(attribute.Price, out var price);
                });

            var actualRims = Enum.GetValues(typeof(RimsEnum)).OfType<RimsEnum>()
                .All(_ =>
                {
                    var attribute = typeof(RimsEnum).GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>();
                    return decimal.TryParse(attribute.Price, out var price);
                });

            var actualVarnish = Enum.GetValues(typeof(VarnishEnum)).OfType<VarnishEnum>()
                .All(_ =>
                {
                    var attribute = typeof(VarnishEnum).GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>();
                    return decimal.TryParse(attribute.Price, out var price);
                });

            //Assert
            Assert.IsTrue(actualEquipment);
            Assert.IsTrue(actualRims);
            Assert.IsTrue(actualVarnish);
        }
    }
}