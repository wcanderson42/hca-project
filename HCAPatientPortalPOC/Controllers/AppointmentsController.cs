using HCAPatientPortalPOC.Models;
using HCAPatientPortalPOC.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HCAPatientPortalPOC.Controllers;

public class AppointmentsController : Controller
{
    private readonly PortalDbContext _context;

    public AppointmentsController(PortalDbContext context)
    {
        _context = context;
    }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            // TODO: order by provider, startTime
            return View(await _context.Appointments
                .OrderBy(x => x.PatientId)
                .ToListAsync());
        }

        // GET: ScheduleSlots/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            var slot = await _context.ScheduleSlots.FindAsync(appointment.ScheduleSlotId);
            ViewData["Provider"] = await _context.Providers.FindAsync(slot.ProviderId);
            ViewData["Patient"] = await _context.Patients.FindAsync(appointment.PatientId);
            ViewData["Slot"] = slot;
            return View(appointment);
        }

        // GET ScheduleSlots/Create
        public async Task<IActionResult> Create()
        {
            List<Provider> providers = await _context.Providers.ToListAsync();
            ViewData["Providers"] = providers.ToDictionary(p => p.Id, p => $"{p.FirstName} {p.LastName} {p.Title}");
            ViewData["Patients"] = await _context.Patients.ToListAsync();
            ViewData["Slots"] = await _context.ScheduleSlots
                .Where(s => s.Available == true)
                .OrderBy(x => x.ProviderId)
                .ThenBy(x => x.StartTime)
                .ThenBy(x => x.Duration)
                .ToListAsync();


            return View();
        }

        // POST: ScheduleSlots/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dictionary<string, string> dict)
        {
            try
            {
                Appointment appointment = Validator.ValidateAppointment(dict);
                if (ModelState.IsValid)
                {
                    ScheduleSlot slot = await _context.ScheduleSlots.FindAsync(appointment.ScheduleSlotId);
                    if(slot == null)
                    {
                        return NotFound();
                    }

                    _context.Add(appointment);
                    slot.Available = false;
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception e)
            {
                //TODO: route to error page
                Console.WriteLine(e.Message);
                
            }  
            return View();
        }

       
}
