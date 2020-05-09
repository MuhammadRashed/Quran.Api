using Quran.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quran.Api.Dtos
{

    /// <summary>
    /// بيانات الاية
    /// </summary>
    public class AyaOutputDto
    {
        /// <summary>
        /// رقم معرف الاية السابقة
        /// </summary>
        public int PreviousId
        {
            get
            {
                return (Id - 1) > 0 ? (Id - 1) : Const.AyaCount;
            }
        }

        /// <summary>
        /// رقم معرف الاية اللاحقة
        /// </summary>
        public int NextId
        {
            get
            {
                return (Id + 1) > Const.AyaCount ? 1 : (Id + 1);
            }
        }

        public string Audio
        {
            get
            {
                return $"/audio/{SurahIndex.ToString().PadLeft(3,'0')}/{AyaIndex.ToString().PadLeft(3, '0')}.mp3";
            }
        }
       

        /// <summary>
        /// رقم معرف الاية
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// رقم تسلسل الاية ضمن السورة, البسملة ترقم صفر, عدا في سورة البقرة
        /// </summary>
        public int AyaIndex { get; set; }


        /// <summary>
        /// رقم تسلسل السورة من 1 وحتى 144
        /// </summary>
        public int SurahIndex { get; set; }

        /// <summary>
        /// رقم تسلسل الصفحة من 1 وحتى 604
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// رقم تسلسل الجزء من 1 وحتى 30
        /// </summary>
        public int JuzIndex { get; set; }

        /// <summary>
        /// محتوى الآية
        /// </summary>
        public string Content { get; set; }
    }
}
