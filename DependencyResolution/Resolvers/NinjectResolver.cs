using Ninject;
using Ninject.Modules;

namespace LearningIoC.DependencyResolution.Resolvers
{
    internal abstract class NinjectResolver : NinjectModule, IResolver
    {
        public TAbstractType Get<TAbstractType>()
        {
            return Kernel.Get<TAbstractType>();
        }

        public void Initialize()
        {
            var kernel = new StandardKernel();
            kernel.Load(this);
        }

        public abstract string ResolverName { get; }
    }
}