using BuddyFitProject.Data.Models;
using BuddyFitProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BuddyFitProject.Components.Services
{
    public class UserInventoryService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public UserInventoryService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }
        public List<UserInventory> GetInventory(int userId)
        {
            List<UserInventory> inventory = new();
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                inventory = dbContext.UserInventory
                            .Where(x => x.UserId == userId)
                            .ToList();

                if (!inventory.Any())
                    throw new Exception("User Inventory does not exist!");
                return inventory;

            }
        }

        public UserInventory GetInventoryItem(int userId, int itemId)
        {
            List<UserInventory> inventory = new();
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.UserInventory.SingleOrDefault(x => x.UserId == userId && x.ItemId == itemId);
            }
        }

        public List<UserInventory> GetInventoryOfType(int userId, string type)
        {
            List<UserInventory> inventory = new();
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                inventory = dbContext.UserInventory
                            .Where
                                    (
                                    x => 
                                        x.UserId == userId && 
                                        x.ItemId == dbContext.Items.FirstOrDefault
                                                    (y => y.Id == x.ItemId && y.Type == type)
                                                    .Id
                                    )
                            .ToList();

                if (!inventory.Any())
                    throw new Exception("User Inventory does not exist!");
                return inventory;

            }
        }

        public void AddUserInventory(UserInventory userInventory)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.UserInventory.Add(userInventory);
                dbContext.SaveChanges();
            }
        }

        public bool UserInventoryExists(int userId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.UserInventory.Any(x => x.UserId == userId);
            }
        }
    }
}
