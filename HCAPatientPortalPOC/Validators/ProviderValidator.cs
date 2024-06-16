using HCAPatientPortalPOC.Models;

namespace HCAPatientPortalPOC.Validators;

public static partial class Validator
{
    public static Provider ValidateProvider(Dictionary<string, string> data)
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

        // Title - OPTIONAL
        string? title = null;
        if(data.TryGetValue("Title", out title) && title.Length > 10) // TODO: arbitrary value, should be moved to  aconfiguration file
        {
            throw new ValidationException("Title", "Title must be less than 10 characters long");
        }

        // Id - OPTIONAL
        string? rawId = null;
        int? id = null;

        if(data.TryGetValue("Id", out rawId))
        {
            // rawId = "1" or "a" or ""
            int foundId;
            bool found = int.TryParse(rawId, out foundId);
            if(found && foundId < 0)
            {
               throw new ValidationException("Id", "Id cannot be negative"); 
            }

            id = foundId;
        }

        // All validation tests passed, return patient
        return new Provider(first, last, title, id);
    }
}