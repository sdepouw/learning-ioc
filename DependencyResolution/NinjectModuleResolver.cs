using LearningNinject.Core;
using LearningNinject.Core.Interfaces;
using LearningNinject.Core.Interfaces.External;
using LearningNinject.DatabaseDependency;
using LearningNinject.PaymentGatewayDependency;
using Ninject;
using Ninject.Modules;

namespace LearningNinject.DependencyResolution
{
    internal class NinjectModuleResolver : NinjectModule, IResolver
    {
        public TAbstractType Get<TAbstractType>()
        {
            return Kernel.Get<TAbstractType>();
        }

        public override void Load()
        {
            // Binding to core classes.
            Bind<IMyApplication>().To<MyApplication>();
            Bind<IBusinessLogic>().To<BusinessLogic>();

            // Binding to extenral dependencies.
            Bind<IPaymentService>().To<PayPalPaymentService>();
            BindRepositoryWithCache<IWidgetRepository, SqlWidgetRepository, CachedWidgetRepository>();
        }

        // In normal circumstances, use the cached repository.
        // Inside the cached repository class, we need the real repository.
        // Consumer does not have to worry, still calls Resolver.Get<TInterface>().
        // Real repository does not have to be concerned about caching logic.
        private void BindRepositoryWithCache<TInterface, TRepository, TCachedRepository>() 
            where TRepository : TInterface
            where TCachedRepository : TInterface
        {
            Bind<TInterface>().To<TRepository>().WhenInjectedExactlyInto<TCachedRepository>();
            Bind<TInterface>().To<TCachedRepository>();
        }
    }
}