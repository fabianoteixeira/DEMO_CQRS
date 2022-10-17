using DemoCQRS.Domain.Entities;

namespace DemoCQRS.Application.Contracts
{
    public interface IPersonReadRepository
    {
        Person Get(Guid key);
        Task<Person> GetAsync(Guid key);
        IEnumerable<Person> List();
        Task<IEnumerable<Person>> ListAsync();
        Task<IEnumerable<Person>> ToPagedListAsync(int page, int pageSize);
    }
}
