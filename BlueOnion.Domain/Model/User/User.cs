using BlueOnion.Domain.Interfaces;
using BlueOnion.Domain.Model.Base;
using System;

namespace BlueOnion.Domain.Model
{
    public class User: AggregateRoot<Guid>, IUser<Guid>
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
}