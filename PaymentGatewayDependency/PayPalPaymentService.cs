using System;
using LearningNinject.Core.Interfaces.External;

namespace LearningNinject.PaymentGatewayDependency
{
    public class PayPalPaymentService : IPaymentService
    {
        public void MakePaymentForWidget(string widget)
        {
            Console.WriteLine("Making payment to PayPal for one copy of the '{0}' widget.", widget);
        }
    }
}