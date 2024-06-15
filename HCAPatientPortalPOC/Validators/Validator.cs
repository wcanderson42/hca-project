namespace HCAPatientPortalPOC.Validators;


/*  Validator will accept incoming form data
    verify that the data meets requirements to create data model instance
    then return the data model instance
*/
public static partial class Validator
{
    /*
    functions that would work across models would go here
    model-specific functions will be split into separate files for readability/extendability
    */
}

public class ValidationException : Exception
{
    public ValidationException() : base() { }
    public ValidationException(string message) : base(message) { }
    public ValidationException(string property, string message) : base($"Invalid {property}: {message}") { }
}
