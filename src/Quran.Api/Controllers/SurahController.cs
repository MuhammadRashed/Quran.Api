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
    [Route("[controller]")]
    [ApiController]
    public class SurahController : ControllerBase
    {
        private readonly QuranContext quranContext;
        private readonly IMapper mapper;

        public SurahController(QuranContext quranContext, IMapper mapper)
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
        public async Task<ActionResult<SurahOutputDto[]>> GetAll()
        {
            var result = await quranContext.Surahs.ToListAsync();
            var parsed = mapper.Map<SurahOutputDto[]>(result);
            return parsed;
        }

        /// <summary>
        /// بيانات سورة محددة
        /// </summary>
        /// <param name="SurahIndex"></param>
        /// <returns></returns>
        [Route("{SurahIndex}")]
        [HttpGet]
        public async Task<ActionResult<SurahOutputDto>> GetById(int SurahIndex)
        {
            var result = await quranContext.Surahs.FindAsync(SurahIndex);
            var parsed = mapper.Map<SurahOutputDto>(result);
            return parsed;
        }

        /// <summary>
        /// صفحات سورة محددة
        /// </summary>
        /// <param name="SurahIndex"></param>
        /// <returns></returns>
        [Route("{SurahIndex}/Pages")]
        [HttpGet]
        public async Task<ActionResult<int[]>> GetRelatedPages(int SurahIndex)
        {
            var result =await quranContext.Ayas.Where(r=>r.SurahId == SurahIndex).Select(p => p.PageId.Value).Distinct().OrderBy(u=>u).ToArrayAsync();
            return result;
        }

        /// <summary>
        /// اجزاء سورة محددة
        /// </summary>
        /// <param name="SurahIndex"></param>
        /// <returns></returns>
        [Route("{SurahIndex}/Juz")]
        [HttpGet]
        public async Task<ActionResult<int[]>> GetRelatedJuz(int SurahIndex)
        {
            var result = await quranContext.Ayas.Where(r => r.SurahId == SurahIndex).Select(p => p.JuzId.Value).Distinct().OrderBy(u => u).ToArrayAsync();
            return result;
        }

    }
}
