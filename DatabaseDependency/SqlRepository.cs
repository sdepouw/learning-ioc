﻿using System;
using LearningIoC.Core.Interfaces;

namespace LearningIoC.DatabaseDependency
{
    public class SqlRepository<T> : IRepository<T>
        where T : new()
    {
        public T Get()
        {
            Console.WriteLine("Getting object of type '{0}'!", typeof(T).Name);
            return new T();
        }
    }
}