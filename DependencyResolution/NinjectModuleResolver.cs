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
            this.BindRepositoryWithCache<IWidgetRepository, SqlWidgetRepository, CachedWidgetRepository>();
        }
    }
}