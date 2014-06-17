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
            // Select all assemblies containing interfaces and implementations.
            var assemblies = new List<Assembly>
            {
                // TODO: Better way to obtain desired assemblies?
                Assembly.GetAssembly(typeof (IBusinessLogic)),
                Assembly.GetAssembly(typeof (SqlWidgetRepository)),
                Assembly.GetAssembly(typeof (PayPalPaymentService)),
            };
            
            // Bind all interfaces to implementations, excluding special case where one interface has multiple implementations.
            Kernel.Bind(x => x.From(assemblies).SelectAllClasses()
                .Excluding(typeof(IWidgetRepository), typeof(SqlWidgetRepository), typeof(CachedWidgetRepository))
                .BindAllInterfaces());
            this.BindRepositoryWithCache<IWidgetRepository, SqlWidgetRepository, CachedWidgetRepository>();
        }
    }
}