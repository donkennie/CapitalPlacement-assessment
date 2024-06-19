using src.DTOs;
using Newtonsoft.Json;
using Capital_placement_assessment.Extensions;

namespace src.Models
{
    public class Profile
    {
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("partitionKey")]
        public string PartitionKey { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public string Nationality { get; protected set; }
        public string CurrectResidence { get; protected set; }
        public long IDNumber { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public string Gender { get; protected set; }
        public string SelfDescription { get; protected set; }
        public int YearOfGraduation { get; protected set; }
        public int Other { get; protected set; }
        public List<string> MultipleChoice { get; protected set; }
        public bool IsRejected { get; protected set; } = false;
        public int YearsOfExperience { get; protected set; }
        public DateTime DateMovedToUK { get; protected set; }
        public DateTime? CreatedAt { get; protected set; }
        public DateTime? LastModified { get; protected set; }

        public Profile()
        {
        }
        public Profile(ProfileDTO profileDto)
        {
            Validator.CannotBeNullOrEmpty(profileDto.FirstName, profileDto.LastName, profileDto.Email, profileDto.Phone,
                                profileDto.SelfDescription, profileDto.MultipleChoice, profileDto.YearsOfExperience);

            Id = Guid.NewGuid().ToString();
            PartitionKey = Id;
            FirstName = profileDto.FirstName;
            LastName = profileDto.LastName;
            Email = profileDto.Email;
            Phone = profileDto.Phone;
            Nationality = profileDto.Nationality;
            CurrectResidence = profileDto.CurrectResidence;
            IDNumber = profileDto.IDNumber;
            DateOfBirth = profileDto.DateOfBirth;
            Gender = profileDto.Gender;
            SelfDescription = profileDto.SelfDescription;
            YearOfGraduation = profileDto.YearOfGraduation;
            Other = profileDto.Other;
            MultipleChoice = profileDto.MultipleChoice;
            IsRejected = profileDto.IsRejected;
            YearsOfExperience = profileDto.YearsOfExperience;
            DateMovedToUK = profileDto.DateMovedToUK;
            CreatedAt = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;

        }

        public void Update(ProfileDTO profileDto)
        {
            FirstName = profileDto.FirstName;
            LastName = profileDto.LastName;
            Email = profileDto.Email;
            Phone = profileDto.Phone;
            Nationality = profileDto.Nationality;
            CurrectResidence = profileDto.CurrectResidence;
            IDNumber = profileDto.IDNumber;
            DateOfBirth = profileDto.DateOfBirth;
            Gender = profileDto.Gender;
            SelfDescription = profileDto.SelfDescription;
            YearOfGraduation = profileDto.YearOfGraduation;
            Other = profileDto.Other;
            MultipleChoice = profileDto.MultipleChoice;
            IsRejected = profileDto.IsRejected;
            YearsOfExperience = profileDto.YearsOfExperience;
            DateMovedToUK = profileDto.DateMovedToUK;
            LastModified = DateTime.UtcNow;
        }

    }
}