
namespace ViewModel
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class HiddenAttribute : System.Attribute
    {
        public HiddenAttribute()
        {
            Hidden = true;
        }

        public bool Hidden { get; set; }
    }
}
