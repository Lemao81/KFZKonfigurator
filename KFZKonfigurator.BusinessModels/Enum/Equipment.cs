using KFZKonfigurator.Base.Attributes;

namespace KFZKonfigurator.BusinessModels.Enum
{
    public enum Equipment
    {
        [Price("520.99")] AirConditioner,
        [Price("1020.50")] ABS,
        [Price("900")] SoundSystem,
        [Price("850")] MultiFunctionSteeringWheel,
        [Price("570.80")] AllWheelDrive,
        [Price("250")] ClimateAutomation,
        [Price("130.95")] XenonLight,
        [Price("256")] TowCoupling,
        [Price("2100.99")] CruiseControl,
        [Price("1300")] SeatHeater,
        [Price("2400")] ParkingSensors,
        [Price("650.50")] NavigationDevice
    }
}