using DataAccess.Repository.IRepository;
using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class FormOfWorkRepository : Repository<FormOfWork>, IFormOfWorkRepository
    {
        private readonly AppDbContext _db;

        public FormOfWorkRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FormOfWork formOfWork)
        {
            var objFromDb = _db.FormOfWorks.FirstOrDefault(s => s.Id == formOfWork.Id);
            if (objFromDb != null)
            {
                objFromDb.Form = formOfWork.Form;
            }
        }
    }
}
