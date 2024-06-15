using HCAPatientPortalPOC.Models;

namespace HCAPatientPortalPOC.Validators;

public static partial class Validator
{
    public static Patient ValidatePatient(Dictionary<string, string> data)
    {
        // FirstName
        string first;
        if(!data.TryGetValue("FirstName", out first) || first.Length == 0)
        {
            throw new ValidationException("FirstName", "FirstName must be provided");
        }
        else if (first.Length > 30) // TODO: arbitrary value, should be moved to  aconfiguration file
        {
            throw new ValidationException("FirstName", "FirstName must be less than 30 characters long");
        }

        // LastName
        string last;
        if(!data.TryGetValue("LastName", out last) || last.Length == 0)
        {
            throw new ValidationException("LastName", "LastName must be provided");
        }
        else if (last.Length > 30) // TODO: arbitrary value, should be moved to  aconfiguration file
        {
            throw new ValidationException("LastName", "LastName must be less than 30 characters long");
        }

        // DateOfBirth
        string dobString;
        DateOnly dateOfBirth;
        if(!data.TryGetValue("DateOfBirth", out dobString) || dobString.Length == 0)
        {
            throw new ValidationException("DateOfBirth", "DateOfBirth must be provided");
        }

        try
        {
            dateOfBirth = DateOnly.Parse(dobString);
        }
        catch (Exception e)
        {
            throw new ValidationException("DateOfBirth", $"DateOfBirth not parsable \"{e.Message}\"");
        }



        // Id - OPTIONAL
        string rawId;
        int id = 0;
        bool useId = false;

        if(data.TryGetValue("Id", out rawId))
        {
            useId = int.TryParse(rawId, out id);
            if(useId && id < 0)
            {
               throw new ValidationException("Id", "Id cannot be negative"); 
            }
        }

        // All validation tests passed, return patient
        if(useId)
        {
            return new Patient(id, first, last, dateOfBirth);
        }
        return new Patient(first, last, dateOfBirth);
    }
}