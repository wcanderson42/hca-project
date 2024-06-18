using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HCAPatientPortalPOC.Models;

public class Provider()
{
    [Key()]
    public int? Id { get; set;}

    [
        Display(Name = "First Name"),
        Required(ErrorMessage = "First name is required"),
        StringLength(15, ErrorMessage = "First Name must be less than 15 characters")
    ]
    public required string FirstName { get; set; }

    [
        Display(Name = "Last Name"),
        Required(ErrorMessage = "Last name is required"),
        StringLength(15, ErrorMessage = "Last Name must be less than 15 characters")
    ]
    public required string LastName { get; set; }

    [
        Display(Name = "Title"),
        StringLength(6, ErrorMessage = "Title must be less than 6 characters")
    ]
    public string? Title { get; set; }
}