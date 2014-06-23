﻿using LearningIoC.Core;
using LearningIoC.Core.Interfaces;
using LearningIoC.Core.Interfaces.External;
using LearningIoC.DatabaseDependency;
using LearningIoC.PaymentGatewayDependency;

namespace LearningIoC.DependencyResolution.Resolvers
{
    internal class NinjectExplicitResolver : NinjectResolver
    {
        public override void Load()
        {
            Bind<IMyApplication>().To<MyApplication>();
            Bind<IBusinessLogic>().To<BusinessLogic>();
            Bind<IPaymentService>().To<PayPalPaymentService>();
            this.BindRepositoryWithCache(typeof(IRepository<>), typeof(SqlRepository<>), typeof(CachedRepository<>));
            this.BindRepositoryWithCache<IWidgetRepository, SqlWidgetRepository, CachedWidgetRepository>();
        }

        public override string ResolverName { get { return "Ninject (explicit)"; } }
    }
}