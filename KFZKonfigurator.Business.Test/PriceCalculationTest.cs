using System.Collections.Generic;
using KFZKonfigurator.Base.Enum;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.BusinessModels.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KFZKonfigurator.Business.Test
{
    [TestClass]
    public class PriceCalculationTest
    {
        private PriceCalculationService _service;

        [TestInitialize]
        public void Setup() {
            _service = new PriceCalculationService();
        }

        [TestMethod]
        public void Test_that_price_is_calculated_correctly() {
            // Arrange
            var priceExpected = 153.6M;
            var equipments = new List<Equipment> {
                new Equipment {PriceEuro = 10},
                new Equipment {PriceEuro = 15}
            };
            var rims = new Rims {PriceEuro = 12};
            var varnish = new Varnish {PriceEuro = 16.6M};

            // Act
            var priceActual = _service.CalculatePrice(Currency.Euro, equipments, rims, varnish, 20);

            // Assert
            Assert.AreEqual(priceExpected, priceActual);
        }
    }
}