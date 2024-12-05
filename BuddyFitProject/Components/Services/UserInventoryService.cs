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
    }
}
