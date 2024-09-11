using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ITutorRepository : IRepository<Tutor>
    {
        void Update(Tutor tutor);
    }
}
