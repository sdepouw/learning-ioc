using System;
using System.Collections.Generic;
using LearningIoC.Core.Interfaces.External;

namespace LearningIoC.DatabaseDependency
{
    public class SqlWidgetRepository : IWidgetRepository
    {
        public List<string> FetchWidgets()
        {
            Console.WriteLine("Talking to SQL Database to get widgets.");
            return new List<string> {"Doodad", "Gizmo"};
        }
    }
}