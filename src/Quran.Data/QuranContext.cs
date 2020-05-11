using Microsoft.EntityFrameworkCore;
using Quran.Core;
using Quran.Data.SerilizationDtos;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Quran.Data
{
    public class QuranContext : DbContext
    {
        public QuranContext(DbContextOptions<QuranContext> options)
    : base(options)
        { }

        public DbSet<Verse> Verses { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Part> Parts { get; set; }
        
    }
}
