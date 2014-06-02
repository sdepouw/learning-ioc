using System;
using System.Collections.Generic;
using System.Linq;
using LearningNinject.Core.Exceptions;
using LearningNinject.Core.Interfaces;
using LearningNinject.Core.Interfaces.External;

namespace LearningNinject.Core
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