using MediatR;

namespace DemoCQRS.Application.Events
{
    public class DeletePersonEvent : INotification
    {
        public DeletePersonEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
