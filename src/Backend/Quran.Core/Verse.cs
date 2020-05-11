using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quran.Core
{
    public class Verse
    {
        [Key]
        public int Id { get; set; }
        public int VerseIndex { get; set; }

        public string Content { get; set; }


        public int ChapterId { get; set; }

        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; }

        
        public int? PartId { get; set; }
        [ForeignKey("PartId")]
        public Part Part { get; set; }



        public int? PageId { get; set; }
        
        [ForeignKey("PageId")]
        public Page Page { get; set; }

        public override string ToString()
        {
            return $"{ChapterId}_{VerseIndex}";
        }

    }
}
