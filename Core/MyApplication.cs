using System.Collections.Generic;
using System.Linq;
using LearningNinject.Core.Interfaces;
using LearningNinject.Core.Interfaces.External;

namespace LearningNinject.Core
{
    public class MyApplication : IMyApplication
    {
        private readonly IBusinessLogic businessLogic;
        private readonly IWidgetRepository widgetRepository;
        private readonly IPaymentService paymentService;

        public MyApplication(IBusinessLogic businessLogic, IWidgetRepository widgetRepository, IPaymentService paymentService)
        {
            this.businessLogic = businessLogic;
            this.widgetRepository = widgetRepository;
            this.paymentService = paymentService;
        }

        public void Run()
        {
            businessLogic.Validate();
            
            List<string> widgets = widgetRepository.FetchWidgets();
            
            paymentService.MakePaymentForWidget(widgets.First());
        }
    }
}