using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITutorRepository Tutor { get; }
        IMainSubjectRepository MainSubject { get; }
        IFormOfWorkRepository FormOfWork { get; }
        ITeachingTopicRepository TeachingTopic { get; }
        IPostRepository Post { get; }
        void Save();
    }
}
