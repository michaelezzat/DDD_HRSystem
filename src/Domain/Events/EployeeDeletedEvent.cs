using HRSystem.Domain.Entities;
using MediatR;

namespace HRSystem.Domain.Events;

public class EployeeDeletedEvent : INotification
{
    public EployeeDeletedEvent(Employee item)
    {
        Item = item;
    }

    public Employee Item { get; }
}
