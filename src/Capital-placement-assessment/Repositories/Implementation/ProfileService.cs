using Capital_placement_assessment.Repositories.Abstraction;
using src.DTOs;
using src.Models;

namespace Capital_placement_assessment.Repositories.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository) =>
            _profileRepository = profileRepository;

        public async Task<bool> CreateProfile(ProfileDTO profileDTO)
        {
            var profile = new Profile(profileDTO);

            await _profileRepository.Create(profile);

            return true;
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            var queryString = "SELECT * FROM c";

            var profiles = await _profileRepository.GetAll(queryString);
            return profiles;
        }

        public async Task<Profile> GetProfileById(string profileId)
        {
            var profile = await _profileRepository.Get(profileId);
            return profile;
        }
        public async Task<bool> UpdateProfile(string profileId, ProfileDTO profileDto)
        {
            var profile = await GetProfileById(profileId);
            if (profile == null)
                return false;

            profile.update(profileDto);

            await _profileRepository.UpdateEntity(profile);

            return true;
        }

        public async Task<bool> DeleteProfile(string profileId)
        {
            var profileToDelete = await GetProfileById(profileId);
            if (profileToDelete == null) return false;

             await _profileRepository.Delete(profileToDelete);
            return true;
        }
    }
}
