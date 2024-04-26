using Lawyeed.API.Lawyeed.Domain.Models;

namespace Lawyeed.API.Lawyeed.Domain.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> ListAsync();
    Task AddAsync(Person person);
    Task<Person> FindByIdAsync(int id);
    void Update(Person person);
    void Remove(Person person);
}