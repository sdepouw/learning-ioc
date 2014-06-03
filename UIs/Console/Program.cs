using LearningNinject.Core.Interfaces;
using LearningNinject.DependencyResolution;

namespace LearningNinject.Console
{
    public static class Program
    {
        public static void Main()
        {
            var myApplication = Resolver.Get<IMyApplication>();
            myApplication.Run();
        }
    }
}
