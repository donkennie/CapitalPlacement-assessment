using src.Models;

namespace Capital_placement_assessment.Repositories.Abstraction
{
    public interface IProfileRepository
    {
        Task Create(Profile entity);
        Task UpdateEntity(Profile entity);
        Task<Profile> Get(string id);
        Task<IEnumerable<Profile>> GetAll(string queryString);
    }
}