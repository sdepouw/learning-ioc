using LearningIoC.DependencyResolution;
using LearningNinject.Core.Interfaces;

namespace LearningIoC.Console
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
