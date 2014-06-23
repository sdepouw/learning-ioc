using LearningIoC.DependencyResolution.Resolvers;

namespace LearningIoC.DependencyResolution
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
   
                // Store resolver and return.
                _instance = new StructureMapResolver();
                _instance.Initialize();
                return _instance;
            }
        }
    }
}