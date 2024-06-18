using System.ComponentModel.DataAnnotations;
using HCAPatientPortalPOC.Validators;

namespace HCAPatientPortalPOC.Models;

public class ScheduleSlot()
{
    [Key()]
    public int? Id { get; set;}

    [
        Display(Name = "Provider ID"),
        Required(ErrorMessage = "Provider ID is required")
        // TODO: is this foreign key defined?
    ]
    public required int ProviderId { get; set; }

    [
        Display(Name = "Start Time"),
        Required(ErrorMessage = "Start time is required"),
        DateIsFuture(ErrorMessage = "Start time must be in the future")
    ]
    public required DateTime StartTime { get; set; }

    [
        Display(Name = "Duration (Minutes)"),
        Required(ErrorMessage = "Duration is required"),
        Range(1,60, ErrorMessage = "Duration must be between 1 and 60")
    ]
    public required int Duration { get; set; }

    [
        Display(Name = "Slot is Available"),
    ]
    public bool Available { get; set; } = true;
}