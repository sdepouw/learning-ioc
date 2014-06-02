namespace LearningNinject.DependencyResolution
{
    public interface IResolver
    {
        TAbstractType Resolve<TAbstractType>();
    }
}