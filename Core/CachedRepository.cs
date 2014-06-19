using System;
using LearningNinject.Core.Interfaces;

namespace LearningNinject.Core
{
    public class CachedRepository<T> : IRepository<T>
        where T : class
    {
        private readonly IRepository<T> repository;

        public CachedRepository(IRepository<T> repository)
        {
            this.repository = repository;
        }

        private T cachedObject;
        public T Get()
        {
            if (cachedObject == null)
            {
                cachedObject = repository.Get();
            }
            else
            {
                Console.WriteLine("Using cached repository to fetch '{0}'!", typeof(T).Name);
            }
            return cachedObject;
        }
    }
}