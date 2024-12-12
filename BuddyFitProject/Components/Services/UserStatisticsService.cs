using BuddyFitProject.Data.Models;
using BuddyFitProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BuddyFitProject.Components.Services
{
    public class UserStatisticsService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public UserStatisticsService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }

        public List<UserStatistics> GetStatisticsByUser(int id)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                var stats = dbContext.UserStatistics
                    .Where(x => x.UserId == id)
                    .ToList();

                if (!stats.Any())
                    throw new Exception("User statistics do not exist!");

                return stats;
            }
        }

        public UserStatistics GetStatisticByUserAndExercise(int userId, int exerciseId)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                var stats = dbContext.UserStatistics.FirstOrDefault(x => x.UserId == userId && x.ExerciseId == exerciseId);
                return stats;
            }
        }

        public void UpdateUserStatistics(int userId)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                // Fetch all exercises and statistics related to the user
                var exercises = dbContext.Exercises.ToList();
                var userStats = dbContext.UserStatistics
                    .Where(us => us.UserId == userId)
                    .ToDictionary(us => us.ExerciseId); // Create dictionary for quick lookup

                foreach (var exercise in exercises)
                {
                    // Calculate total minutes and coins for the current exercise
                    var userWorkouts = dbContext.WorkoutSessions
                        .Where(ws => ws.UserId == userId && ws.ExerciseId == exercise.Id)
                        .ToList();

                    int totalMinutes = userWorkouts.Sum(ws => ws.Minutes);
                    int totalCoins = userWorkouts.Sum(ws => ws.Reward);

                    if (totalMinutes > 0 || totalCoins > 0) // Only update if there are relevant workouts
                    {
                        if (userStats.TryGetValue(exercise.Id, out var existingStat))
                        {
                            // Update the existing statistics entry
                            existingStat.Total_minutes = totalMinutes;
                            existingStat.Total_coins = totalCoins;
                            dbContext.UserStatistics.Update(existingStat);
                        }
                        else
                        {
                            // Create a new statistics entry if one doesn't exist
                            AddUserStatistic(userId, exercise.Id);
                        }
                    }
                }

                // Save changes to the database
                dbContext.SaveChanges();
            }
        }

        public void AddUserStatistic(int userId, int exerciseId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                UserStatistics userStat = new();
                userStat.UserId = userId;
                userStat.ExerciseId = exerciseId;

                int total_minutes = 0;
                int total_coins = 0;

                foreach (WorkoutSessions workout in dbContext.WorkoutSessions.Where(x => x.ExerciseId == exerciseId && x.UserId == userId).ToList())
                {
                    total_minutes += workout.Minutes;
                    total_coins += workout.Reward;
                }

                userStat.Total_minutes = total_minutes;
                userStat.Total_coins = total_coins;

                dbContext.UserStatistics.Add(userStat);
                dbContext.SaveChanges();
            }
        }
    }
}
