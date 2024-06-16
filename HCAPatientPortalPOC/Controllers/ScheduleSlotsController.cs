using HCAPatientPortalPOC.Models;
using HCAPatientPortalPOC.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HCAPatientPortalPOC.Controllers;

public class ScheduleSlotsController : Controller
{
    private readonly PortalDbContext _context;

    public ScheduleSlotsController(PortalDbContext context)
    {
        _context = context;
    }

        // GET: ScheduleSlots
        public async Task<IActionResult> Index()
        {
            // TODO: order by provider, startTime
            return View(await _context.ScheduleSlots
                .OrderBy(x => x.ProviderId)
                .ThenBy(x => x.StartTime)
                .ToListAsync());
        }

        // GET: ScheduleSlots/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.ScheduleSlots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }
}
