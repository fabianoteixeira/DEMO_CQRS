using MediatR;

namespace DemoCQRS.Application.Events
{
    public class UpdatePersonEvent : INotification
    {
        public UpdatePersonEvent(Guid id, string name, string email, string telefone)
        {
            Id = id;
            Name = name;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
