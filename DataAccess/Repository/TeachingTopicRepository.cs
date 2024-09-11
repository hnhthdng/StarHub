using DataAccess.Repository.IRepository;
using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TeachingTopicRepository : Repository<TeachingTopic>, ITeachingTopicRepository
    {
        private readonly AppDbContext _db;

        public TeachingTopicRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TeachingTopic teachingTopic)
        {
            var objFromDb = _db.TeachingTopics.FirstOrDefault(s => s.Id == teachingTopic.Id);
            if (objFromDb != null)
            {
                objFromDb.Topic = teachingTopic.Topic;
            }
        }
    }
}
