using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.DTO.FormOfWork
{
    public class FormOfWorkDTO
    {
        [Required]
        [MaxLength(50)]
        public string Form { get; set; } // off, onl
    }
}
