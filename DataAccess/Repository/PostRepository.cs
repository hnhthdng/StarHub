using DataAccess.Repository.IRepository;
using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly AppDbContext _db;

        public PostRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Post post)
        {
            var objFromDb = _db.Posts.FirstOrDefault(s => s.Id == post.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = post.Title;
                objFromDb.Content = post.Content;
            }
        }
    }
}
