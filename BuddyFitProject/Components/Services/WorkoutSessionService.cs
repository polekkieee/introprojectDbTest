using BuddyFitProject.Data.Models;
using BuddyFitProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BuddyFitProject.Components.Services
{
    public class WorkoutSessionService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public WorkoutSessionService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }

        public void AddWorkoutSession(WorkoutSessions WorkSesh)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                WorkSesh.Timestamp = DateTime.Now;
                dbContext.WorkoutSessions.Add(WorkSesh); // Ensure this matches the DbSet for WorkoutSessions
                dbContext.SaveChanges();
            }
        }

        public async Task AddWorkoutSessionAsync(WorkoutSessions WorkSesh)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                WorkSesh.Timestamp = DateTime.Now;
                await dbContext.WorkoutSessions.AddAsync(WorkSesh); // Ensure this matches the DbSet for WorkoutSessions
                await dbContext.SaveChangesAsync();
            }
        }

        public List<WorkoutSessions> LoadWorkoutSessionsByUser(int userId)
        {
            List<WorkoutSessions> workouts = new();
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                workouts = dbContext.WorkoutSessions
                    .Where(x => x.UserId == userId)
                    .ToList();

                if (!workouts.Any())
                    throw new Exception("User statistics do not exist!");

                return workouts;
            }
        }
    }
}
