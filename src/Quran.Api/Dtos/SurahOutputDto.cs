using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quran.Api.Dtos
{

    /// <summary>
    /// بيانات السورة
    /// </summary>
    public class SurahOutputDto
    {

        /// <summary>
        /// رقم تسلسل السورة
        /// </summary>
        public int SurahIndex { get; set; }

        /// <summary>
        /// اسم السورة باللغة الانجليزية
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// اسم السورة باللغة العربية
        /// </summary>
        public string TitleAr { get; set; }

        /// <summary>
        /// عدد صفحات السورة 
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// عدد ايات السورة
        /// </summary>
        public int Count { get; set; }
    }
}
