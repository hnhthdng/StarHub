using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class Tutor
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public int TuitionFee { get; set; }

        public List<MainSubject> MainSubjects { get; set; }

        [MaxLength(200)]
        public string LivingAt { get; set; }

        public List<FormOfWork> FormOfWorks { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        [Required]
        public int Gender { get; set; } // 1: Nam, 2: Nu

        [MaxLength(100)]
        public string Hometown { get; set; }

        [MaxLength(200)]
        public string Education { get; set; }

        [MaxLength(500)]
        public string Experience { get; set; }

        [MaxLength(500)]
        public string Achievement { get; set; }

        public List<TeachingTopic> TeachingTopics { get; set; }

        [MaxLength(200)]
        public string CurrentStatus { get; set; } // Ex: Hiện đang là sinh viên

        [MaxLength(200)]
        public string TeachingArea { get; set; }
    }

}
