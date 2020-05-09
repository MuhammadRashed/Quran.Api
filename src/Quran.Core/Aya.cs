using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quran.Core
{
    public class Aya
    {
        [Key]
        public int Id { get; set; }
        public int AyaIndex { get; set; }

        public string Content { get; set; }


        public int SurahId { get; set; }

        [ForeignKey("SurahId")]
        public Surah Surah { get; set; }

        
        public int? JuzId { get; set; }
        [ForeignKey("JuzId")]
        public Juz Juz { get; set; }



        public int? PageId { get; set; }
        
        [ForeignKey("PageId")]
        public Page Page { get; set; }

        public override string ToString()
        {
            return $"{SurahId}_{AyaIndex}";
        }

    }
}
