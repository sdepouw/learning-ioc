using System.Collections.Generic;

namespace LearningIoC.Core.Interfaces.External
{
    public interface IWidgetRepository
    {
        List<string> FetchWidgets();
    }
}