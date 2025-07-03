using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NationlParkAPI_2.Models;
using NationlParkAPI_2.Models.DTOs;
using NationlParkAPI_2.Repository;
using NationlParkAPI_2.Repository.IRepository;

namespace NationlParkAPI_2.Controllers
{
    [Route("api/trail")]
    [ApiController]
    //[Authorize]
    public class TrailController : Controller
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _mapper;
        public TrailController(ITrailRepository trailRepository,IMapper mapper)
        {
            _trailRepository = trailRepository;
            _mapper = mapper;            
        }
        [HttpGet]
        public ActionResult GetTrails()
        {
            var trailsdto = _trailRepository.GetTrails().
                Select(_mapper.Map<Trail, TrailDto>);
            return Ok(trailsdto);

        }
        [HttpGet("{trailId:int}",Name = "GetTrail")]
        public ActionResult GetTrail(int trailId)
        {
            var trails = _trailRepository.GetTrail(trailId);
            if(trails == null) return NotFound();
            var trailsDto = _mapper.Map<TrailDto>(trails);
            return Ok(trailsDto);

        }
        [HttpPost]
        public ActionResult CreateTrail([FromBody]TrailDto trailDto)
        {
            if (trailDto == null) return BadRequest();
            if (_trailRepository.TrailExist(trailDto.Name))
            {
                ModelState.AddModelError("", "Trail in Db !!!!!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(!ModelState.IsValid) return BadRequest();
            var trails = _mapper.Map<TrailDto,Trail>(trailDto);
            if (!_trailRepository.CreateTrail(trails))
            {
                ModelState.AddModelError("", $"Something went wrong while creating Trail: {trails.Name} ");
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            return CreatedAtRoute("GetTrail", new { trailId = trails.Id }, trails);


        }
        [HttpPut]
        public ActionResult UpdateTrail([FromBody] TrailDto trailDto)
        {
            if(trailDto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var trails = _mapper.Map <TrailDto,Trail>(trailDto);
            if (!_trailRepository.UpdateTrail(trails))
            {
                ModelState.AddModelError("", $"Something went wrong while update Trail:  {trails.Name} ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();//204
        }
        [HttpDelete("{trailId:int}")]
        public ActionResult DeleteTrail(int trailId)
        {
            if(!_trailRepository.TrailExist(trailId)) return BadRequest();
            var trails = _trailRepository.GetTrail(trailId);
            if(trails == null) return NotFound();
            if (!_trailRepository.DeleteTrail(trails))
            {
                ModelState.AddModelError("", $"Something went wrong while Delete Trail:  {trails.Name} ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
