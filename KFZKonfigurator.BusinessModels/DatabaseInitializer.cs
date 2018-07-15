using System;
using System.Collections.Generic;
using System.Data.Entity;
using KFZKonfigurator.Base;
using KFZKonfigurator.BusinessModels.Model;

namespace KFZKonfigurator.BusinessModels
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<KonfiguratorDbContext>
    {
        private readonly Random _random = new Random();

        protected override void Seed(KonfiguratorDbContext context) {
            context.Varnishes.AddRange(new List<Varnish> {
                new Varnish {Name = "Beige", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Black", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Blue", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Brown", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Green", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Metallic", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Red", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Silver", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "White", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)},
                new Varnish {Name = "Yellow", PriceEuro = GetNextPrice(400), PricePound = GetNextPrice(300)}
            });

            context.Rimses.AddRange(new List<Rims> {
                new Rims {Name = "FiveDoubleSpokes16", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "FiveDoubleSpokes18", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "FiveSpokes16", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "FiveSpokes18", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "FourMultiSpokes16", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "FourMultiSpokes18", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "FourSpokes16", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "FourSpokes18", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "TenSpokes16", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)},
                new Rims {Name = "TenSpokes18", PriceEuro = GetNextPrice(1000), PricePound = GetNextPrice(800)}
            });

            context.Equipments.AddRange(new List<Equipment> {
                new Equipment {Name = "ABS", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "AirConditioner", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "AllWheelDrive", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "ClimateAutomation", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "CruiseControl", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "MultiFunctionSteeringWheel", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "NavigationDevice", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "ParkingSensors", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "SeatHeater", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "SoundSystem", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "TowCoupling", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)},
                new Equipment {Name = "XenonLight", PriceEuro = GetNextPrice(2000), PricePound = GetNextPrice(1700)}
            });
        }

        private decimal GetNextPrice(int factor) {
            return _random.NextDouble().ToDecimal() * factor;
        }
    }
}