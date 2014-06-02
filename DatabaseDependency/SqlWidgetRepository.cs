using System;
using System.Collections.Generic;
using LearningNinject.Core.Interfaces.External;

namespace LearningNinject.DatabaseDependency
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