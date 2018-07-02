using System;
using KFZKonfigurator.BusinessModels.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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
            var actualEquipment = Enum.GetValues(typeof(Equipment)).OfType<Equipment>()
                .All(_ =>
                {
                    var attributes = typeof(Equipment).GetMember(_.ToString())[0].GetCustomAttributes(typeof(PriceAttribute), false);
                    return attributes.Any() && attributes[0] is PriceAttribute;
                });

            var actualRims = Enum.GetValues(typeof(Rims)).OfType<Rims>()
                .All(_ =>
                {
                    var attributes = typeof(Rims).GetMember(_.ToString())[0].GetCustomAttributes(typeof(PriceAttribute), false);
                    return attributes.Any() && attributes[0] is PriceAttribute;
                });

            //Assert
            Assert.IsTrue(actualEquipment);
            Assert.IsTrue(actualRims);
        }

        [TestMethod]
        public void Test_that_price_strings_are_valid()
        {
            //Arrange
            var actualEquipment = Enum.GetValues(typeof(Equipment)).OfType<Equipment>()
                .All(_ =>
                {
                    var attribute = typeof(Equipment).GetMember(_.ToString())[0].GetCustomAttributes(typeof(PriceAttribute), false)[0] as PriceAttribute;
                    return decimal.TryParse(attribute.Price, out var price);
                });

            var actualRims = Enum.GetValues(typeof(Rims)).OfType<Rims>()
                .All(_ =>
                {
                    var attribute = typeof(Rims).GetMember(_.ToString())[0].GetCustomAttributes(typeof(PriceAttribute), false)[0] as PriceAttribute;
                    return decimal.TryParse(attribute.Price, out var price);
                });

            //Assert
            Assert.IsTrue(actualEquipment);
            Assert.IsTrue(actualRims);
        }
    }
}