using HRSystem.Domain.Common;

namespace HRSystem.Domain.Entities;

public class Employee : BaseEntity
{
    public string? Title { get; set; }
}
