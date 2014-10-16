
namespace BlueOnion.ViewModel.Common
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class OptionTargetAttribute : System.Attribute
    {
        public OptionTargetAttribute(string name, int limit = int.MaxValue)
        {
            TargetProperty = name;
            Limit = limit;
        }
        // used to wire up the Image Select Control
        public string TargetProperty { get; set; }
        
        // used to limit the number of images you can add to a model
        public int Limit { get; set; }
    }
}
