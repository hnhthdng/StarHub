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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;


        public TutorController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tutors = _unitOfWork.Tutor.GetAll(includeProperty: "MainSubjects,FormOfWorks,TeachingTopics");
            return Ok(tutors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == id, includeProperties: "MainSubjects,FormOfWorks,TeachingTopics");
            if (tutor == null)
            {
                return NotFound();
            }
            return Ok(tutor);
        }

        [HttpPost("AddBasicInfo")]
        public IActionResult Post([FromForm] TutorBasicInfoDTO tutorDTO, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            // Ensure the upload directory exists
            string webRootPath = _hostingEnvironment.WebRootPath;
            string uploadsFolder = Path.Combine(webRootPath, "images", "avatarTutor");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate a unique file name
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadsFolder, fileName);

            // Save the file to the server
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
            }


            // Map the DTO to the entity
            Tutor tutor = _mapper.Map<Tutor>(tutorDTO);
            tutor.avatarURL = $"/images/avatarTutor/{fileName}";

            // Save the tutor to the database
            try
            {
                _unitOfWork.Tutor.Add(tutor);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to save tutor: {ex.Message}");
            }

            return CreatedAtAction("Get", new { id = tutor.Id }, tutor);
        }


        [HttpPut("UpdateBasicInfo/{id}")]
        public IActionResult Update(int id, [FromForm] TutorBasicInfoDTO tutorDTO, IFormFile file)
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

            // Handle optional image file upload
            if (file != null && file.Length > 0)
            {
                // Ensure the upload directory exists
                string webRootPath = _hostingEnvironment.WebRootPath;
                string uploadsFolder = Path.Combine(webRootPath, "images", "avatarTutor");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                // Save the new file to the server
                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Delete the old avatar file if it exists
                    if (!string.IsNullOrEmpty(existingTutor.avatarURL))
                    {
                        string oldFilePath = Path.Combine(webRootPath, existingTutor.avatarURL.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Update the avatar URL with the new file
                    existingTutor.avatarURL = $"/images/avatarTutor/{fileName}";
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
                }
            }

            // Map updated values from DTO to the existing entity (excluding avatarURL if not changed)
            _mapper.Map(tutorDTO, existingTutor);

            // Update the entity in the repository
            try
            {
                _unitOfWork.Tutor.Update(existingTutor);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update tutor: {ex.Message}");
            }

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
            var tutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == tutorId, includeProperties: "MainSubjects,FormOfWorks,TeachingTopics");
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
            var tutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == tutorId, includeProperties: "MainSubjects,FormOfWorks,TeachingTopics");
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

        [HttpPut("AddOrUpdateTeachingTopicsForTutor")]
        public IActionResult AddAndUpdateTeachingTopicsForTutor(int tutorId, [FromBody] List<int> ListofTeachingTopicId)
        {
            // Validate input
            if (tutorId <= 0 || ListofTeachingTopicId == null)
            {
                return BadRequest("Invalid Tutor ID or Teaching Topic ID.");
            }

            // Retrieve the Tutor entity from the database
            var tutor = _unitOfWork.Tutor.GetFirstOrDefault(t => t.Id == tutorId, includeProperties: "MainSubjects,FormOfWorks,TeachingTopics");
            if (tutor == null)
            {
                return NotFound($"Tutor with ID {tutorId} not found.");
            }

            // Retrieve the TeachingTopic entity from the database
            var teachingTopic = new List<TeachingTopic>();
            foreach (var teachingTopicId in ListofTeachingTopicId)
            {
                teachingTopic.Add(_unitOfWork.TeachingTopic.GetFirstOrDefault(tt => tt.Id == teachingTopicId));
            }

            if (teachingTopic == null)
            {
                return NotFound($"Teaching Topic not found.");
            }

            // Clear the existing TeachingTopic list
            tutor.TeachingTopics.Clear();

            // Add the new TeachingTopic to the Tutor's TeachingTopic list
            tutor.TeachingTopics.AddRange(teachingTopic);

            // Save the changes to the database
            _unitOfWork.Save();

            return Ok(tutor); // Return the updated Tutor object
        }
    }
}
