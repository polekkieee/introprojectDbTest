using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuddyFitProject.Models;

namespace BuddyFitProject.Data
{
    public class BuddyFitProjectContext(DbContextOptions<BuddyFitProjectContext> options) : DbContext(options)
    {
        public DbSet<BuddyFitProject.Models.User> User { get; set; } = default!;
        public DbSet<BuddyFitProject.Models.Workout> Workout { get; set; } = default!;
    }
}
