using DataAccess.Repository.IRepository;
using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TutorRepository : Repository<Tutor>, ITutorRepository
    {
        private readonly AppDbContext _db;

        public TutorRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tutor tutor)
        {
            var objFromDb = _db.Tutors.FirstOrDefault(s => s.Id == tutor.Id);
            if (objFromDb != null)
            {
                objFromDb.FullName = tutor.FullName;
                objFromDb.TuitionFee = tutor.TuitionFee;    
                objFromDb.MainSubjects = tutor.MainSubjects;
                objFromDb.LivingAt = tutor.LivingAt;
                objFromDb.FormOfWorks = tutor.FormOfWorks;
                objFromDb.YearOfBirth = tutor.YearOfBirth;
                objFromDb.Gender = tutor.Gender;
                objFromDb.Hometown = tutor.Hometown;
                objFromDb.Education = tutor.Education;
                objFromDb.Experience = tutor.Experience;
                objFromDb.Achievement = tutor.Achievement;
                objFromDb.TeachingTopics = tutor.TeachingTopics;
                objFromDb.CurrentStatus = tutor.CurrentStatus;
                objFromDb.TeachingArea = tutor.TeachingArea;

            }
        }
    }
}
