using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DemoCQRS.Domain.Entities
{
    public class Person
    {
        public Person(string name, string email, string telefone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Telefone = telefone;
        }

        public Person(Guid id, string name, string email, string telefone)
        {
            Id = id;
            Name = name;
            Email = email;
            Telefone = telefone;
        }

        [Key]
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
