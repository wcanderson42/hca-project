namespace HCAPatientPortalPOC.Models;

public class Appointment()
{
    public int? Id {get; private set; }
    public int PatientId { get; set; }
    public int ScheduleSlotId { get; set; }
}