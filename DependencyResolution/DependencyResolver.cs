using Ninject;

namespace LearningNinject.DependencyResolution
{
    // Maintains our resolver instance. Implementation details (i.e. the fact that we're using Ninject) is encapsulated.
    public static class DependencyResolver
    {
        private static IResolver _resolver;
        public static IResolver Resolver
        {
            get
            {
                // Only set up the resolver once.
                if (_resolver != null)
                {
                    return _resolver;
                }

                // Load Ninject's resolver up.
                var resolver = new NinjectModuleResolver();
                var kernel = new StandardKernel();
                kernel.Load(resolver);

                // Store resolver (in this case, Ninject's Kernel), and return.
                _resolver = resolver;
                return _resolver;
            }
        }
    }
}