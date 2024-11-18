using System;

namespace Empfinder.Factories;

public interface IFactory<T>
{
    public T Get();
}