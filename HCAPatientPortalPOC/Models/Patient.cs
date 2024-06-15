namespace HCAPatientPortalPOC.Models;

public class Patient(string firstName, string lastName, DateOnly dateOfBirth)
{    
    public int Id { get; private set;}
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public DateOnly DateOfBirth { get; private set;} = dateOfBirth;

    public Patient(string firstName, string lastName, string dateOfBirth)
        : this(firstName, lastName, DateOnly.Parse(dateOfBirth))  {}
}