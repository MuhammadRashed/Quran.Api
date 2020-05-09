using System;
using System.Collections.Generic;
using System.Text;

namespace Quran.Core
{
    public class Juz
    {
        public int Id { get; set; }
        public int JuzIndex { get; set; }
        public ICollection<Aya> Ayas { get; set; }
    }
}
