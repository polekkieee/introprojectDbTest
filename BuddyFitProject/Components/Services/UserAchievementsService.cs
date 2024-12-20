using BuddyFitProject.Data;
using BuddyFitProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BuddyFitProject.Components.Services
{
    public class UserAchievementsService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public UserAchievementsService(IDbContextFactory<BuddyFitDbContext> dbContext) // Constructor
        {
            DbContextFactory = dbContext;
        }

        // Adds a new UserAchievement to the database
        public void AddUserAchievement(UserAchievements userAchievement)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.UserAchievements.Add(userAchievement);
                dbContext.SaveChanges();
            }
        }

        // Retrieves the achievements of a specific user by their userId
        public List<UserAchievements> GetUserAchievementsByUserId(int userId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var userAchievements = dbContext.UserAchievements
                                                 .Where(ua => ua.UserId == userId).ToList();
                return userAchievements;
            }
        }

        // Retrieves a specific user achievement by userId and achievementId
        public UserAchievements GetUserAchievementByUserAndAchievement(int userId, int achievementId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.UserAchievements
                                 .FirstOrDefault(ua => ua.UserId == userId && ua.AchievementId == achievementId);
            }
        }

        // Updates the status (unlocked or not) of a user achievement
        public void UpdateUserAchievement(UserAchievements userAchievement)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.UserAchievements.Update(userAchievement);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUserAchievements(int userId)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                // Fetch all exercises and statistics related to the user
                var achievements = dbContext.Achievements.ToList();
                var userAchievements = dbContext.UserAchievements
                    .Where(us => us.UserId == userId)
                    .ToDictionary(us => us.AchievementId); // Create dictionary for quick lookup

                foreach (var achievement in achievements)
                {
                    if (!userAchievements.TryGetValue(achievement.Id, out var existingAchievement))
                    {
                        // Create a new statistics entry if one doesn't exist
                        AddUserAchievement(new UserAchievements
                                        {
                                            AchievementId = achievement.Id,
                                            UserId = userId,
                                            Unlocked = false
                                        });
                    }
                }

                // Save changes to the database
                dbContext.SaveChanges();
            }
        }


        // Deletes a specific user achievement based on userId and achievementId
        public void DeleteUserAchievement(int userId, int achievementId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var userAchievement = dbContext.UserAchievements
                                                .FirstOrDefault(ua => ua.UserId == userId && ua.AchievementId == achievementId);

                if (userAchievement != null)
                {
                    dbContext.UserAchievements.Remove(userAchievement);
                    dbContext.SaveChanges();
                }
            }
        }

        // Checks if a user has unlocked a specific achievement
        public bool HasUserUnlockedAchievement(int userId, int achievementId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.UserAchievements
                                 .Any(ua => ua.UserId == userId && ua.AchievementId == achievementId && ua.Unlocked);
            }
        }

        // Retrieves a list of unlocked achievements for a specific user
        public List<UserAchievements> GetUnlockedAchievements(int userId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.UserAchievements
                                 .Where(ua => ua.UserId == userId && ua.Unlocked).ToList();
            }
        }

        // Retrieves a list of all achievements for a specific user, unlocked or not
        public List<UserAchievements> GetAllAchievements(int userId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.UserAchievements
                                 .Where(ua => ua.UserId == userId).ToList();
            }
        }
    }
}
