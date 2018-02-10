using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Consumer.Model
{
    public class ConsumerContext : DbContext
    {
      public ConsumerContext(DbContextOptions<ConsumerContext> options)
        : base(options)
      {
        Database.Migrate();
      }

        public DbSet<StudentInfo> StudentInfos { get; set; }

       
  }
}
