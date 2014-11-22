
using BlueOnion.Domain.Interfaces;
using BlueOnion.ViewModel.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;


namespace BlueOnion.ViewModel
{
    public abstract class ViewModelNonGenericBase
    {

        public ViewModelNonGenericBase()
        {
            ModelState = new SimpleModelState();
            KOMapping = new KOMapping();
            Meta = new List<string>();
            OnlyValidateFields = new List<string>();
            StatusCode = (int)HttpStatusCode.OK;
            HasDialog = false;
            HasAlerts = true;
            FormControlClasses = "form-group col-sm-6 col-md-4 col-lg-3";
            _canDelete = true;
            //User = new Use();
            //var manageSubNav = new List<NavigationItemDto>
            //{
            //    new NavigationItemDto { DisplayName = "Address", CssClass = "", Url = "/HiltonWebPim2014/DedupAddress"},
            //    new NavigationItemDto { DisplayName = "Individuals", CssClass = "", Url = "/HiltonWebPim2014/DedupContactsIndividualNameDuplicate" },
            //    new NavigationItemDto { DisplayName = "Entities", CssClass = "", Url = "/HiltonWebPim2014/DuplicateEntity"},
            //};

            //NavigationItemDto authenticationNavItem;
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    authenticationNavItem = new NavigationItem
            //    {
            //        DisplayName = "Logout",
            //        CssClass = "fa-sign-out",
            //        Url = "/HiltonWebPim2014/Authentication/SignOut"
            //    };
            //else
            //    authenticationNavItem = new NavigationItem
            //    {
            //        DisplayName = "Login",
            //        CssClass = "fa-sign-in",
            //        Url = ""
            //    };

            NavigationItems = new List<NavigationItemDto>
            {
                new NavigationItemDto {DisplayName = "Users", CssClass = "fa-wrench", Url = "/Users"},
            };


        }

        private readonly bool _canDelete;
        public abstract List<ColumnData> Columns { get; }
        public bool HasAlerts { get; set; }
        public bool HasDialog { get; set; }
        public bool HasExport { get; set; }
        public bool HideNav { get; set; }
        public bool IsLoading { get; set; }
        public bool IsRowLoading { get; set; }
        public bool IsTableLoading { get; set; }
        public bool LeaveOpenOnAjaxSuccess { get; set; }
        public int StatusCode { get; set; }
        public KOMapping KOMapping { get; set; }
        public List<NavigationItemDto> NavigationItems { get; set; }
        public List<string> Meta { get; set; }
        public List<string> OnlyValidateFields { get; set; }
        public object Grid { get; set; }
        public SimpleModelState ModelState { get; set; }
        public string FormControlClasses { get; set; }
        public string Message { get; set; }
        public string RedirectResponse { get; set; }
        public string Title { get; set; }
        public IUser<Guid> User { get; set; }
        public virtual bool CanDelete
        {
            get { return _canDelete; }
        }

        public string ToJson()
        {
            var json = JsonConvert.SerializeObject(this,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return json;
        }


    }
}