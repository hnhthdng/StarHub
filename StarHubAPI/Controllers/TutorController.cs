using AutoMapper;
using DataAccess.Repository.IRepository;
using DataObject;
using DataObject.DTO.Tutor;
using DataObject.DTO.TutorMainSubject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TutorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tutors = _unitOfWork.Tutor.GetAll(includeProperty:"MainSubjects,FormOfWorks");
            return Ok(tutors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == id, includeProperties: "MainSubjects,FormOfWorks");
            if (tutor == null)
            {
                return NotFound();
            }
            return Ok(tutor);
        }

        [HttpPost("AddBasicInfo")]
        public IActionResult Post([FromBody] TutorBasicInfoDTO tutorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Tutor tutor = _mapper.Map<Tutor>(tutorDTO);
            _unitOfWork.Tutor.Add(tutor);
            _unitOfWork.Save();
            return CreatedAtAction("Get", new { id = tutor.Id }, tutor);
        }


        [HttpPut("UpdateBasicInfo/{id}")]
        public IActionResult Update(int id, [FromBody] TutorBasicInfoDTO tutorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the existing entity
            var existingTutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == id);
            if (existingTutor == null)
            {
                return NotFound($"Tutor with Id {id} not found.");
            }

            // Map updated values from DTO to the existing entity
            _mapper.Map(tutorDTO, existingTutor);

            // Update the entity in the repository
            _unitOfWork.Tutor.Update(existingTutor);
            _unitOfWork.Save();

            return CreatedAtAction("Get", new { id = id }, existingTutor);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tutor = _unitOfWork.Tutor.Get(id);
            if (tutor == null)
            {
                return NotFound();
            }
            _unitOfWork.Tutor.Remove(tutor);
            _unitOfWork.Save();
            return NoContent();
        }


        [HttpPut("AddOrUpdateMainSubjectsForTutor")]
        public IActionResult AddAndUpdateMainSubjectsForTutor(int tutorId, [FromBody] List<int> ListofMainSubjectId)
        {
            // Validate input
            if (tutorId <= 0 || ListofMainSubjectId == null)
            {
                return BadRequest("Invalid Tutor ID or Main Subject ID.");
            }

            // Retrieve the Tutor entity from the database
            var tutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == tutorId, includeProperties: "MainSubjects,FormOfWorks");
            if (tutor == null)
            {
                return NotFound($"Tutor with ID {tutorId} not found.");
            }

            // Retrieve the MainSubject entity from the database
            var mainSubject = new List<MainSubject>();
            foreach (var mainSubjectId in ListofMainSubjectId)
            {
                mainSubject.Add(_unitOfWork.MainSubject.GetFirstOrDefault(ms => ms.Id == mainSubjectId));
            }

            if (mainSubject == null)
            {
                return NotFound($"Main Subject not found.");
            }

            // Clear the existing MainSubjects list
            tutor.MainSubjects.Clear();

            // Add the new MainSubjects to the Tutor's MainSubjects list
            tutor.MainSubjects.AddRange(mainSubject);

            // Save the changes to the database
            _unitOfWork.Save();

            return Ok(tutor); // Return the updated Tutor object
        }

        [HttpPut("AddOrUpdateFormOfWorkForTutor")]
        public IActionResult AddAndUpdateFormOfWorkForTutor(int tutorId, [FromBody] List<int> ListofFormOfWorkId)
        {
            // Validate input
            if (tutorId <= 0 || ListofFormOfWorkId == null)
            {
                return BadRequest("Invalid Tutor ID or Form Of Work ID.");
            }

            // Retrieve the Tutor entity from the database
            var tutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == tutorId, includeProperties: "MainSubjects,FormOfWorks");
            if (tutor == null)
            {
                return NotFound($"Tutor with ID {tutorId} not found.");
            }

            // Retrieve the FormOfWork entity from the database
            var formOfWork = new List<FormOfWork>();
            foreach (var formOfWorkId in ListofFormOfWorkId)
            {
                formOfWork.Add(_unitOfWork.FormOfWork.GetFirstOrDefault(f => f.Id == formOfWorkId));
            }

            if (formOfWork == null)
            {
                return NotFound($"Form Of Work not found.");
            }

            // Clear the existing FormOfWork list
            tutor.FormOfWorks.Clear();

            // Add the new FormOfWork to the Tutor's FormOfWork list
            tutor.FormOfWorks.AddRange(formOfWork);

            // Save the changes to the database
            _unitOfWork.Save();

            return Ok(tutor); // Return the updated Tutor object
        }
    }
}
