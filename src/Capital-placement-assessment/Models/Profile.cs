using src.DTOs;
using Newtonsoft.Json;

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
        public Profile(ProfileDTO profile)
        {
            Id = Guid.NewGuid().ToString();
            PartitionKey = Id;
            FirstName = profile.FirstName;
            LastName = profile.LastName;
            Email = profile.Email;
            Phone = profile.Phone;
            Nationality = profile.Nationality;
            CurrectResidence = profile.CurrectResidence;
            IDNumber = profile.IDNumber;
            DateOfBirth = profile.DateOfBirth;
            Gender = profile.Gender;
            SelfDescription = profile.SelfDescription;
            YearOfGraduation = profile.YearOfGraduation;
            Other = profile.Other;
            MultipleChoice = profile.MultipleChoice;
            IsRejected = profile.IsRejected;
            YearsOfExperience = profile.YearsOfExperience;
            DateMovedToUK = profile.DateMovedToUK;
            CreatedAt = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;

        }

        public void update(ProfileDTO profile)
        {
            FirstName = profile.FirstName;
            LastName = profile.LastName;
            Email = profile.Email;
            Phone = profile.Phone;
            Nationality = profile.Nationality;
            CurrectResidence = profile.CurrectResidence;
            IDNumber = profile.IDNumber;
            DateOfBirth = profile.DateOfBirth;
            Gender = profile.Gender;
            SelfDescription = profile.SelfDescription;
            YearOfGraduation = profile.YearOfGraduation;
            Other = profile.Other;
            MultipleChoice = profile.MultipleChoice;
            IsRejected = profile.IsRejected;
            YearsOfExperience = profile.YearsOfExperience;
            DateMovedToUK = profile.DateMovedToUK;
            LastModified = DateTime.UtcNow;
        }
    }
}