using AutoMapper;
using DataAccess.Repository.IRepository;
using DataObject;
using DataObject.DTO.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Post.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_unitOfWork.Post.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Post post = _mapper.Map<Post>(postDTO);
            post.CreatedAt = DateTime.Now;
            _unitOfWork.Post.Add(post);
            _unitOfWork.Save();
            return CreatedAtAction("Get", new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = _unitOfWork.Post.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            _mapper.Map(postDTO, post);
            _unitOfWork.Post.Update(post);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _unitOfWork.Post.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            _unitOfWork.Post.Remove(post);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
