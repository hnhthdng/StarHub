using DataAccess.Repository.IRepository;
using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MainSubjectRepository : Repository<MainSubject>, IMainSubjectRepository
    {
        private readonly AppDbContext _db;

        public MainSubjectRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MainSubject mainSubject)
        {
            var objFromDb = _db.MainSubjects.FirstOrDefault(s => s.Id == mainSubject.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = mainSubject.Name;
            }
        }
    }
}
