using System;
using Empfinder.Models.Abstract;

namespace Empfinder.Models;

public class ParserInstructor : Entity
{
    public string Url { get; set; } = string.Empty;
    public DateTime LastParse { get; set; }
    public ParserInstructorType Type { get; set; }
}
