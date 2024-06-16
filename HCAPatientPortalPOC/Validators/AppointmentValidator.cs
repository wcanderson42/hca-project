using HCAPatientPortalPOC.Models;

namespace HCAPatientPortalPOC.Validators;

public static partial class Validator
{
    public static Appointment ValidateAppointment(Dictionary<string, string> data)
    {
        // ScheduleSlotId
        int scheduleSlotId;
        if(!data.TryGetValue("ScheduleSlotId", out string slotIdStr))
        {
            throw new ValidationException("ScheduleSlotId", "ScheduleSlotId must be provided");
        } 
        else if (!int.TryParse(slotIdStr, out scheduleSlotId))
        {
            throw new ValidationException("ScheduleSlotId", "ScheduleSlotId must be an int");
        }
        else if (scheduleSlotId < 0)
        {
            throw new ValidationException("ScheduleSlotId", "ScheduleSlotId cannot be negative");
        }

        // PatientId
        int patientId;
        if(!data.TryGetValue("PatientId", out string patientIdStr))
        {
            throw new ValidationException("PatientId", "PatientId must be provided");
        } 
        else if (!int.TryParse(patientIdStr, out patientId))
        {
            throw new ValidationException("PatientId", "PatientId must be an int");
        }
        else if (patientId < 0)
        {
            throw new ValidationException("PatientId", "PatientId cannot be negative");
        }

        // All validation tests passed, return appointment
        return new Appointment(patientId, scheduleSlotId);
    }

}