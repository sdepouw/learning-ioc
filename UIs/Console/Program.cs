using System;
using LearningIoC.Core.Interfaces;
using LearningIoC.DependencyResolution;

namespace LearningIoC.Console
{
    public static class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Using IoC container: {0}{1}", Resolver.Instance.ResolverName, Environment.NewLine);
            var myApplication = Resolver.Instance.Get<IMyApplication>();
            myApplication.Run();
        }
    }
}
