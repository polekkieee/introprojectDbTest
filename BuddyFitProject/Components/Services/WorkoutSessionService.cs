using BuddyFitProject.Data.Models;
using BuddyFitProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuddyFitProject.Components.Services
{
    public class WorkoutSessionService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public WorkoutSessionService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }

        public void AddWorkoutSessions(WorkoutSessions WorkSesh)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                WorkSesh.Timestamp = DateTime.Now;
                dbContext.WorkoutSessions.Add(WorkSesh); // Ensure this matches the DbSet for WorkoutSessions
                dbContext.SaveChanges();
            }
        }
        public List<WorkoutSessions> RetrieveWorkoutSessionss()
        {

            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                //return WorkoutSessions.Include(x => x.user).ToList();
                return null;
            }
        }
    }
}
