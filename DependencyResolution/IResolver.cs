namespace LearningNinject.DependencyResolution
{
    public interface IResolver
    {
        TAbstractType Get<TAbstractType>();
    }
}