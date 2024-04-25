using chooapi.Models;

namespace chooapi.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAll();
    }
}
