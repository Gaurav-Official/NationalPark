using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp_NP.Models;
using WebApp_NP.Repository.IRepository;

namespace WebApp_NP.Controllers
{
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _nationalparkRepository;
        public NationalParkController(INationalParkRepository nationalParkRepository)
        {
            _nationalparkRepository = nationalParkRepository;            
        }
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        public async Task<IActionResult> GetAll()
        {
            var nationalParkList =await _nationalparkRepository.GetAllAsync
                (SD.NationalParkAPIPath);
            return Json(new {data=nationalParkList});
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status =await _nationalparkRepository.DeleteAsync(SD.NationalParkAPIPath, id);
            if(status) 
                    return Json(new {success=true,message="Data Deleted Successfully !!"});
                    return Json(new {success=false,message="Somthing Went Wrong While Deleting data !!"});
            
        }
        #endregion

        public async Task<ActionResult> Upsert(int? id)
        {
            NationalPark nationalPark = new NationalPark();
            if (id == null) return View(nationalPark);
            nationalPark =await _nationalparkRepository.GetAsync
                (SD.NationalParkAPIPath, id.GetValueOrDefault());
            if (nationalPark == null) return NotFound();
            return View(nationalPark);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(NationalPark nationalPark)
        {
            if (nationalPark == null) return BadRequest();
            if(!ModelState.IsValid) return View(nationalPark);
            //**
            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0)
            {
                byte[] p1 = null;
                using (var fs1 = files[0].OpenReadStream())
                {
                    using(var ms=new MemoryStream())
                    {
                        fs1.CopyTo(ms);
                        p1=ms.ToArray();
                    }
                }
                nationalPark.Picture= p1;
            }
            else
            {
                var nationalParkInDb = await _nationalparkRepository.GetAsync
                    (SD.NationalParkAPIPath, nationalPark.Id);
                nationalPark.Picture=nationalParkInDb.Picture;

            }
            //**//
            if (nationalPark.Id == 0)
              await  _nationalparkRepository.CreateAsync(SD.NationalParkAPIPath, nationalPark);
            else
                await _nationalparkRepository.UpdateAsync(SD.NationalParkAPIPath, nationalPark);
            return RedirectToAction(nameof(Index));


        }
    }
}
