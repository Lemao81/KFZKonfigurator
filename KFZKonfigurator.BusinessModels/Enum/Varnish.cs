using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.BusinessModels.Resources;

namespace KFZKonfigurator.BusinessModels.Enum
{
    public enum Varnish
    {
        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Silver,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Black,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Brown,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Red,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Blue,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Yellow,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        White,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Metallic,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Beige,

        [Display(ResourceType = typeof(OptionsDisplayResx))]
        Green
    }
}