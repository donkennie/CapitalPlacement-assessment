using Capital_placement_assessment.Repositories.Abstraction;
using src.Models;

namespace Capital_placement_assessment.Repositories.Implementation
{
    public class ProfileRepository : IProfileRepository
    {
        public ProfileRepository()
        {
            
        }
        public Task Create(Profile entity)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetAll(string queryString)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}