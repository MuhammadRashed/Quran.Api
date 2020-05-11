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
            CreateMap<Verse, VerseOutputDto>()
                .ForMember(
                mem => mem.ChapterIndex,
                opt => opt.MapFrom(t => t.ChapterId)
                )
                .ForMember(
                mem => mem.PageIndex,
                opt => opt.MapFrom(t => t.PageId)
                )
                .ForMember(
                mem => mem.PartIndex,
                opt => opt.MapFrom(t => t.PartId)
                )
                ;

            CreateMap<Chapter, ChapterOutputDto>();
            CreateMap<Part, PartOutputDto>();

            

        }
    }
}
