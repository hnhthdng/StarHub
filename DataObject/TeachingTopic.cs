﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataObject
{
    public class TeachingTopic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Topic { get; set; }
        [JsonIgnore]

        public virtual List<Tutor> Tutors { get; set; }
    }
}
