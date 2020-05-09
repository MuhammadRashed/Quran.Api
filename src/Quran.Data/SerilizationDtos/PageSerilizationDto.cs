using System;
using System.Collections.Generic;
using System.Text;

namespace Quran.Data.SerilizationDtos
{
    class PageSerilizationDto
    {
        public int Page { get; set; }
        public AyaSerilizationDto[] Ayats { get; set; }
    }
}
