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

        //public void DeleteUser(Users user)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        dbContext.Users.Remove(user);
        //        dbContext.SaveChanges();
        //    }
        //}

        public void UpdateUserStatistics(int userId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var stats = dbContext.UserStatistics
                    .Where(x => x.UserId == userId)
                    .ToList();

                var workouts = dbContext.WorkoutSessions
                    .Where(x => x.UserId == userId)
                    .ToList();

                foreach(var workout in workouts)
                {
                    if(!dbContext.UserStatistics.Where(x => x.ExerciseId == workout.ExerciseId).Any())
                    {
                        AddUserStatistic(userId, workout.ExerciseId);
                    }
                }

                dbContext.UserStatistics.UpdateRange(stats);
                dbContext.SaveChanges();
            }
        }

        //public bool ValidateUser(string username, string password)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        return (dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Password == password) != null);
        //    }
        //}

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
