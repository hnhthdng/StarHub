using AutoMapper;
using DataAccess.Repository.IRepository;
using DataObject;
using DataObject.DTO.MainSubject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainSubjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MainSubjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var mainSubjects = _unitOfWork.MainSubject.GetAll();
            return Ok(mainSubjects);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var mainSubject = _unitOfWork.MainSubject.Get(id);
            if (mainSubject == null)
            {
                return NotFound();
            }
            return Ok(mainSubject);
        }
        [HttpGet("GetByName")]
        public IActionResult Get(string name)
        {
            name = name.Trim();
            var mainSubject = _unitOfWork.MainSubject.GetFirstOrDefault(m => m.Name == name);
            if (mainSubject == null)
            {
                return NotFound();
            }
            return Ok(mainSubject);
        }

        [HttpPost("AddMainSubject")]
        public IActionResult Post([FromBody] MainSubjectDTO mainSubjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MainSubject mainSubject = _mapper.Map<MainSubject>(mainSubjectDTO);
            _unitOfWork.MainSubject.Add(mainSubject);
            _unitOfWork.Save();
            return CreatedAtAction("Get", new { id = mainSubject.Id }, mainSubject);
        }


        [HttpPut("UpdateMainSubject/{id}")]
        public IActionResult Update(int id, [FromBody] MainSubjectDTO mainSubjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mainSubject = _unitOfWork.MainSubject.Get(id);
            if (mainSubject == null)
            {
                return NotFound();
            }
            _mapper.Map(mainSubjectDTO, mainSubject);
            _unitOfWork.MainSubject.Update(mainSubject);
            _unitOfWork.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mainSubject = _unitOfWork.MainSubject.Get(id);
            if (mainSubject == null)
            {
                return NotFound();
            }
            _unitOfWork.MainSubject.Remove(mainSubject);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
