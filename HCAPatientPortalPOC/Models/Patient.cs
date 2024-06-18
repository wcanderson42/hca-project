using System.ComponentModel.DataAnnotations;
using HCAPatientPortalPOC.Validators;

namespace HCAPatientPortalPOC.Models;

public class Patient()
{    

    // Id - primary identifier for Patients, should only be set by EF when it returns database entries
    [Key()]
    public int? Id { get; init;} 
    
    [
        Display(Name = "First Name"),
        Required(ErrorMessage = "First name is required"),
        StringLength(15, ErrorMessage = "First Name must be less than 15 characters")
    ]
    public string FirstName { get; set; }

    [
        Display(Name = "Last Name"),
        Required(ErrorMessage = "Last name is required"),
        StringLength(15, ErrorMessage = "Last Name must be less than 15 characters")
    ]
    public string LastName { get; set; }

    [
        Display(Name = "Date of Birth"),
        Required(ErrorMessage = "Date of Birth is required"),
        DateIsPastPresent(ErrorMessage = "Date of Birth must be today or in the past"),
    ]
    public required DateOnly DateOfBirth { get; set;}
}