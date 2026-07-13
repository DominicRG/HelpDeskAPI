using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HelpDesk.Domain.Entities;
using HelpDesk.Infrastructure.Persistence.Interfaces;

namespace HelpDesk.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IDatabaseContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<Area> Area { get; set; }
        public DbSet<Area> Area => Set<Area>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
