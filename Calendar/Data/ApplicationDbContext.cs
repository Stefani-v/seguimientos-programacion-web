using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Calendar.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
