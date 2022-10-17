using DemoCQRS.Application.Events;
using DemoCQRS.Domain.Entities;
using DemoCQRS.Read.Context;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCQRS.Read.EventHandlers
{
    public class PersonEventHanlder : INotificationHandler<CreatePersonEvent>,
                                        INotificationHandler<UpdatePersonEvent>,
                                        INotificationHandler<DeletePersonEvent>
    {
        private readonly ReadDbContext _readDbContext;
        private IMongoCollection<Person> _people { get; }

        public PersonEventHanlder()
        {
            _readDbContext = new ReadDbContext();
            _people = _readDbContext.People;
        }

        public async Task Handle(CreatePersonEvent notification, CancellationToken cancellationToken)
        {
            await _people.InsertOneAsync(new Person(notification.Id,notification.Name, notification.Email, notification.Telefone));
        }

        public async Task Handle(UpdatePersonEvent notification, CancellationToken cancellationToken)
        {
            await _people.ReplaceOneAsync(x => x.Id == notification.Id, new Person(notification.Id,notification.Name, notification.Email, notification.Telefone));
        }

        public async Task Handle(DeletePersonEvent notification, CancellationToken cancellationToken)
        {
           await _people.DeleteOneAsync(m => m.Id == notification.Id);
        }
    }
}
