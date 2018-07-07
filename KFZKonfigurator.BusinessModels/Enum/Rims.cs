using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.Base.Attributes;
using KFZKonfigurator.BusinessModels.Resources;

namespace KFZKonfigurator.BusinessModels.Enum
{
    public enum Rims
    {
        [Price("532")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FiveDoubleSpokes16,

        [Price("150")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FiveSpokes16,

        [Price("850")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FourSpokes16,

        [Price("746")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        TenSpokes16,

        [Price("280")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FourMultiSpokes16,

        [Price("280")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FiveDoubleSpokes18,

        [Price("405")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FiveSpokes18,

        [Price("780")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FourSpokes18,

        [Price("500")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        TenSpokes18,

        [Price("310")] [Display(ResourceType = typeof(OptionsDisplayResx))]
        FourMultiSpokes18
    }
}