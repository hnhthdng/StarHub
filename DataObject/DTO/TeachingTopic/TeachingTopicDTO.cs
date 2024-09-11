using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.DTO.TeachingTopic
{
    public class TeachingTopicDTO
    {
        [Required]
        [MaxLength(100)]
        public string Topic { get; set; }
    }
}
