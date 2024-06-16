namespace HCAPatientPortalPOC.Models;

public class ScheduleSlot(int providerId, DateTime startTime, int duration,  int? id = null, int? appointmentId = null)
{
    public int? Id { get; private set;} = id;
    public int ProviderId { get; set; } = providerId;
    public DateTime StartTime { get; set; } = startTime;
    public int Duration { get; set; } = duration;
    public int? AppointmentId { get; set; } = appointmentId;
}