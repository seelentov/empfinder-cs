using System;
using Empfinder.Models;

namespace Empfinder.Services;

public interface IParser : IService
{
    public List<Employee> GetEmployees(string url);
}
