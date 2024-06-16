namespace HCAPatientPortalPOC.Models;
// TODO: make id nullable
public class Patient(string firstName, string lastName, DateOnly dateOfBirth) // Primary constructor for creating new patients
{    
    public int Id { get; private set;} // Id should not be changed after instantiation. Allow private set for EF database reads
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public DateOnly DateOfBirth { get; private set;} = dateOfBirth;

    public Patient(int id, string firstName, string lastName, DateOnly dateOfBirth) // Secondary constructor for when Id is known Ie database update operation 
        : this(firstName, lastName, dateOfBirth)
    {
        Id = id;
    }
}