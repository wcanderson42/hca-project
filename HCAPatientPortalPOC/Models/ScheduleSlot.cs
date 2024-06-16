namespace HCAPatientPortalPOC.Models;

public class ScheduleSlot(int providerId, DateTime startTime, int duration, bool available = true, int? id = null)
{
    public int? Id { get; private set;} = id;
    public int ProviderId { get; set; } = providerId;
    public DateTime StartTime { get; set; } = startTime;
    public int Duration { get; set; } = duration;
    public bool Available { get; set; } = available;
}