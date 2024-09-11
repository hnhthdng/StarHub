using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class FormOfWork
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Form { get; set; } // off, onl

        public List<Tutor> Tutors { get; set; }
    }
}
