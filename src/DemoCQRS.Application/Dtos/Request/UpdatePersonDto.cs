namespace DemoCQRS.Application.Dtos.Request
{
    public class UpdatePersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
