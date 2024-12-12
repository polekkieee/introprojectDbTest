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

        public PetService(IDbContextFactory<BuddyFitDbContext> dbContext) //Construction to initialize the service with a database context factory
        {
            DbContextFactory = dbContext;
        }

        public Pets GetPet(int userId) //Retrieves pet from correct user from the database
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                var pet = dbContext.Pets.FirstOrDefault(x => x.UserId == userId);
                return pet;
            }
        }

        public void UpdatePet(Pets pet) //Logic to update pet in the database
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Pets.Update(pet);
                dbContext.SaveChanges();
            }
        }

        public int DecreaseHealth(Users user, Pets pet) //Logic to lower the health percentage
        {
            if (DateTime.Compare(pet.Health_bar_tlc, user.Register_moment) <= 0)
            {
                return pet.Health_bar;
            }

            if (pet.Health_bar < 100)
            {
                TimeSpan Ts = DateTime.Now - pet.Health_bar_tlc; //Timespan since user was registered
                pet.Health_bar -= Ts.Hours; //So the healthbar lowers one every hour
                pet.Health_bar = Math.Max(0, pet.Health_bar); //So it doesn't go under 0
                pet.Health_bar_tlc = DateTime.Now; //Reset the datetime
                UpdatePet(pet);
            }
            return pet.Health_bar;
        }

        public int IncreaseHealth(int TotalMinutes, Pets pet) //Logic to increase the health percentage
        {
            if (pet.Health_bar < 100)
            {
                pet.Health_bar += TotalMinutes / 2; //Healthbar increases 1 every 2 minutes you workout
                pet.Health_bar = Math.Min(100, pet.Health_bar); //So it doesn't go over the 100
                pet.Health_bar_tlc = DateTime.Now; //Reset the datetime
                UpdatePet(pet);
            }
            return pet.Health_bar;
        }

        public int ChangeStamina(Pets pet, int TotalMinutes) //Logic to change the stamina percentage
        {
            if (pet.Stamina_bar < 100)
            {
                pet.Stamina_bar += TotalMinutes / 5; //Staminabar increases 1 every 5 minutes you workout
                pet.Stamina_bar = Math.Min(100, pet.Stamina_bar);  
                pet.Stamina_bar = Math.Max(0, pet.Stamina_bar); 
                UpdatePet(pet); 
            }
            return pet.Stamina_bar;
        }

        public int DigestFood(Users user, Pets pet) //Logic to lower the food percentage
        {
            if (DateTime.Compare(pet.Food_bar_tlc, user.Register_moment) <= 0)
            {
                return pet.Food_bar;
            }

            if (pet.Food_bar > 0)
            {
                TimeSpan Ts = DateTime.Now - pet.Food_bar_tlc; //Timespan since user was registered
                pet.Food_bar -= Ts.Hours; //So the foodbar lowers one every hour
                pet.Food_bar = Math.Max(0, pet.Food_bar); 
                pet.Food_bar_tlc = DateTime.Now; //Resetting pet.Food_bar_tlc to the time it was last changed
                UpdatePet(pet);
            }
            return pet.Food_bar;
        }

        public int EatFood(Pets pet) //Logic to increase the food percentage
        {
            if (pet.Food_bar < 100)
            {
                pet.Food_bar = Math.Min(100, pet.Food_bar + 20);
                pet.Food_bar_tlc = DateTime.Now;
                UpdatePet(pet);
            }
            return pet.Food_bar;
        }
    }
}