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
    [Route("[controller]")]
    [ApiController]
    public class AyaController : ControllerBase
    {
        private readonly QuranContext quranContext;
        private readonly IMapper mapper;

        public AyaController(QuranContext quranContext , IMapper mapper )
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
        public async Task<ActionResult<AyaOutputDto[]>> GetTopHundredBySearch(string search)
        {
            search = TextOperations.SkipChars(search);
            var parsed = mapper.Map<AyaOutputDto[]>(await quranContext.Ayas.ToListAsync())
                .Where(t => TextOperations.SkipChars(t.Content).Contains(search)).Take(100).ToArray();
            return parsed;
        }

        /// <summary>
        /// جلب بيانات الاية حسب المعرف الخاص بها
        /// </summary>
        /// <param name="AyaId">من واحد وحتى 6348</param>
        /// <returns></returns>
        [Route("{AyaId}")]
        [HttpGet]
        public async Task<ActionResult<AyaOutputDto>> GetById(int AyaId)
        {
            var result = await quranContext.Ayas.FindAsync(AyaId);
            var parsed = mapper.Map<AyaOutputDto>(result);
            return parsed;
        }

        /// <summary>
        /// ايات سورة
        /// </summary>
        /// <param name="SurahIndex">رقم السورة من 1 وحتى 144</param>
        /// <returns></returns>
        [Route("Surah/{SurahIndex}")]
        [HttpGet]
        public async Task<ActionResult<AyaOutputDto[]>> GetBySurah(int SurahIndex)
        {
            var result = await quranContext.Ayas.Where(r=>r.SurahId == SurahIndex).OrderBy(y=>y.Id).ToListAsync();
            var parsed = mapper.Map<AyaOutputDto[]>(result);
            return parsed;
        }

        /// <summary>
        /// اية سورة
        /// </summary>
        /// <param name="AyaIndex">رقم الاية في السورة</param>
        /// <param name="SurahIndex">رقم السورة</param>
        /// <returns></returns>
        [Route("{AyaIndex}/Surah/{SurahIndex}")]
        [HttpGet]
        public async Task<ActionResult<AyaOutputDto>> GetBySurah(int AyaIndex, int SurahIndex)
        {
            var result = await quranContext.Ayas.Where(r=>r.SurahId == SurahIndex & r.AyaIndex == AyaIndex ).FirstOrDefaultAsync();
            var parsed = mapper.Map<AyaOutputDto>(result);
            return parsed;
        }

        /// <summary>
        /// ايات جزء
        /// </summary>
        /// <param name="JuzIndex">رقم الجزء من 1 وحتى 30</param>
        /// <returns></returns>
        [Route("Juz/{JuzIndex}")]
        [HttpGet]
        public async Task<ActionResult<AyaOutputDto[]>> GetByJuz(int JuzIndex)
        {
            var result = await quranContext.Ayas.Where(r => r.JuzId == JuzIndex).OrderBy(t=>t.Id).ToListAsync();
            var parsed = mapper.Map<AyaOutputDto[]>(result);
            return parsed;
        }

        /// <summary>
        /// ايات صفحة
        /// </summary>
        /// <param name="PageIndex">رقم الصفحة من 1 وحتى 604</param>
        /// <returns></returns>
        [Route("Page/{PageIndex}")]
        [HttpGet]
        public async Task<ActionResult<AyaOutputDto[]>> GetByPage(int PageIndex)
        {
            var result = await quranContext.Ayas.Where(r => r.PageId == PageIndex).OrderBy(t => t.Id).ToListAsync();
            var parsed = mapper.Map<AyaOutputDto[]>(result);
            return parsed;
        }
    }
}
