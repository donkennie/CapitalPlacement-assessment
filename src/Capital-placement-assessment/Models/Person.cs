using System.Reflection;

namespace Capital_placement_assessment.Models
{
    public class Person(string firstName, string lastname, DateTime dateOfBirth, string gender)
    {
        public string FirstName { get; protected set; } = firstName;
        public string LastName { get; protected set; } = lastname;
        public DateTime DateOfBirth { get; protected set; } = dateOfBirth;
        public string Gender { get; protected set;} = gender;

        public static Person CreatePersonFactory(PersonDTO personDTO)
        {
           
            return new Person(personDTO.firstName, personDTO.lastname, 
                              personDTO.dateOfBirth, personDTO.gender);
        }
        
    }


    
    public record PersonDTO(int id, string firstName, string lastname, DateTime dateOfBirth, string gender);

}
