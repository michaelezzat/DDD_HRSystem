using HRSystem.Domain.Entities;
using MediatR;

namespace HRSystem.Domain.Events;

public class EmmloyeeAddedEvent : INotification
{
    public EmmloyeeAddedEvent(Employee item)
    {
        Item = item;
    }

    public Employee Item { get; }
}
