using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Entities
{
    public class CoreAppDbContext : DbContext
    {
        public CoreAppDbContext(DbContextOptions options) :base(options) {

        }
        public DbSet<Restaurant> Restaurants { get;set;}
    }
}
