namespace BlueOnion.ViewModel.AutoMapper
{
        public static partial class ConfigMapper
        {
            public static void MapAll()
            {
                MapScaffolded();
                PageInfoMapping.Map();
            }
        }
}