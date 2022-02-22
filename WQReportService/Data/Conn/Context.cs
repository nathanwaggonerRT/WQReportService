using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace WQReportService.Data
{
    public partial class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ScheduledReport_check> ScheduledReport_check { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        
    }
}
