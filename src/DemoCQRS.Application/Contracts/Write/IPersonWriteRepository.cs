using DemoCQRS.Domain.Entities;

namespace DemoCQRS.Application.Contracts.Write
{
    public interface IPersonWriteRepository
    {
        Task<Person> AddAsync(Person entity);
        Task AddRangeAsync(List<Person> entity);
        Task UpdateAsync(Person entity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<Person>> ListAsync();
    }
}
