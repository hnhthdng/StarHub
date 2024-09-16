using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Tutor = new TutorRepository(_db);
            MainSubject = new MainSubjectRepository(_db);
            FormOfWork = new FormOfWorkRepository(_db);
            TeachingTopic = new TeachingTopicRepository(_db);
            Post = new PostRepository(_db);
        }
        public ITutorRepository Tutor { get; private set; }
        public IMainSubjectRepository MainSubject { get; private set; }
        public IFormOfWorkRepository FormOfWork { get; private set; }
        public ITeachingTopicRepository TeachingTopic { get; private set; }
        public IPostRepository Post { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
