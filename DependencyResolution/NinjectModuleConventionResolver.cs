using System.Collections.Generic;
using System.Reflection;
using LearningNinject.Core;
using LearningNinject.Core.Interfaces;
using LearningNinject.Core.Interfaces.External;
using LearningNinject.DatabaseDependency;
using LearningNinject.PaymentGatewayDependency;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace LearningNinject.DependencyResolution
{
    internal class NinjectModuleConventionResolver : NinjectModule, IResolver
    {
        public TAbstractType Get<TAbstractType>()
        {
            return Kernel.Get<TAbstractType>();
        }

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
                // Bind all the located interfaces to their implementations
                .BindAllInterfaces());
            this.BindRepositoryWithCache<IWidgetRepository, SqlWidgetRepository, CachedWidgetRepository>();
        }
    }
}