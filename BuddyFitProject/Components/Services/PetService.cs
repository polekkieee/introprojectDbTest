using BuddyFitProject.Data.Models;
using BuddyFitProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BuddyFitProject.Components.Services
{
    public class PetService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public PetService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }



        public Pets GetPet(int userId)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                var pet = dbContext.Pets.FirstOrDefault(x => x.UserId == userId);
                return pet;
            }
        }

        public void UpdatePet(Pets pet)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Pets.Update(pet);
                dbContext.SaveChanges();
            }
        }

        public int ChangeHealth(Users user,Pets pet, List<WorkoutSessions> Workouts)
        {
            int totalMinutes = 0;
            foreach (var session in Workouts)
            {
                totalMinutes += session.Minutes;
            }
            if (pet.Health_bar <= 100)
            {
                pet.Health_bar = totalMinutes / 2;
            }
            if (pet.Health_bar > 100)
            {
                pet.Health_bar = 100;
            }
            TimeSpan Ts = DateTime.Now - user.Register_moment;
            pet.Health_bar -= Ts.Hours;
            if (pet.Health_bar <= 0)
            {
                pet.Health_bar = 0;
            }
            UpdatePet(pet);
            return pet.Health_bar;
        }

    }
}