using System;
using LearningIoC.Core.Interfaces.External;

namespace LearningIoC.PaymentGatewayDependency
{
    public class PayPalPaymentService : IPaymentService
    {
        public void MakePaymentForWidget(string widget)
        {
            Console.WriteLine("Making payment to PayPal for one copy of the '{0}' widget.", widget);
        }
    }
}