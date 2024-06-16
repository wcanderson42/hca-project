namespace HCAPatientPortalPOC.Models;

public class Provider(string firstName, string lastName, string title, int? id = null)
{
    public int? Id { get; private set;} = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Title { get; set; } = title;
}