using AutoMapper;
using Quran.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quran.Api.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Aya, AyaOutputDto>()
                .ForMember(
                mem => mem.SurahIndex,
                opt => opt.MapFrom(t => t.SurahId)
                )
                .ForMember(
                mem => mem.PageIndex,
                opt => opt.MapFrom(t => t.PageId)
                )
                .ForMember(
                mem => mem.JuzIndex,
                opt => opt.MapFrom(t => t.JuzId)
                )
                ;

            CreateMap<Surah, SurahOutputDto>();
            CreateMap<Juz, JuzOutputDto>();

            

        }
    }
}
