using DemoCQRS.Application.Dtos.Response;
using MediatR;

namespace DemoCQRS.Application.Commands
{
    public class CreatePersonCommand : IRequest<PersonResponseDto>
    {
        public CreatePersonCommand(string name, string email, string telefone)
        {
            Name = name;
            Email = email;
            Telefone = telefone;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
