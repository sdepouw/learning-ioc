using System.Reflection;
using LearningIoC.Core;
using LearningIoC.Core.Interfaces;
using LearningIoC.Core.Interfaces.External;
using LearningIoC.DatabaseDependency;
using LearningIoC.PaymentGatewayDependency;
using Ninject.Extensions.Conventions;

namespace LearningIoC.DependencyResolution.Resolvers
{
    internal class NinjectConventionResolver : NinjectResolver
    {
        public override void Load()
        {
            // TODO: Better way to obtain desired assemblies?
            Assembly coreAssembly = Assembly.GetAssembly(typeof (IBusinessLogic));
            Assembly databaseDependencyAssembly = Assembly.GetAssembly(typeof (SqlWidgetRepository));
            Assembly paymentGatewayAssembly = Assembly.GetAssembly(typeof (PayPalPaymentService));
            
            Kernel.Bind(x => 
                // Select all classes from assemblies containing our interfaces and implementations
                x.From(coreAssembly, databaseDependencyAssembly, paymentGatewayAssembly).SelectAllClasses()
                // Exclude the types involved with special-case bindings
                .Excluding(typeof(IWidgetRepository), typeof(SqlWidgetRepository), typeof(CachedWidgetRepository))
                .Excluding(typeof(IRepository<>), typeof(SqlRepository<>), typeof(CachedRepository<>))
                // Bind all the located interfaces to their implementations
                .BindAllInterfaces());

            this.BindRepositoryWithCache(typeof(IRepository<>), typeof(SqlRepository<>), typeof(CachedRepository<>));
            this.BindRepositoryWithCache<IWidgetRepository, SqlWidgetRepository, CachedWidgetRepository>();
        }

        public override string ResolverName { get { return "Ninject (convention)"; } }
    }
}