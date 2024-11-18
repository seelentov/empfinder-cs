using System;

namespace Empfinder.Factories;

public interface IAbstractFactory<T, U>
{
    public T Get(U type);

}
