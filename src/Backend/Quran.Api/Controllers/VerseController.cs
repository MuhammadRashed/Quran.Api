using Microsoft.AspNetCore.Mvc;
using Quran.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using Quran.Api.Dtos;

namespace Quran.Api.Controllers
{
    /// <summary>
    /// بيانات الاية
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    public class VerseController : ControllerBase
    {
        private readonly QuranContext quranContext;
        private readonly IMapper mapper;

        public VerseController(QuranContext quranContext , IMapper mapper )
        {
            this.quranContext = quranContext;
            this.mapper = mapper;
        }


        /// <summary>
        /// البحث عن الايات
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/{search}")]
        public async Task<ActionResult<VerseOutputDto[]>> GetTopHundredBySearch(string search)
        {
            search = TextOperations.SkipChars(search);
            var parsed = mapper.Map<VerseOutputDto[]>(await quranContext.Verses.Where(t => t.CleanContent.Contains(search)).Take(100).ToArrayAsync());
            return parsed;
        }

        /// <summary>
        /// جلب بيانات الاية حسب المعرف الخاص بها
        /// </summary>
        /// <param name="VerseId">من واحد وحتى 6348</param>
        /// <returns></returns>
        [Route("{VerseId}")]
        [HttpGet]
        public async Task<ActionResult<VerseOutputDto>> GetById(int VerseId)
        {
            var result = await quranContext.Verses.FindAsync(VerseId);
            var parsed = mapper.Map<VerseOutputDto>(result);
            return parsed;
        }

        /// <summary>
        /// ايات سورة
        /// </summary>
        /// <param name="ChapterIndex">رقم السورة من 1 وحتى 144</param>
        /// <returns></returns>
        [Route("Chapter/{ChapterIndex}")]
        [HttpGet]
        public async Task<ActionResult<VerseOutputDto[]>> GetByChapter(int ChapterIndex)
        {
            var result = await quranContext.Verses.Where(r=>r.ChapterId == ChapterIndex).OrderBy(y=>y.Id).ToListAsync();
            var parsed = mapper.Map<VerseOutputDto[]>(result);
            return parsed;
        }

        /// <summary>
        /// اية سورة
        /// </summary>
        /// <param name="VerseIndex">رقم الاية في السورة</param>
        /// <param name="ChapterIndex">رقم السورة</param>
        /// <returns></returns>
        [Route("{VerseIndex}/Chapter/{ChapterIndex}")]
        [HttpGet]
        public async Task<ActionResult<VerseOutputDto>> GetByChapter(int VerseIndex, int ChapterIndex)
        {
            var result = await quranContext.Verses.Where(r=>r.ChapterId == ChapterIndex & r.VerseIndex == VerseIndex ).FirstOrDefaultAsync();
            var parsed = mapper.Map<VerseOutputDto>(result);
            return parsed;
        }

        /// <summary>
        /// ايات جزء
        /// </summary>
        /// <param name="PartIndex">رقم الجزء من 1 وحتى 30</param>
        /// <returns></returns>
        [Route("Part/{PartIndex}")]
        [HttpGet]
        public async Task<ActionResult<VerseOutputDto[]>> GetByPart(int PartIndex)
        {
            var result = await quranContext.Verses.Where(r => r.PartId == PartIndex).OrderBy(t=>t.Id).ToListAsync();
            var parsed = mapper.Map<VerseOutputDto[]>(result);
            return parsed;
        }

        /// <summary>
        /// ايات صفحة
        /// </summary>
        /// <param name="PageIndex">رقم الصفحة من 1 وحتى 604</param>
        /// <returns></returns>
        [Route("Page/{PageIndex}")]
        [HttpGet]
        public async Task<ActionResult<VerseOutputDto[]>> GetByPage(int PageIndex)
        {
            var result = await quranContext.Verses.Where(r => r.PageId == PageIndex).OrderBy(t => t.Id).ToListAsync();
            var parsed = mapper.Map<VerseOutputDto[]>(result);
            return parsed;
        }
    }
}
