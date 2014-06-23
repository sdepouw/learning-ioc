namespace LearningIoC.DependencyResolution.Resolvers
{
    public interface IResolver
    {
        TAbstractType Get<TAbstractType>();
        void Initialize();
        string ResolverName { get; }
    }
}