using DemoCQRS.Application.Contracts.Write;
using DemoCQRS.Domain.Entities;
using DemoCQRS.Write.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCQRS.Write.Repositories
{
   
    public class PersonWriteRepository : IPersonWriteRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public PersonWriteRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext ?? throw new ArgumentNullException(nameof(writeDbContext));
        }

        public async Task<Person> AddAsync(Person entity)
        {
            await _writeDbContext.People.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<Person> entity)
        {
            await _writeDbContext.Set<Person>().AddRangeAsync(entity);
            _writeDbContext.SaveChanges();

        }

        public async Task UpdateAsync(Person entity)
        {
            _writeDbContext.Update<Person>(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = _writeDbContext.People.SingleOrDefault(p => p.Id == id);
            _writeDbContext.Set<Person>().Remove(entity);
            return await _writeDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _writeDbContext.People.OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}
