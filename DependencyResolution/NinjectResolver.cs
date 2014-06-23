using Ninject;
using Ninject.Modules;

namespace LearningNinject.DependencyResolution
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
    }
}