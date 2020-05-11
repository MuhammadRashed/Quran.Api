using System;
using System.Collections.Generic;
using System.Text;

namespace Quran.Core
{
    public class Part
    {
        public int Id { get; set; }
        public int PartIndex { get; set; }
        public ICollection<Verse> Verses { get; set; }
    }
}
