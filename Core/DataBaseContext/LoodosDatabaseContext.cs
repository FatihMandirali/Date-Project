using Core.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataBaseContext
{
   public class LoodosDatabaseContext : DbContext
    {
        public LoodosDatabaseContext()
        {

        }

        public LoodosDatabaseContext(DbContextOptions<LoodosDatabaseContext> options)
            : base(options)
        {

        }
        public DbSet<Date> Date { get; set; }
    }
}
