using LearningIoC.Core;
using LearningIoC.Core.Interfaces;
using LearningIoC.Core.Interfaces.External;
using LearningIoC.DatabaseDependency;
using LearningIoC.PaymentGatewayDependency;
using StructureMap;

namespace LearningIoC.DependencyResolution.Resolvers
{
    public class StructureMapResolver : IResolver
    {
        private readonly Container container = new Container();

        public TAbstractType Get<TAbstractType>()
        {
            return container.GetInstance<TAbstractType>();
        }

        public void Initialize()
        {
            container.Configure(x =>
            {
                x.For<IMyApplication>().Use<MyApplication>();
                x.For<IBusinessLogic>().Use<BusinessLogic>();
                x.For<IPaymentService>().Use<PayPalPaymentService>();

                x.For<IWidgetRepository>().Use<SqlWidgetRepository>();
                x.For(typeof (IRepository<>)).Use(typeof (SqlRepository<>));
            });
        }
    }
}