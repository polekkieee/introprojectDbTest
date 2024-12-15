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

        public List<UserInventory> GetFullInventory(int userId)
        {
            List<UserInventory> inventory = new();
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                inventory = dbContext.UserInventory
                            .Where(x => x.UserId == userId)
                            .ToList();

                if (!inventory.Any())
                    UpdateUserInventory(userId);
                return inventory;

            }
        }

        public List<UserInventory> GetInventory(int userId)
        {
            List<UserInventory> inventory = new();
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                inventory = dbContext.UserInventory
                            .Where(x => x.UserId == userId && x.Quantity > 0)
                            .ToList();
                return inventory;
            }
        }

        public void UpdateUserInventory(int userId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var items = dbContext.Items.ToList();
                foreach (var item in items)
                {
                    if (!UserInventoryItemExists(userId, item.Id))
                    {
                        AddUserInventory(new UserInventory
                                        {
                                            UserId = userId,
                                            ItemId = item.Id,
                                            Quantity = 0
                                        });
                    }
                }
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

              
                return inventory;

            }
        }

        
  

        public void UpdateUserInventoryItem(UserInventory userinv)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var item = dbContext.UserInventory
            .FirstOrDefault(x => x.UserId == userinv.UserId && x.ItemId == userinv.ItemId);

                if (item != null)
                {
                    item.Quantity = userinv.Quantity;
                    dbContext.SaveChanges();
                }

                //dbContext.UserInventory.Update(userinv);
                //dbContext.SaveChanges();
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

        public bool UserInventoryItemExists(int userId, int itemId)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.UserInventory.Any(x => x.UserId == userId && x.ItemId == itemId);
            }
        }
    }
}
