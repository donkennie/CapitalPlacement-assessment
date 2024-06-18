namespace src.DTOs
{
    public record ProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrectResidence { get; set; }
        public long IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string SelfDescription { get; set; }
        public int YearOfGraduation { get; set; }
        public int Other { get; set; }
        public List<string> MultipleChoice { get; set; }
        public bool IsRejected { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime DateMovedToUK { get; set; }
    }
}