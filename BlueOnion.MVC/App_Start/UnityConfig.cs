
using BlueOnion.Domain.Interfaces;
using BlueOnion.MVC.Common;
using BlueOnion.Repository;
using BlueOnion.Repository.Common;
using BlueOnion.Repository.Interfaces;
using BlueOnion.Service;
using BlueOnion.ViewModel.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity.Mvc5;

namespace BlueOnion.MVC
{
    public static partial class UnityConfig
    {
        private static readonly int ServicesMaxReturn = 1000;

        private static InjectionMember[] ServicesInjectionMember()
        {
            return new InjectionMember[]
            {
                new InjectionConstructor(typeof(IUnitOfWork), typeof(IUser<Guid>), typeof(IRepositoriesWrapper), ServicesMaxReturn)
            };
        }

        public static IUnityContainer RegisterComponents()
        {
            _container = Register(new UnityContainer());
            //change providers and resolvers
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(_container);
            var oldProvider = FilterProviders.Providers.Single(f => f is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(oldProvider);
            var provider = new UnityFilterAttributeFilterProvider(_container);
            FilterProviders.Providers.Add(provider);
            return _container;
        }

        static UnityContainer _container;

        public static UnityContainer Register(UnityContainer container)
        {
            _container = container;
            _container.RegisterInstance(new UnitOfWork(), new HttpContextDisposableLifetimeManager<UnitOfWork>());
            _container.RegisterType<IUnitOfWork<BlueOnionContext>, UnitOfWork>();
            _container.RegisterType<IPrincipal>(new InjectionFactory(u => HttpContext.Current.User));
            //_container.RegisterType<IUtilityService, UtilityService>(new HttpContextDisposableLifetimeManager<UtilityService>());
            _container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextDisposableLifetimeManager<UnitOfWork>());
            _container.RegisterType<IUser, LoggedInUserRepository>();

            RegisterAgRepositories();
            RegisterDomainServices();
            RegisterViewModelServices();

            //_container.RegisterType<IUserSecurityProfileQueryService, UserSecurityProfileQueryService>(
            //    new HttpContextDisposableLifetimeManager<UserSecurityProfileQueryService>(),
            //    new InjectionConstructor(typeof(IUnitOfWork), typeof(IUser), typeof(IRepositoriesWrapper), ServicesMaxReturn),
            //    new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<CachingBehaviour>());

            _container.RegisterType<IRepositoriesWrapper, RepositoriesWrapper>(new HttpContextDisposableLifetimeManager<RepositoriesWrapper>());
            _container.RegisterType<IViewModelServices, ViewModelServices>(new HttpContextDisposableLifetimeManager<ViewModelServices>());
            _container.RegisterType<IDomainServices, DomainServices>(new HttpContextDisposableLifetimeManager<DomainServices>());
            _container.AddNewExtension<Interception>();

            return _container;
        }
    }
}