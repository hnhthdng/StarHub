using AutoMapper;
using DataAccess.Repository.IRepository;
using DataObject;
using DataObject.DTO.FormOfWork;
using DataObject.DTO.MainSubject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormOfWorkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FormOfWorkController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var formOfWorks = _unitOfWork.FormOfWork.GetAll();
            return Ok(formOfWorks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var formOfWork = _unitOfWork.FormOfWork.Get(id);
            if (formOfWork == null)
            {
                return NotFound();
            }
            return Ok(formOfWork);
        }

        [HttpGet("GetByFormName")]
        public IActionResult Get(string form)
        {
            form = form.Trim();
            var formOfWork = _unitOfWork.FormOfWork.GetFirstOrDefault(m => m.Form == form);
            if (formOfWork == null)
            {
                return NotFound();
            }
            return Ok(formOfWork);
        }

        [HttpPost("AddFormOfWork")]
        public IActionResult Post([FromBody] FormOfWorkDTO formOfWork)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            FormOfWork formOfWorkObj = _mapper.Map<FormOfWork>(formOfWork);
            _unitOfWork.FormOfWork.Add(formOfWorkObj);
            _unitOfWork.Save();
            return CreatedAtAction("Get", new { id = formOfWorkObj.Id }, formOfWorkObj);
        }

        [HttpPut("UpdateFormOfWork/{id}")]
        public IActionResult Update(int id, [FromBody] FormOfWorkDTO formOfWorkDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var formOfWork = _unitOfWork.FormOfWork.Get(id);
            if (formOfWork == null)
            {
                return NotFound();
            }
            _mapper.Map(formOfWorkDTO, formOfWork);
            _unitOfWork.FormOfWork.Update(formOfWork);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var formOfWork = _unitOfWork.FormOfWork.Get(id);
            if (formOfWork == null)
            {
                return NotFound();
            }
            _unitOfWork.FormOfWork.Remove(formOfWork);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
