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
    public class VerseOutputDto
    {
        /// <summary>
        /// رقم معرف الاية السابقة
        /// </summary>
        public int PreviousId
        {
            get
            {
                return (Id - 1) > 0 ? (Id - 1) : Const.VerseCount;
            }
        }

        /// <summary>
        /// رقم معرف الاية اللاحقة
        /// </summary>
        public int NextId
        {
            get
            {
                return (Id + 1) > Const.VerseCount ? 1 : (Id + 1);
            }
        }

        public string Audio
        {
            get
            {
                return $"/audio/{ChapterIndex.ToString().PadLeft(3,'0')}/{VerseIndex.ToString().PadLeft(3, '0')}.mp3";
            }
        }
       

        /// <summary>
        /// رقم معرف الاية
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// رقم تسلسل الاية ضمن السورة, البسملة ترقم صفر, عدا في سورة البقرة
        /// </summary>
        public int VerseIndex { get; set; }


        /// <summary>
        /// رقم تسلسل السورة من 1 وحتى 144
        /// </summary>
        public int ChapterIndex { get; set; }

        /// <summary>
        /// رقم تسلسل الصفحة من 1 وحتى 604
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// رقم تسلسل الجزء من 1 وحتى 30
        /// </summary>
        public int PartIndex { get; set; }

        /// <summary>
        /// محتوى الآية
        /// </summary>
        public string Content { get; set; }
    }
}
