using HCAPatientPortalPOC.Models;

namespace HCAPatientPortalPOC.Validators;

public static partial class Validator
{
    public static ScheduleSlot ValidateScheduleSlot(Dictionary<string, string> data)
    {
        // ProviderId
        int providerId;
        if(!data.TryGetValue("ProviderId", out string providerIdStr))
        {
            throw new ValidationException("ProviderId", "ProviderId must be provided");
        } 
        else if (!int.TryParse(providerIdStr, out providerId))
        {
            throw new ValidationException("ProviderId", "ProviderId must be an int");
        }
        else if (providerId < 0)
        {
            throw new ValidationException("ProviderId", "ProviderId cannot be negative");
        }

        // StartTime
        DateTime startTime;
        if (!data.TryGetValue("StartTime", out string startTimeStr))
        {
            throw new ValidationException("StartTime", "StartTime must be provided");
        }
        else if (!DateTime.TryParse(startTimeStr, out startTime))
        {
            throw new ValidationException("StartTime", $"StartTime could not be parsed from \"{startTimeStr}\"");
        }
        else if (startTime < DateTime.Now)
        {
            throw new ValidationException("StartTime", "StartTime must be in the future");
        }

        // Duration
        int duration;
        if(!data.TryGetValue("Duration", out string durationStr))
        {
            throw new ValidationException("Duration", "Duration must be provided");
        } 
        else if (!int.TryParse(durationStr, out duration))
        {
            throw new ValidationException("Duration", "Duration must be an int");
        }
        else if (duration < 0 || duration > 60)
        {
            throw new ValidationException("Duration", "Duration must be between 1 and 60");
        }

        // AppointmentId - OPTIONAL
        int? appointmentId = null;
        if(data.TryGetValue("AppointmentId", out string apptIdStr))
        {
            if (!int.TryParse(apptIdStr, out int foundApptId))
            {
                throw new ValidationException("AppointmentId", "AppointmentId must be an int");
            }
            else if (foundApptId < 0)
            {
                throw new ValidationException("AppointmentId", "AppointmentId cannot be negative");
            }
            appointmentId = foundApptId;
        } 

        // Id - OPTIONAL
        int? id = null;
        if(data.TryGetValue("Id", out string idStr))
        {
            if (!int.TryParse(idStr, out int foundId))
            {
                throw new ValidationException("Id", "Id must be an int");
            }
            else if (foundId < 0)
            {
                throw new ValidationException("Id", "Id cannot be negative");
            }
            id = foundId;
        } 

        // All validation tests passed, return patient
        return new ScheduleSlot(providerId, startTime, duration, id, appointmentId);
    }
}