using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IFormOfWorkRepository : IRepository<FormOfWork>
    {
        void Update(FormOfWork formOfWork);
    }
}
