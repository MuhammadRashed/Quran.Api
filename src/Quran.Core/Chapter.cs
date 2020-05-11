using System;
using System.Collections.Generic;
using System.Text;

namespace Quran.Core
{
    public class Chapter
    {
        public int Id { get; set; }
        public int ChapterIndex { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public int Pages { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }
}
