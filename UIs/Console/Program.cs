using LearningIoC.Core.Interfaces;
using LearningIoC.DependencyResolution;

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
