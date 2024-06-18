using src.DTOs;
using src.Models;

namespace Capital_placement_assessment.Repositories.Abstraction
{
    public interface IProfileService
    {
        Task<bool> CreateProfile(ProfileDTO profileDTO);
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfileById(string profileId);
        Task<bool> UpdateProfile(string profileId, ProfileDTO profileDto);
    }
}
