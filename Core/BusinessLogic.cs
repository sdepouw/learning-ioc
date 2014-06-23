using System;
using System.Collections.Generic;
using System.Linq;
using LearningIoC.Core.Exceptions;
using LearningIoC.Core.Interfaces;
using LearningIoC.Core.Interfaces.External;

namespace LearningIoC.Core
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IWidgetRepository widgetRepository;

        public BusinessLogic(IWidgetRepository widgetRepository)
        {
            this.widgetRepository = widgetRepository;
        }

        public void Validate()
        {
            List<string> widgets = widgetRepository.FetchWidgets();
            if (!widgets.Any())
            {
                throw new BusinessLogicValidationFailedException();
            }
            Console.WriteLine("Business Logic has validated the wdigets.");
        }
    }
}