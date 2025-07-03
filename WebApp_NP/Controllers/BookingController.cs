using Microsoft.AspNetCore.Mvc;
using WebApp_NP.Models.ViewModels;

namespace WebApp_NP.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Create(int parkId, string parkName)
        {
            var model = new BookingVM
            {
                ParkId = parkId,
                ParkName = parkName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Price = model.NumberOfPersons * 100;
            model.BookingStatus = "Pending";

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7041/api/Booking\r\n", model);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Success");

            ViewBag.Error = "Booking failed. Try again.";
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var client = _httpClientFactory.CreateClient();

            var bookings = await client.GetFromJsonAsync<List<BookingVM>>("https://localhost:7041/api/Booking/future");
            var parks = await client.GetFromJsonAsync<List<NationalParkVM>>("https://localhost:7041/api/NationalPark");

            foreach (var booking in bookings)
            {
                var park = parks.FirstOrDefault(p => p.Id == booking.ParkId);
                booking.ParkName = park?.Name ?? "Unknown";
            }

            return View(bookings);
        }



        public IActionResult Success()
        {
            return View();
        }
    }

}
