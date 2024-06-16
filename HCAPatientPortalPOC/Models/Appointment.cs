namespace HCAPatientPortalPOC.Models;

public class Appointment(int patientId, int scheduleSlotId)
{
    public int? Id {get; private set; }
    public int PatientId { get; set; } = patientId;
    public int ScheduleSlotId { get; set; } = scheduleSlotId;
}