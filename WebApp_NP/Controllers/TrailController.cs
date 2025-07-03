using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using WebApp_NP.Models;
using WebApp_NP.Models.ViewModels;
using WebApp_NP.Repository.IRepository;

namespace WebApp_NP.Controllers
{
    public class TrailController : Controller
    {
        private readonly ITrailRepository _trailRepository;
        private readonly INationalParkRepository _nationalParkRepository;

        public TrailController(ITrailRepository trailRepository, INationalParkRepository nationalParkRepository)
        {
            _trailRepository = trailRepository;
            _nationalParkRepository = nationalParkRepository;
        }

        // ========== INDEX ==========
        public IActionResult Index()
        {
            return View(); // Data will be loaded via AJAX using /Trail/GetAll
        }

        // ========== GET ALL FOR DATATABLE ==========
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trailList = await _trailRepository.GetAllAsync(SD.TrailAPIPath);
            return Json(new { data = trailList });
        }

        // ========== DELETE ==========
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _trailRepository.DeleteAsync(SD.TrailAPIPath, id);

            if (status)
            {
                return Json(new { success = true, message = "Trail deleted successfully!" });
            }

            return Json(new { success = false, message = "Error while deleting trail." });
        }

        // ========== UPSERT (CREATE/EDIT) - GET ==========
        public async Task<IActionResult> Upsert(int? id)
        {
            var nationalParkList = await _nationalParkRepository.GetAllAsync(SD.NationalParkAPIPath);

            TrailVm trailVm = new TrailVm()
            {
                Trail = new Trail(),
                NationalParkList = nationalParkList.Select(np => new SelectListItem
                {
                    Text = np.Name,
                    Value = np.Id.ToString()
                })
            };

            // Create
            if (!id.HasValue)
                return View(trailVm);

            // Edit
            var trail = await _trailRepository.GetAsync(SD.TrailAPIPath, id.Value);
            if (trail == null)
                return NotFound();

            trailVm.Trail = trail;
            return View(trailVm);
        }

        // ========== UPSERT (CREATE/EDIT) - POST ==========
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TrailVm trailVm)
        {
            if (ModelState.IsValid)
            {
                if (trailVm.Trail.Id == 0)
                {
                    // CREATE
                    await _trailRepository.CreateAsync(SD.TrailAPIPath, trailVm.Trail);
                }
                else
                {
                    // UPDATE
                    await _trailRepository.UpdateAsync(SD.TrailAPIPath, trailVm.Trail);
                }

                return RedirectToAction(nameof(Index));
            }

            // Reload dropdown list if model is invalid
            var nationalParkList = await _nationalParkRepository.GetAllAsync(SD.NationalParkAPIPath);
            trailVm.NationalParkList = nationalParkList.Select(np => new SelectListItem
            {
                Text = np.Name,
                Value = np.Id.ToString()
            });

            return View(trailVm);
        }
    }
}
