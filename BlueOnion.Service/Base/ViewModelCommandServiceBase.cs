using AutoMapper;
using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;
using BlueOnion.ViewModel;
using BlueOnion.ViewModel.Common;
using BlueOnion.ViewModel.Interfaces;
using System;
using System.Linq;
using System.Net;

namespace BlueOnion.Service.Base
{
    public abstract class ViewModelCommandServiceBase<AR, VM, Dto, DDto, REPO, TId> : ViewModelServiceBase<AR, VM, Dto, DDto, TId>
        where AR : class, IAggregateRoot<TId>, new()
        where VM : IViewModelBase<Dto, DDto, TId>, new()
        where Dto : class, IDto<TId>, new()
        where DDto : class, IDto<TId>, new()
        where REPO : IRepository<AR, TId>
    {
        protected readonly REPO _repo;
        protected AR _domainObject;

        public ViewModelCommandServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, REPO repo, IDomainServices domainServices)
            : base(unitOfWork, user, repositories, domainServices)
        {
            _repo = repo;
        }

        //populate model and property errors and set status code
        //todo create a simple modelstate collection all services can share
        public VM ReturnInvalid(SimpleModelState ms, VM vm)
        {
            //moves errors from simple model state to VM
            //TODO actually validate model here instead of depending on
            //errors passed in simple modestate from model binding

            //only add validation errors for fields validation reqruested for
            if (vm.OnlyValidateFields.Any())
            {
                ms.ModelErrors = ms.ModelErrors.Where(x => vm.OnlyValidateFields.Contains(x.Key)).ToList();
                ms.PropertyErrors = ms.PropertyErrors.Where(x => vm.OnlyValidateFields.Contains(x.Key)).ToList();

                //its valid if we have no errors
                ms.IsValid = (!ms.ModelErrors.Any() && !ms.PropertyErrors.Any());
            }

            vm.ModelState = ms;

            if (!ms.IsValid)
                vm.StatusCode = (int)HttpStatusCode.BadRequest;

            return vm;
        }

        //save changes copies from vm; call uow save
        public virtual VM ExecuteSave()
        {
            UnitOfWork.Save();

            Mapper.Map(_domainObject, _vm.Item);
            Mapper.Map(_domainObject, _vm.ItemDetail);

            _vm.Message = String.Format("{0} has been updated", _vm.Title);
            return _vm;
        }

        //determines if item detail in view model is create or update 
        public bool IsCreate()
        {

            if (_vm.ItemDetail.Id == null)
                return true;
            return _vm.ItemDetail.Id.Equals(GetDefaultIdValue());
        }

        //pulls from database or creates new object
        public virtual bool DetermineInsertOrUpdate(bool forValidation = false)
        {
            if (IsCreate())
            {
                var guid = GetInsertIdValue();
                _domainObject = new AR { Id = guid };
                _vm.ItemDetail.Id = guid;
                _repo.Add(_domainObject);
                return true;
            }
            else
            {
                UnitOfWork.DebugChangeTracker();
                _domainObject = _repo.GetById(_vm.ItemDetail.Id);
                //todo clear anything from change tracker?

                UnitOfWork.DebugChangeTracker();
                return false;
            }
        }

        public abstract TId GetDefaultIdValue();
        public abstract TId GetInsertIdValue();
        //sets audit field info
        public virtual void SetAuditFields(bool isInsert)
        {
            _domainObject.CreatedDate = DateTime.Now;
            _domainObject.CreatedBy = User.UserName.ToString();
        }

        //copies changes to change tracked domain object
        public virtual void CopyToChangeTracked(VM vm)
        {
            var isInsert = DetermineInsertOrUpdate();
            UnitOfWork.DebugChangeTracker();
            //copy from dto to domain
            Mapper.Map(vm.ItemDetail, _domainObject);
            UnitOfWork.DebugChangeTracker();
            SetAuditFields(isInsert);
            //todo see if we can just handle this in automapper
            //we require this because EF change tracking things the 
            //child collections that where "added" from the dto are inserts but they 
            //are not
            _repo.SetCollectionsUnmodified(_domainObject);
        }

        public virtual void Validate()
        {
            CopyToChangeTracked(_vm);

            //_vm.Message = String.Format("{0} has been updated", _vm.Title);
            foreach (var validationResults in UnitOfWork.GetValidationErrors())
            {
                var entityType = validationResults.Entry.Entity.GetType();
                var isRoot = entityType == typeof(AR);

                var propertyPrefix = "ItemDetail.";

                //TODO this only handle child properties 1 level deep. make it go 2+
                if (!isRoot)
                {
                    propertyPrefix = String.Format("{0}{1}.", propertyPrefix, entityType.Name);
                }

                foreach (var error in validationResults.ValidationErrors)
                {
                    var fullPropertyName = String.Format("{0}{1}", propertyPrefix, error.PropertyName);
                    _vm.ModelState.PropertyErrors.Add(new SimpleError() { Key = fullPropertyName, ErrorMessage = error.ErrorMessage });
                }
            }
            _vm.ModelState.IsValid = !_vm.ModelState.PropertyErrors.Any();
        }

        //takes a viewmodel and validates then saves
        public virtual VM SaveViewModel(VM pvm, SimpleModelState modelState, bool validateOnly = false)
        {

            _vm = pvm;
            _vm.ModelState = modelState;
            UnitOfWork.DebugChangeTracker();
            Validate();
            UnitOfWork.DebugChangeTracker();
            return modelState.IsValid ? (validateOnly ? _vm : ExecuteSave()) : ReturnInvalid(modelState, _vm);
        }

        protected void SetDbConcurrencyException()
        {
            _vm.ModelState.IsValid = false;
            _vm.StatusCode = (int)HttpStatusCode.BadRequest;
            if (_vm.ModelState == null)
                _vm.ModelState = new SimpleModelState();
            _vm.ModelState.PropertyErrors.Add(new SimpleError()
            {
                Key = "",
                ErrorMessage = "DBConcurrencyException"
            });
        }
    }
}