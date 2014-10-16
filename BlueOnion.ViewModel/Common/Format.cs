namespace BlueOnion.ViewModel.Common
{
    public class Format
    {
        public Format()
        {
            Binding = "html";
        }

        public string Binding { get; set; }
        public string FormatString { get; set; }
    }
}