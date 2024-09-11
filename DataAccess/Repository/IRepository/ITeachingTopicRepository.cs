using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ITeachingTopicRepository : IRepository<TeachingTopic>
    {
        void Update(TeachingTopic teachingTopic);
    }
}
