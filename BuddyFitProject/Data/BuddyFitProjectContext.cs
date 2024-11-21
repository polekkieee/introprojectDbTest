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
        public DbSet<Exercise> Exercise { get; set; } = default!;
        public DbSet<Item> Item { get; set; } = default!;
        public DbSet<Pet> Pet { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<UserInventory> UserInventory { get; set; } = default!;
        public DbSet<UserStatistics> UserStatistics { get; set; } = default!;
        public DbSet<WorkoutSession> WorkoutSession { get; set; } = default!;

    }
}
