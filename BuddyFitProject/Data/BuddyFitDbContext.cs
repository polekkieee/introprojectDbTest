using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuddyFitProject.Data.Models;

namespace BuddyFitProject.Data
{
    public class BuddyFitDbContext(DbContextOptions<BuddyFitDbContext> options) : DbContext(options)
    {
        public DbSet<Exercises> Exercises { get; set; } = default!;
        public DbSet<Items> Items { get; set; } = default!;
        public DbSet<Pets> Pets { get; set; } = default!;
        public DbSet<Users> Users { get; set; } 
        public DbSet<UserInventory> UserInventory { get; set; } = default!;
        public DbSet<UserStatistics> UserStatistics { get; set; } = default!;
        public DbSet<WorkoutSessions> WorkoutSessions { get; set; } = default!;
        public DbSet<Achievements> Achievements { get; set; } = default!;
        public DbSet<UserAchievements> UserAchievements { get; set; } = default!;



    }
}

