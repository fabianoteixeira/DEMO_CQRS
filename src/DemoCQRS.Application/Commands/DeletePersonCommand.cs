using MediatR;

namespace DemoCQRS.Application.Commands
{

    public class DeletePersonCommand : IRequest<bool>
    {
        public DeletePersonCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

}
