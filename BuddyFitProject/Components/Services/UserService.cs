using BuddyFitProject.Data;
using BuddyFitProject.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Azure.Identity;
using SendGrid.Helpers.Mail;
using BuddyFitProject.Components.Pages.Account;

namespace BuddyFitProject.Components.Services
{
    public class UserService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public UserService(IDbContextFactory<BuddyFitDbContext> dbContext) //Constructor
        {
            DbContextFactory = dbContext;
        }

        public void AddUser(Users user) //Saves the user into the database
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public Users GetUserByName(string name) //Retrieves the user from the database using their username
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                Users user = dbContext.Users.SingleOrDefault<Users>(x => x.Username == name);
                return user;
            }
        }

        public Users GetUserById(int id) //Retrieves the user from the database using their id
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                Users user = dbContext.Users.SingleOrDefault<Users>(x => x.Id == id);
                return user;
            }
        }

        public Users GetUserByLogin(string name, string password) //Retrieves the user from the database using their username and password
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                Users user = dbContext.Users.SingleOrDefault<Users>(x => x.Username == name && x.Password == password);
                return user;
            }
        }

        public Users DeleteUser(Users user) //Logic to delete the user
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var userToDelete = dbContext.Users.FirstOrDefault(u => u.Username == user.Username && u.Email == user.Email);

                dbContext.Users.Remove(userToDelete); //Removes the user from the database
                dbContext.SaveChanges();

                return userToDelete;
            }
        }

        public void UpdateUser(Users user) //Updates user in the database
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
            }
        }

        public bool ValidateUser(string username, string password) //Validates user by username and password
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Password == password) != null;
            }
        }

        public bool ValidateUserByEmailAndUsername(string username, string email) //Validates user by username and email
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Email == email) != null;
            }
        }

        public bool ValidateUserByEmaiUsernameAndPassword(string username, string email, string password) //Validates user by username, email and password
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Email == email && x.Password == password) != null;
            }
        }

        public Users GetUserByUsernameAndEmail(string username, string email) //Retrieves the user from the database using their username and email
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Email == email);

            }
        }

        public bool NewUser(string username, string startcondition) //Checks if the user is new
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault(x => x.Username == username && x.Start_condition == "new") != null;
            }
        }
        public void AddWorkout(Users user, WorkoutSessions workout) //Saves workout to the database
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                //user.WorkoutSessions.Add(workout);
                //workout.user = user;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
            }
        }

        public bool UserExists(string username, string email) //Checks if the user exist
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.Any(x => x.Username == username || x.Email == email);
            }
        }

        public void AddPet(Pets pet) //Saves the pet's information into the database
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Pets.Add(pet);
                dbContext.SaveChanges();
            }
        }

       
    }
}
