using AutoMapper;
using DataAccess.Repository.IRepository;
using DataObject;
using DataObject.DTO.TeachingTopic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingTopicController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TeachingTopicController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var teachingTopics = _unitOfWork.TeachingTopic.GetAll();
            return Ok(teachingTopics);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var teachingTopic = _unitOfWork.TeachingTopic.Get(id);
            if (teachingTopic == null)
            {
                return NotFound();
            }
            return Ok(teachingTopic);
        }
        [HttpGet("GetByTopicName")]
        public IActionResult Get(string topic)
        {
            topic = topic.Trim();
            var teachingTopic = _unitOfWork.TeachingTopic.GetFirstOrDefault(m => m.Topic == topic);
            if (teachingTopic == null)
            {
                return NotFound();
            }
            return Ok(teachingTopic);
        }

        [HttpPost("AddTeachingTopic")]
        public IActionResult Post([FromBody] TeachingTopicDTO teachingTopicDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TeachingTopic teachingTopic = _mapper.Map<TeachingTopic>(teachingTopicDTO);
            _unitOfWork.TeachingTopic.Add(teachingTopic);
            _unitOfWork.Save();
            return CreatedAtAction("Get", new { id = teachingTopic.Id }, teachingTopic);
        }

        [HttpPut("UpdateTeachingTopic/{id}")]
        public IActionResult Update(int id, [FromBody] TeachingTopicDTO teachingTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the existing entity
            var existingTeachingTopic = _unitOfWork.TeachingTopic.GetFirstOrDefault(t => t.Id == id);
            if (existingTeachingTopic == null)
            {
                return NotFound($"Teaching Topic with Id {id} not found.");
            }

            _mapper.Map(teachingTopic, existingTeachingTopic);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.TeachingTopic.Get(id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.TeachingTopic.Remove(objFromDb);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
