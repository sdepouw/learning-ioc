using Ninject;

namespace LearningNinject.DependencyResolution
{
    // Maintains our resolver instance. Implementation details (i.e. the fact that we're using Ninject) is encapsulated.
    public static class Resolver
    {
        private static IResolver _instance;
        public static IResolver Instance
        {
            get
            {
                // Only set up the resolver once.
                if (_instance != null)
                {
                    return _instance;
                }

                // Load Ninject's resolver up.
                var resolver = new NinjectModuleResolver();
                var kernel = new StandardKernel();
                kernel.Load(resolver);

                // Store resolver (in this case, Ninject's Kernel), and return.
                _instance = resolver;
                return _instance;
            }
        }
    }
}