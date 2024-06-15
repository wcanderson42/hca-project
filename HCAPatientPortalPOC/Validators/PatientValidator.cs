using HCAPatientPortalPOC.Models;
using Microsoft.Extensions.Primitives;

namespace HCAPatientPortalPOC.Validators;

public static partial class Validator
{
    public static Patient ValidatePatient(Dictionary<string, StringValues> data)
    {
        // FirstName
        StringValues rawFirst;
        if(!data.TryGetValue("FirstName", out rawFirst))
        {
            throw new ValidationException("FirstName", "FirstName must be provided");
        }

        string first = rawFirst.ToString();
        if(first.Length == 0)
        {
            throw new ValidationException("FirstName", "FirstName must be provided");
        }
        else if (first.Length > 30) // TODO: arbitrary value, should be moved to  aconfiguration file
        {
            throw new ValidationException("FirstName", "FirstName must be less than 30 characters long");
        }

        // LastName
        StringValues rawLast;
        if(!data.TryGetValue("LastName", out rawLast))
        {
            throw new ValidationException("LastName", "LastName must be provided");
        }

        string last = rawLast.ToString();
        if(last.Length == 0)
        {
            throw new ValidationException("LastName", "LastName must be provided");
        }
        else if (last.Length > 30) // TODO: arbitrary value, should be moved to  aconfiguration file
        {
            throw new ValidationException("LastName", "LastName must be less than 30 characters long");
        }

        // DateOfBirth
        StringValues rawDOB;
        DateOnly dateOfBirth;
        if(!data.TryGetValue("DateOfBirth", out rawDOB) || rawDOB.ToString().Length == 0)
        {
            throw new ValidationException("DateOfBirth", "DateOfBirth must be provided");
        }

        try
        {
            dateOfBirth = DateOnly.Parse(rawDOB.ToString());
        }
        catch (Exception e)
        {
            throw new ValidationException("DateOfBirth", $"DateOfBirth not parsable \"{e.Message}\"");
        }

        // All validation tests passed, return patient
        return new Patient(first, last, dateOfBirth);
        
    }
}