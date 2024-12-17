using BuddyFitProject.Data.Models;
using BuddyFitProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BuddyFitProject.Components.Services
{
    public class ItemService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public ItemService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }
        public Items GetItemById(int id)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.Items.SingleOrDefault<Items>(x => x.Id == id);
            }
        }

        public List<Items> LoadItems()
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.Items.ToList();
            }
        }

    }
}

