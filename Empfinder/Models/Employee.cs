using System;
using Empfinder.Models.Abstract;

namespace Empfinder.Models;

public class Employee : Entity
{
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Socials { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
    public string Site { get; set; } = string.Empty;
    public EmployeeSiteType SiteType { get; set; }

}
