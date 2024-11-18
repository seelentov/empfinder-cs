using System;
using Empfinder.Factories;
using Empfinder.Models;
using OpenQA.Selenium.Chrome;

namespace Empfinder.Services;

public interface IYandexMapsParser : IParser
{

}
public class YandexMapsParser : IYandexMapsParser
{
    private readonly ChromeDriver _driver;

    public YandexMapsParser(ISeleniumFactory seleniumFactory)
    {
        _driver = seleniumFactory.Get();
    }
    public List<Employee> GetEmployees(string url)
    {
        List<Employee> employees = [];

        _driver.Navigate().GoToUrl(url);



        return employees;
    }

}
