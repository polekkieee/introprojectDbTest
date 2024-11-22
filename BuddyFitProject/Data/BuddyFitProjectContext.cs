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
        public DbSet<Exercises> Exercises { get; set; } = default!;
        public DbSet<Items> Items { get; set; } = default!;
        public DbSet<Pets> Pets { get; set; } = default!;
        public DbSet<Users> Users { get; set; } = default!;
        public DbSet<UserInventory> UserInventorys { get; set; } = default!;
        public DbSet<UserStatistics> UserStatistics { get; set; } = default!;
        public DbSet<WorkoutSessions> WorkoutSessions { get; set; } = default!;

    }
}
