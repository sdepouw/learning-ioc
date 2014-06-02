using LearningNinject.Core.Interfaces;
using LearningNinject.DependencyResolution;

namespace LearningNinject.Console
{
    public static class Program
    {
        public static void Main()
        {
            var myApplication = DependencyResolverInstance.Resolver.Resolve<IMyApplication>();
            myApplication.Run();
        }
    }
}
