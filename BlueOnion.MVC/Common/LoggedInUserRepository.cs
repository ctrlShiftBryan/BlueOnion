
using BlueOnion.Domain.Interfaces;
using BlueOnion.Domain.Model;
using BlueOnion.Repository;
using BlueOnion.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace BlueOnion.MVC.Common
{
    public class LoggedInUserRepository : IUser, IPrincipal
    {
        private readonly IPrincipal _principal;
        private readonly IUnitOfWork<BlueOnionContext> _unitOfWork;
        private Guid _id;
        private ICollection<UserRole> _userRoles;
        private User _user;

        public LoggedInUserRepository(IPrincipal principal, IUnitOfWork unitOfWork)
        {
            _principal = principal;
            _unitOfWork = unitOfWork;
            if (principal != null)
                Identity = principal.Identity;

        }

        public bool IsInRole(string role)
        {
            return _principal.IsInRole(role);
        }

        //defaults in constructor

        public List<string> ContextRecordStatuses { get; set; }
        private DateTime? _contextDateTime;

        //returns current datetime if not set
        public DateTime? ContextDateTime
        {
            get
            {
                return _contextDateTime.HasValue ? _contextDateTime : DateTime.Now;
            }

            set { _contextDateTime = value; }
        }

        public IIdentity Identity { get; private set; }

        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        private void GetUser()
        {
            _user = _unitOfWork.Context.Users.Include("UserRoles").Include("UserRoles.Role").Single(x => x.UserName == Identity.Name);
        }

        public Guid Id
        {
            get
            {
                GetUser();
                return _user.Id;
            }
            set { _id = value; }
        }

        public ICollection<UserRole> UserRoles
        {
            get
            {
                GetUser();
                return _user.UserRoles;
            }
            set { _userRoles = value; }
        }

        public string UserName
        {
            get
            {
                return Identity.Name;

            }

            set
            {

            }
        }
    }
}