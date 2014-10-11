using System.Collections.Generic;

namespace ViewModel
{
    public class SimpleModelState
    {
        public SimpleModelState()
        {
            PropertyErrors = new List<SimpleError>();
            ModelErrors = new List<SimpleError>();
        }
        public bool IsValid { get; set; }
        public List<SimpleError> PropertyErrors { get; set; }
        public List<SimpleError> ModelErrors { get; set; }

        public void AddError(string property, string message)
        {
            if(string.IsNullOrWhiteSpace(property))
                ModelErrors.Add(new SimpleError() { Key = property, ErrorMessage = message });
            else
            {
                PropertyErrors.Add(new SimpleError() { Key = property, ErrorMessage = message });
            }
        }

    }
}