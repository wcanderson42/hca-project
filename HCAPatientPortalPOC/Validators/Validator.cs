using System.ComponentModel.DataAnnotations;

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

    public static bool DateIsPastPresent( DateOnly date){
        return date <= DateOnly.FromDateTime(DateTime.Now);
    }
}

public class ValidationException : Exception
{
    public ValidationException() : base() { }
    public ValidationException(string message) : base(message) { }
    public ValidationException(string property, string message) : base($"Invalid {property}: {message}") { }
}

public static class AdditionalValidation
{
     public static ValidationResult DateIsPastPresent( DateOnly date)
     {
        if(date <= DateOnly.FromDateTime(DateTime.Now))
        {
            return ValidationResult.Success;
        }
        
        return new ValidationResult("Date is not in the past or present");
    }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
sealed public class DateIsPastPresentAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if(value == null)
        {
            return false;
        }
        
        if((DateOnly) value > DateOnly.FromDateTime(DateTime.Now))
        {
            return false;
        }

        return true;
    }
}