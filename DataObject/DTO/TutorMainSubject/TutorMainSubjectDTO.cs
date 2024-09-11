using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.DTO.TutorMainSubject
{
    public class TutorMainSubjectDTO
    {
        public int TutorId { get; set; }
        public List<int> MainSubjectIds { get; set; } // Use IDs if you only need to link existing subjects
    }
}
