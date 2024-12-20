using BuddyFitProject.Data;
using BuddyFitProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BuddyFitProject.Components.Services
{
    public class AchievementsService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public AchievementsService(IDbContextFactory<BuddyFitDbContext> dbContext) // Constructor
        {
            DbContextFactory = dbContext;
        }

        // Adds a new achievement to the database
        public void AddAchievement(Achievements achievement)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Achievements.Add(achievement);
                dbContext.SaveChanges();
            }
        }

        // Retrieves an achievement by its Id
        public Achievements GetAchievementById(int achievementId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Achievements
                                 .FirstOrDefault(a => a.Id == achievementId);
            }
        }

        // Retrieves all achievements
        public List<Achievements> GetAllAchievements()
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Achievements.ToList();
            }
        }

        // Retrieves achievements by name (for filtering)
        public List<Achievements> GetAchievementsByName(string name)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Achievements
                                 .Where(a => a.Name.Contains(name))
                                 .ToList();
            }
        }

        // Updates an existing achievement
        public void UpdateAchievement(Achievements achievement)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Achievements.Update(achievement);
                dbContext.SaveChanges();
            }
        }

        // Deletes an achievement by its Id
        public void DeleteAchievement(int achievementId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var achievement = dbContext.Achievements
                                           .FirstOrDefault(a => a.Id == achievementId);

                if (achievement != null)
                {
                    dbContext.Achievements.Remove(achievement);
                    dbContext.SaveChanges();
                }
            }
        }

        // Retrieves achievements by their condition type (e.g., 'level', 'exercise')
        public List<Achievements> GetAchievementsByConditionType(string conditionType)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Achievements
                                 .Where(a => a.Condition_Type == conditionType)
                                 .ToList();
            }
        }

        // Retrieves unlocked achievements (based on some user achievement data, assuming you have the unlocked status stored in UserAchievements)
        public List<int> GetUnlockedAchievementsIds(int userId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var userAchievements = dbContext.UserAchievements
                                                 .Where(ua => ua.UserId == userId && ua.Unlocked)
                                                 .Select(ua => ua.AchievementId);

                return dbContext.Achievements

                                 .Where(a => userAchievements.Contains(a.Id)).Select(x => x.Id)
                                 .ToList();
            }
        }
    }
}
