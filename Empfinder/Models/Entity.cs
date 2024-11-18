using System;

namespace Empfinder.Models.Abstract;

abstract public class Entity : Model
{
    public int Id { get; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
}
