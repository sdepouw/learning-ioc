using LearningNinject.Core;
using LearningNinject.Core.Interfaces;
using LearningNinject.Core.Interfaces.External;
using LearningNinject.DatabaseDependency;
using LearningNinject.PaymentGatewayDependency;

namespace LearningIoC.DependencyResolution.Resolvers
{
    internal class NinjectExplicitResolver : NinjectResolver
    {
        public override void Load()
        {
            // Binding to core classes.
            Bind<IMyApplication>().To<MyApplication>();
            Bind<IBusinessLogic>().To<BusinessLogic>();
            

            // Binding to extenral dependencies.
            Bind<IPaymentService>().To<PayPalPaymentService>();
            this.BindRepositoryWithCache(typeof(IRepository<>), typeof(SqlRepository<>), typeof(CachedRepository<>));
            this.BindRepositoryWithCache<IWidgetRepository, SqlWidgetRepository, CachedWidgetRepository>();
        }
    }
}