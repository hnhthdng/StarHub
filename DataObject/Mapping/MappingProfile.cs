﻿using AutoMapper;
using DataObject.DTO.MainSubject;
using DataObject.DTO.Tutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define the mapping between Tutor and TutorBasicInfoDTO
            CreateMap<Tutor, TutorBasicInfoDTO>().ReverseMap();

            //Define the mapping between MainSubject and MainSubjectDTO
            CreateMap<MainSubject, MainSubjectDTO>().ReverseMap();
        }
    }
}
