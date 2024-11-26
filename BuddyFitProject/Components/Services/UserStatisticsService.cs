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

        //public void UpdateUser(Users user, string email)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        user.Email = email;
        //        dbContext.Users.Update(user);
        //        dbContext.SaveChanges();
        //    }
        //}

        //public bool ValidateUser(string username, string password)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        return (dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Password == password) != null);
        //    }
        //}

        //public void AddWorkout(Users user, WorkoutSessions workout)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        //user.WorkoutSessions.Add(workout);
        //        //workout.user = user;
        //        dbContext.Users.Update(user);
        //        dbContext.SaveChanges();
        //    }
        //}
    }
}
