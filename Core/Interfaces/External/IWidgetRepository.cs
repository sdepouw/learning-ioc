using System.Collections.Generic;

namespace LearningNinject.Core.Interfaces.External
{
    public interface IWidgetRepository
    {
        List<string> FetchWidgets();
    }
}