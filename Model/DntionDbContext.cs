using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class DntionDbContext : DbContext
    {
        public DntionDbContext(DbContextOptions<DntionDbContext> options) : base(options)
        {
        }
 
        public DbSet<Donations> donations { get; set; }

    }
}