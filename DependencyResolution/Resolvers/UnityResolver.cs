using LearningNinject.Core;
using LearningNinject.Core.Interfaces;
using LearningNinject.Core.Interfaces.External;
using LearningNinject.DatabaseDependency;
using LearningNinject.PaymentGatewayDependency;
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
            // Binding to core classes.
            container.RegisterType<IMyApplication, MyApplication>();
            container.RegisterType<IBusinessLogic, BusinessLogic>();

            // Binding to extenral dependencies.
            container.RegisterType<IPaymentService, PayPalPaymentService>();
            container.RegisterType<IWidgetRepository, CachedWidgetRepository>(new InjectionMember[] { new InjectionConstructor(new SqlWidgetRepository()) });

            // TODO: Figure out how to use cached repository pattern with generic repository in Unity.
            container.RegisterType(typeof(IRepository<>), typeof(SqlRepository<>));
        }
    }
}