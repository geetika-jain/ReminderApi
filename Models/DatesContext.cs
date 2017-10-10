using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ReminderApi.Models
{
    public class DatesContext : DbContext
    {
        public DatesContext(DbContextOptions<DatesContext> options)
            : base(options)
        {
        }

        public DbSet<Dates> Dates { get; set; }

    }
}
