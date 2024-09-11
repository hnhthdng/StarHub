﻿using AutoMapper;
using DataAccess.Repository.IRepository;
using DataObject;
using DataObject.DTO.Tutor;
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
            var tutors = _unitOfWork.Tutor.GetAll();
            return Ok(tutors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tutor = _unitOfWork.Tutor.Get(id);
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

            return CreatedAtAction("Get", new { id = id }, existingTutor); ; // Return 204 No Content on successful update
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
    }
}
