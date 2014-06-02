using LearningNinject.Core.Interfaces;
using LearningNinject.DependencyResolution;

namespace LearningNinject.Console
{
    public static class Program
    {
        public static void Main()
        {
            var myApplication = DependencyResolver.Resolver.Resolve<IMyApplication>();
            myApplication.Run();
        }
    }
}
