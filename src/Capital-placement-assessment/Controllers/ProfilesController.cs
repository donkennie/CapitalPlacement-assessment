using Capital_placement_assessment.Repositories.Abstraction;
using Microsoft.AspNetCore.Mvc;
using src.DTOs;

namespace Capital_placement_assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfilesController(IProfileService profileService) =>
            _profileService = profileService;


        [HttpPost, Route("/create-profile")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateProfile(ProfileDTO profileDTO)
        {
            var result = await _profileService.CreateProfile(profileDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut, Route("/update-profile")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateProfile(string profileId, ProfileDTO profileDTO)
        {
            var result = await _profileService.UpdateProfile(profileId, profileDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet, Route("/get-profiles")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetProfiles()
        {
            var result = await _profileService.GetProfiles();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet, Route("/get-profile-by-id")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetProfileById(string profileId)
        {
            var result = await _profileService.GetProfileById(profileId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete, Route("/delete-profile")]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteProfile(string profileId)
        {
            var result = await _profileService.DeleteProfile(profileId);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }


    }
}