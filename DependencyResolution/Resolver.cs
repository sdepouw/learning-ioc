using Ninject;

namespace LearningNinject.DependencyResolution
{
    // Maintains our resolver instance. Implementation details (i.e. the fact that we're using Ninject) is encapsulated.
    public static class Resolver
    {
        public static T Get<T>()
        {
            return Instance.Get<T>();
        }

        private static IResolver _instance;
        private static IResolver Instance
        {
            get
            {
                // Only set up the resolver once.
                if (_instance != null)
                {
                    return _instance;
                }
   
                // Store resolver (in this case, Ninject's Kernel), and return.
                _instance = Initialize();
                return _instance;
            }
        }

        private static NinjectModuleResolver Initialize()
        {
            // Load Ninject's resolver up.
            var resolver = new NinjectModuleResolver();
            var kernel = new StandardKernel();
            kernel.Load(resolver);
            return resolver;
        }
    }
}