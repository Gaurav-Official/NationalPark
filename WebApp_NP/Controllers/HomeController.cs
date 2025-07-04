using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApp_NP.Models;
using WebApp_NP.Models.ViewModels;
using WebApp_NP.Repository.IRepository;

namespace WebApp_NP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INationalParkRepository _nationalparkRepository;
        private readonly ITrailRepository _trailRepository;
        

        public HomeController(ILogger<HomeController> logger,INationalParkRepository
            nationalParkRepository,ITrailRepository trailRepository)
        {
            _logger = logger;
            _nationalparkRepository = nationalParkRepository;
            _trailRepository = trailRepository;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                nationalParkList=await _nationalparkRepository.GetAllAsync(SD.NationalParkAPIPath),
                TrailList=await _trailRepository.GetAllAsync(SD.TrailAPIPath),
            };
            return View(indexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
