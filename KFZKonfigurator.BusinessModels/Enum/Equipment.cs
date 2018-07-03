using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.Base.Attributes;
using KFZKonfigurator.BusinessModels.Resources;

namespace KFZKonfigurator.BusinessModels.Enum
{
    public enum Equipment
    {
        [Price("520.99")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        AirConditioner,

        [Price("1020.50")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        ABS,

        [Price("900")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        SoundSystem,

        [Price("850")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        MultiFunctionSteeringWheel,

        [Price("570.80")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        AllWheelDrive,

        [Price("250")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        ClimateAutomation,

        [Price("130.95")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        XenonLight,

        [Price("256")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        TowCoupling,

        [Price("2100.99")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        CruiseControl,

        [Price("1300")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        SeatHeater,

        [Price("2400")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        ParkingSensors,

        [Price("650.50")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        NavigationDevice
    }
}