using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quran.Api.Dtos
{

    /// <summary>
    /// بيانات الجزء
    /// </summary>
    public class PartOutputDto
    {

        /// <summary>
        /// رقم التسلسلي للجزء - رقم من 1 وحتى 30
        /// </summary>
        public int PartIndex { get; set; }


        /// <summary>
        /// الارقام التسلسلية الخاصة بالسور
        /// </summary>
        public int[] Chapters { get; set; }
    }
}
