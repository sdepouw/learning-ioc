using Ninject.Modules;

namespace LearningNinject.DependencyResolution
{
    internal static class NinjectModuleExtensions
    {
        /// <remarks>
        /// In normal circumstances, use the cached repository.
        /// Inside the cached repository class, we need the real repository.
        /// Consumer does not have to worry, still calls the Resolver.Get method.
        /// Real repository does not have to be concerned about caching logic.
        /// </remarks>
        internal static void BindRepositoryWithCache<TInterface, TRepository, TCachedRepository>(this NinjectModule ninjectModule)
            where TRepository : TInterface
            where TCachedRepository : TInterface
        {
            ninjectModule.Bind<TInterface>().To<TRepository>().WhenInjectedExactlyInto<TCachedRepository>();
            ninjectModule.Bind<TInterface>().To<TCachedRepository>();
        }
    }
}