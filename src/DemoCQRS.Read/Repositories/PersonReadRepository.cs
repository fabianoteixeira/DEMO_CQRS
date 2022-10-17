using DemoCQRS.Application.Contracts;
using DemoCQRS.Domain.Entities;
using DemoCQRS.Read.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCQRS.Read.Repositories
{
    public class PersonReadRepository : IPersonReadRepository
    {
        private readonly ReadDbContext readDbContext = null;
        private IMongoCollection<Person> _people { get; }

        public PersonReadRepository()
        {
            readDbContext = new ReadDbContext();
            _people = readDbContext.People;
        }


        public Person Get(Guid key)
        {
            return _people.Find(x => x.Id == key).FirstOrDefault();
        }

        public async Task<Person> GetAsync(Guid key)
        {
            return await _people.Find(x => x.Id == key).FirstOrDefaultAsync();
        }

        public IEnumerable<Person> List()
        {
            return _people.Find(p => true).ToList();
        }

        public IEnumerable<Person> List(int page, int pageSize)
        {
            return _people.Find(p => true).Skip((page - 1) * pageSize).Limit(pageSize).ToList();
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _people.Find(p => true).SortByDescending(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<Person>> ToPagedListAsync(int page, int pageSize)
        {
            return await _people.Find(p => true).ToListAsync();
        }
    }
}
