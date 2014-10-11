//using System;
//using System.Web.Http.Metadata;

//namespace ViewModel
//{
//    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
//    public class PreventEditAttribute : Attribute//, IMetadataAware
//    {
//        public PreventEditAttribute(bool preventEdit, bool renderAsDisplayFor, bool allowEditOnCreate)
//        {
//            PreventEdit = preventEdit;
//            RenderAsDisplayFor = renderAsDisplayFor;
//            AllowEditOnCreate = allowEditOnCreate;
//        }       

//        public PreventEditAttribute()
//        {
//            PreventEdit = true;
//            RenderAsDisplayFor = false;
//            AllowEditOnCreate = false;
//        }

//        public bool PreventEdit { get; set; }
//        public bool RenderAsDisplayFor { get; set; }
//        public bool AllowEditOnCreate { get; set; }

//        public void OnMetadataCreated(ModelMetadata metadata)
//        {
//            metadata.AdditionalValues["PreventEdit"] = PreventEdit;
//            metadata.AdditionalValues["RenderAsDisplayFor"] = RenderAsDisplayFor;
//            metadata.AdditionalValues["AllowEditOnCreate"] = AllowEditOnCreate;
//        }
//    }
//}
