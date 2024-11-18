using System;
using Empfinder.Models;
using Empfinder.Services;

namespace Empfinder.Factories;

public interface IParserFactory : IAbstractFactory<IParser, ParserInstructorType>
{

}

public class ParserFactory : IParserFactory
{
    private readonly IYandexMapsParser _yandex;

    public ParserFactory(IYandexMapsParser yandex)
    {
        _yandex = yandex;
    }
    public IParser Get(ParserInstructorType type)
    {
        switch (type)
        {
            case ParserInstructorType:

            default:
                throw new ArgumentException("type not correct");
        }
    }
}
