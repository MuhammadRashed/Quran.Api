using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quran.Core
{
    public class Page
    {
        public int Id { get; set; }
        public int PageIndex { get; set; }
        public int JuzId { get; set; }

        [ForeignKey("JuzId")]
        public Juz Juz { get; set; }

        public ICollection<Aya> Aya { get; set; }
    }
}
