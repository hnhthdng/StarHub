using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.DTO.Tutor
{
    public class TutorBasicInfoDTO
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        public int TuitionFee { get; set; }
        [MaxLength(200)]
        public string LivingAt { get; set; }
        [Required]
        public int YearOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }
        [MaxLength(100)]
        public string Hometown { get; set; }
        [MaxLength(200)]
        public string Education { get; set; }
        [MaxLength(500)]
        public string Experience { get; set; }
        [MaxLength(500)]
        public string Achievement { get; set; }
        [MaxLength(200)]
        public string CurrentStatus { get; set; }
        [MaxLength(200)]
        public string TeachingArea { get; set; }
    }
}
