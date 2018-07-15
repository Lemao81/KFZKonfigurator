using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.Base.Attributes;
using KFZKonfigurator.BusinessModels.Resources;

namespace KFZKonfigurator.BusinessModels.Enum
{
    public enum VarnishEnum
    {
        [Price("10")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Silver,

        [Price("20")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Black,

        [Price("30")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Brown,

        [Price("40")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Red,

        [Price("50")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Blue,

        [Price("60")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Yellow,

        [Price("70")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        White,

        [Price("80")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Metallic,

        [Price("90")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Beige,

        [Price("100")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        Green
    }
}