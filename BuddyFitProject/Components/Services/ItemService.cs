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
        public Items GetItemsById(int id)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                Items Item = dbContext.Items.SingleOrDefault<Items>(x => x.Id == id) ?? throw new Exception("Item bestaat niet!");
                return Item;
            }
        }
    }
}

