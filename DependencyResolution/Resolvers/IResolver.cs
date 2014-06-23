﻿namespace LearningNinject.DependencyResolution.Resolvers
{
    public interface IResolver
    {
        TAbstractType Get<TAbstractType>();
        void Initialize();
    }
}