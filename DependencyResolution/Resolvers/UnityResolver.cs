using System;
using LearningIoC.Core;
using LearningIoC.Core.Interfaces;
using LearningIoC.Core.Interfaces.External;
using LearningIoC.DatabaseDependency;
using LearningIoC.PaymentGatewayDependency;
using Microsoft.Practices.Unity;

namespace LearningIoC.DependencyResolution.Resolvers
{
    internal class UnityResolver : IResolver
    {
        private readonly UnityContainer container = new UnityContainer();

        public TAbstractType Get<TAbstractType>()
        {
            return container.Resolve<TAbstractType>();
        }

        public void Initialize()
        {
            container.RegisterType<IMyApplication, MyApplication>();
            container.RegisterType<IBusinessLogic, BusinessLogic>();
            container.RegisterType<IPaymentService, PayPalPaymentService>();
            container.RegisterType<IWidgetRepository, CachedWidgetRepository>(new InjectionMember[] { new InjectionConstructor(new SqlWidgetRepository()) });

            // http://stackoverflow.com/a/24374652/100534
            var cachedRepositoryFactory = new InjectionFactory((ctr, type, str) =>
            {
                var genericType = type.GenericTypeArguments[0];
                var sqlRepoType = typeof(SqlRepository<>).MakeGenericType(genericType);
                var sqlRepoInstance = Activator.CreateInstance(sqlRepoType);
                var cachedRepoType = Activator.CreateInstance(type, sqlRepoInstance);
                return cachedRepoType;
            });

            container.RegisterType(typeof(IRepository<>), typeof(CachedRepository<>), new InjectionMember[] { cachedRepositoryFactory });
        }

        public string ResolverName { get { return "Unity"; } }
    }
}