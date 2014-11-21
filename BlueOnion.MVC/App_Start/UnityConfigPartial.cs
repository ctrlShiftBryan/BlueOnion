
namespace BlueOnion.MVC
{
    public static partial class UnityConfig
    {
        private static void RegisterViewModelServices()
        {
            //_container.RegisterType<IRoleViewModelQueryService, RoleViewModelQueryService>(new HttpContextDisposableLifetimeManager<RoleViewModelQueryService>());
            //_container.RegisterType<IRoleViewModelCommandService, RoleViewModelCommandService>(new HttpContextDisposableLifetimeManager<RoleViewModelCommandService>());
            //_container.RegisterType<IUserViewModelQueryService, UserViewModelQueryService>(new HttpContextDisposableLifetimeManager<UserViewModelQueryService>());
            //_container.RegisterType<IUserViewModelCommandService, UserViewModelCommandService>(new HttpContextDisposableLifetimeManager<UserViewModelCommandService>());
 
        }
        private static void RegisterDomainServices()
        {
            //_container.RegisterType<IRoleQueryService, RoleQueryService>(new HttpContextDisposableLifetimeManager<RoleQueryService>(), ServicesInjectionMember());
            //_container.RegisterType<IRoleCommandService, RoleCommandService>(new HttpContextDisposableLifetimeManager<RoleCommandService>(), ServicesInjectionMember());
            //_container.RegisterType<IUserQueryService, UserQueryService>(new HttpContextDisposableLifetimeManager<UserQueryService>(), ServicesInjectionMember());
            //_container.RegisterType<IUserCommandService, UserCommandService>(new HttpContextDisposableLifetimeManager<UserCommandService>(), ServicesInjectionMember());
        
        }
        private static void RegisterAgRepositories()
        {
            //_container.RegisterType<IRoleRepository, RoleRepository>(new InjectionConstructor(typeof(IUser<Guid>), typeof(IUnitOfWork<BlueOnionContext>), 1000));
            //_container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(typeof(IUser<Guid>), typeof(IUnitOfWork<BlueOnionContext>), 1000));
      
        }
    }
}