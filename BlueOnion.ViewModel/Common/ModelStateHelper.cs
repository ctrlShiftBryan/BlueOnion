//TODO Move to MVC
//using System.Linq;
//using System.Web.Mvc;

//namespace ViewModel
//{
//    public static class ModelStateHelper
//    {

//        public static SimpleModelState ToJsonValidation(this ModelStateDictionary modelState)
//        {
//            var v = from m in modelState.AsEnumerable()
//                    from e in m.Value.Errors
//                    select new SimpleError  { Key = m.Key , ErrorMessage = e.ErrorMessage };
//            v = v.ToList();

//            var pe = v.Where(x => !string.IsNullOrEmpty(x.Key)).ToList();
//            var me = v.Where(x => string.IsNullOrEmpty(x.Key)).ToList();

//            return new SimpleModelState
//            {
//                IsValid = modelState.IsValid,
//                PropertyErrors = pe,
//                ModelErrors = me
//            };
//        }

        
//    }
//}
