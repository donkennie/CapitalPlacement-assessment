using Capital_placement_assessment.Repositories.Abstraction;
using src.DTOs;
using src.Models;

namespace Capital_placement_assessment.Repositories.Implementation
{
    public class ProfileService : IProfileService
    {
        public ProfileService()
        {
            
        }
        public Task<bool> CreateProfile(ProfileDTO profileDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> GetProfileById(string profileId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProfile(string profileId, ProfileDTO profileDto)
        {
            throw new NotImplementedException();
        }
    }
}
