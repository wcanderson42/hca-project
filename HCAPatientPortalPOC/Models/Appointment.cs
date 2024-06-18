using System.ComponentModel.DataAnnotations;

namespace HCAPatientPortalPOC.Models;

public class Appointment()
{
    [Key()]
    public int? Id {get; private set; }

    [
        Display(Name = "Patient ID"),
        Required(ErrorMessage = "Patient ID is reuired")
    ]
    public required int PatientId { get; set; }

    [
        Display(Name = "Schedule Slot ID"),
        Required(ErrorMessage = "Schedule Slot ID is reuired")
    ]
    public required int ScheduleSlotId { get; set; }
}