using System.ComponentModel;
using System.Linq;

namespace ViewModel
{
    public class ListWithColumns<T> : System.Collections.Generic.List<T>
    {
        public System.Collections.Generic.List<string> Columns 
        {
            get
            {
                return TypeDescriptor.GetProperties(typeof (T)).Cast<PropertyDescriptor>().Select(x => x.Name).ToList();
            }
        }
    }
}
