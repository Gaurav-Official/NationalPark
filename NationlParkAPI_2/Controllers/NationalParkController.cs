using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NationlParkAPI_2.Models;
using NationlParkAPI_2.Models.DTOs;
using NationlParkAPI_2.Repository.IRepository;

namespace NationlParkAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;
        public NationalParkController(INationalParkRepository nationalParkRepository
            , IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetNationalPark()
        {
            var nationlParkDto = _nationalParkRepository.
                GetNationalParks().Select(_mapper.Map<NationalPark, NationalParkDto>);
            return Ok(nationlParkDto);//200
        }


        [HttpGet("{nationalParkId:int}",Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var nationalPark = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (nationalPark == null) return NotFound();
            var nationalParkDto = _mapper.Map<NationalParkDto>(nationalPark);
            return Ok(nationalParkDto);//200
        }
        [HttpPost]
        public IActionResult CreateNationalPark([FromBody]NationalParkDto nationalParkDto)
        {
            if(nationalParkDto == null) return BadRequest();//400
            if (_nationalParkRepository.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park in Db !!!!!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(!ModelState.IsValid) return BadRequest();//400
            var nationalPark=_mapper.Map<NationalPark>(nationalParkDto);
            if (!_nationalParkRepository.CreateNationalPark(nationalPark))
            {
                ModelState.AddModelError("",$"Something went wrong while creating National Park: {nationalPark.Name} ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //return Ok();//200
            return CreatedAtRoute("GetNationalPark", new 
            { nationalParkId = nationalPark.Id }, nationalPark);//201

        }
        [HttpPut]
        public IActionResult UpdateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var nationalPark = _mapper.Map<NationalParkDto, NationalPark>(nationalParkDto);
            if (!_nationalParkRepository.UpdateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong while Update National Park: {nationalPark.Name} ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();//204
        }
        [HttpDelete("{nationalParkId:int}")]
        public IActionResult DeleteNationalPark(int nationalParkId)
        {
            if(!_nationalParkRepository.NationalParkExists(nationalParkId)) 
                return NotFound();
            var nationalPark = _nationalParkRepository.GetNationalPark(nationalParkId);
            if(nationalPark == null) return NotFound();
            if (!_nationalParkRepository.DeleteNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong while Delete National Park: {nationalPark.Name} ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();//200
        }

    }
}
