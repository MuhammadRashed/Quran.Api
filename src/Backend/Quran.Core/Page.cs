using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quran.Core
{
    public class Page
    {
        public int Id { get; set; }
        public int PageIndex { get; set; }
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }

        public ICollection<Verse> Verse { get; set; }
    }
}
