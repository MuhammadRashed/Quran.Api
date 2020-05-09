using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quran.Api.Dtos
{

    /// <summary>
    /// بيانات الجزء
    /// </summary>
    public class JuzOutputDto
    {

        /// <summary>
        /// رقم التسلسلي للجزء - رقم من 1 وحتى 30
        /// </summary>
        public int JuzIndex { get; set; }


        /// <summary>
        /// الارقام التسلسلية الخاصة بالسور
        /// </summary>
        public int[] Surahs { get; set; }
    }
}
