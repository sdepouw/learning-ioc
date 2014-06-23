namespace LearningIoC.Core.Interfaces
{
    public interface IRepository<T>
    {
        T Get();
    }
}