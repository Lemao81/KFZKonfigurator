using System;
using KFZKonfigurator.Binding.Enum;

namespace KFZKonfigurator.Binding.Utils
{
    public static class MappingExtensions
    {
        public static string MapToText(this TextboxType type)
        {
            switch (type)
            {
                case TextboxType.Text:
                    return "text";
                case TextboxType.Email:
                    return "email";
                case TextboxType.NumericInteger:
                case TextboxType.NumericDecimal:
                    return "number";
                default:
                    throw new ArgumentException();
            }
        }
    }
}