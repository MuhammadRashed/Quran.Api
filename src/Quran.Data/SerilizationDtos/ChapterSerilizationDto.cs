using System;
using System.Collections.Generic;
using System.Text;

namespace Quran.Data.SerilizationDtos
{
    class ChapterSerilizationDto
    {
        public int Index { get; set; }
        public int Count { get; set; }

        public string Title { get; set; }
        public string TitleAr { get; set; }
        public int Pages { get; set; }
        public string Type { get; set; }

        public object verse { get; set; }
    }
}
