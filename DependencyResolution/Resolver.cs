using LearningIoC.DependencyResolution.Resolvers;

namespace LearningIoC.DependencyResolution
{
    // Maintains our resolver instance. Implementation details (i.e. the fact that we're using Ninject) is encapsulated.
    public static class Resolver
    {
        public static TAbstractType Get<TAbstractType>()
        {
            return Instance.Get<TAbstractType>();
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
                _instance = new UnityResolver();
                _instance.Initialize();
                return _instance;
            }
        }
    }
}