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
            var equipmentType = typeof(Equipment);
            var actualEquipment = Enum.GetValues(equipmentType).OfType<Equipment>()
                .All(_ => equipmentType.GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>() != null);

            var rimsType = typeof(Rims);
            var actualRims = Enum.GetValues(rimsType).OfType<Rims>()
                .All(_ => rimsType.GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>() != null);

            var varnishType = typeof(Varnish);
            var actualVarnish = Enum.GetValues(varnishType).OfType<Varnish>()
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
            var equipmentType = typeof(Equipment);
            var actualEquipment = Enum.GetValues(equipmentType).OfType<Equipment>()
                .All(_ => equipmentType.GetMember(_.ToString())[0].GetCustomAttribute<DisplayAttribute>() != null);

            var rimsType = typeof(Rims);
            var actualRims = Enum.GetValues(rimsType).OfType<Rims>()
                .All(_ => rimsType.GetMember(_.ToString())[0].GetCustomAttribute<DisplayAttribute>() != null);

            var varnishType = typeof(Varnish);
            var actualVarnish = Enum.GetValues(varnishType).OfType<Varnish>()
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
            var actualEquipment = Enum.GetValues(typeof(Equipment)).OfType<Equipment>()
                .All(_ =>
                {
                    var attribute = typeof(Equipment).GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>();
                    return decimal.TryParse(attribute.Price, out var price);
                });

            var actualRims = Enum.GetValues(typeof(Rims)).OfType<Rims>()
                .All(_ =>
                {
                    var attribute = typeof(Rims).GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>();
                    return decimal.TryParse(attribute.Price, out var price);
                });

            var actualVarnish = Enum.GetValues(typeof(Varnish)).OfType<Varnish>()
                .All(_ =>
                {
                    var attribute = typeof(Varnish).GetMember(_.ToString())[0].GetCustomAttribute<PriceAttribute>();
                    return decimal.TryParse(attribute.Price, out var price);
                });

            //Assert
            Assert.IsTrue(actualEquipment);
            Assert.IsTrue(actualRims);
            Assert.IsTrue(actualVarnish);
        }
    }
}