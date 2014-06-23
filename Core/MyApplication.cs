using System.Collections.Generic;
using System.Linq;
using LearningIoC.Core.Interfaces;
using LearningIoC.Core.Interfaces.External;
using LearningIoC.Core.Model;

namespace LearningIoC.Core
{
    public class MyApplication : IMyApplication
    {
        private readonly IBusinessLogic businessLogic;
        private readonly IWidgetRepository widgetRepository;
        private readonly IRepository<Gizmo> gizmoRepository; 
        private readonly IPaymentService paymentService;

        public MyApplication(IBusinessLogic businessLogic, IWidgetRepository widgetRepository, IRepository<Gizmo> gizmoRepository, IPaymentService paymentService)
        {
            this.businessLogic = businessLogic;
            this.widgetRepository = widgetRepository;
            this.gizmoRepository = gizmoRepository;
            this.paymentService = paymentService;
        }

        public void Run()
        {
            businessLogic.Validate();
            
            List<string> widgets = widgetRepository.FetchWidgets();

            gizmoRepository.Get();
            gizmoRepository.Get();
            gizmoRepository.Get();

            paymentService.MakePaymentForWidget(widgets.First());
        }
    }
}