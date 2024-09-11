using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IMainSubjectRepository : IRepository<MainSubject>
    {
        void Update(MainSubject mainSubject);
    }
}
