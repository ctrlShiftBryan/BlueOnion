
namespace BlueOnion.ViewModel.Common
{
    /// <summary>
    /// Able to apply a specific binding to the property, rather than binding on the type
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class BindingAttribute : System.Attribute
    {
        public BindingAttribute(string binding)
        {
            Binding = binding;
        }
        public string Binding { get; set; }
    }
}
