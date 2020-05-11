using Microsoft.AspNetCore.Mvc;
using Quran.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Quran.Api.Dtos;

namespace Quran.Api.Controllers
{
    /// <summary>
    /// بيانات السورة
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly QuranContext quranContext;
        private readonly IMapper mapper;

        public ChapterController(QuranContext quranContext, IMapper mapper)
        {
            this.quranContext = quranContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// جميع السور
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<ChapterOutputDto[]>> GetAll()
        {
            var result = await quranContext.Chapters.ToListAsync();
            var parsed = mapper.Map<ChapterOutputDto[]>(result);
            return parsed;
        }

        /// <summary>
        /// بيانات سورة محددة
        /// </summary>
        /// <param name="ChapterIndex"></param>
        /// <returns></returns>
        [Route("{ChapterIndex}")]
        [HttpGet]
        public async Task<ActionResult<ChapterOutputDto>> GetById(int ChapterIndex)
        {
            var result = await quranContext.Chapters.FindAsync(ChapterIndex);
            var parsed = mapper.Map<ChapterOutputDto>(result);
            return parsed;
        }

        /// <summary>
        /// صفحات سورة محددة
        /// </summary>
        /// <param name="ChapterIndex"></param>
        /// <returns></returns>
        [Route("{ChapterIndex}/Pages")]
        [HttpGet]
        public async Task<ActionResult<int[]>> GetRelatedPages(int ChapterIndex)
        {
            var result =await quranContext.Verses.Where(r=>r.ChapterId == ChapterIndex).Select(p => p.PageId.Value).Distinct().OrderBy(u=>u).ToArrayAsync();
            return result;
        }

        /// <summary>
        /// اجزاء سورة محددة
        /// </summary>
        /// <param name="ChapterIndex"></param>
        /// <returns></returns>
        [Route("{ChapterIndex}/Part")]
        [HttpGet]
        public async Task<ActionResult<int[]>> GetRelatedPart(int ChapterIndex)
        {
            var result = await quranContext.Verses.Where(r => r.ChapterId == ChapterIndex).Select(p => p.PartId.Value).Distinct().OrderBy(u => u).ToArrayAsync();
            return result;
        }

    }
}
