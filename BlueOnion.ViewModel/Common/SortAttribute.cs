
namespace BlueOnion.ViewModel.Common
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class SortAttribute : System.Attribute
    {
        public SortAttribute()
        {
            DisableSort = false;
        }
        // indicates that this is a derived column and another column should be used for the actual sorting
        public string ColumnOverride { get; set; }
        // this field should not allow sorting at all
        public bool DisableSort { get; set; }
    }
}
