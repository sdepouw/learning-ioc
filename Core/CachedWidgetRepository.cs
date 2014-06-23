using System;
using System.Collections.Generic;
using LearningIoC.Core.Interfaces.External;

namespace LearningIoC.Core
{
    public class CachedWidgetRepository : IWidgetRepository
    {
        private readonly IWidgetRepository widgetRepository;

        public CachedWidgetRepository(IWidgetRepository widgetRepository)
        {
            this.widgetRepository = widgetRepository;
        }

        // This could be HTTP cache or any form of caching. Cache invalidation, thread-safety, etc. ignored for demo purposes.
        private static List<string> _widgets; 
        public List<string> FetchWidgets()
        {
            if (_widgets == null)
            {
                _widgets = widgetRepository.FetchWidgets();
            }
            else
            {
                Console.WriteLine("Using cached widgets!");
            }
            return _widgets;
        }
    }
}