namespace KFZKonfigurator.Binding.Models
{
    public class DropdownOption<TEnum>
    {
        public string Label { get; set; }
        public TEnum Value { get; set; }
    }
}