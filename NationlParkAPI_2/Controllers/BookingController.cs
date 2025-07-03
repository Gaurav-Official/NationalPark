using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationlParkAPI_2.Data;
using NationlParkAPI_2.Models;

namespace NationlParkAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookingController(ApplicationDbContext context)
        {
            _context = context;            
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking model)
        {
            if (model.NumberOfPersons > 5)
                return BadRequest("Max 5 persons allowed.");

            var count = _context.Bookings
                .Where(b => b.DateOfBooking.Date == model.DateOfBooking.Date)
                .Count();

            if (count >= 10)
                return BadRequest("Max 10 bookings per day reached.");

            model.Price = model.NumberOfPersons * 100; // ₹100/person
            model.BookingStatus = "Pending";

            _context.Bookings.Add(model);
            await _context.SaveChangesAsync();

            return Ok("Booking successful");
        }

        [HttpGet("future")]
        public IActionResult GetUpcomingBookings()
        {
            var upcoming = _context.Bookings
                .Where(b => b.DateOfBooking > DateTime.Today)
                .ToList();

            return Ok(upcoming);
        }

    }

}
