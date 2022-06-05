using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccesEF
{
    public class VivieroContext : DbContext
    {

        public VivieroContext(DbContextOptions<VivieroContext> options) :
            base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=.\SQLSERVER19; database=Libreria_2022; Integrated Security = true");
        }
    }
}
