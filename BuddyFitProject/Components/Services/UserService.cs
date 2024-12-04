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

        public UserService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }

        public void AddUser(Users user)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public Users GetUserByName(string name)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                Users user = dbContext.Users.SingleOrDefault<Users>(x => x.Username == name) ?? throw new Exception("User bestaat niet!");
                return user;
            }
        }

        public Users GetUserById(int id)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                Users user = dbContext.Users.SingleOrDefault<Users>(x => x.Id == id) ?? throw new Exception("User bestaat niet!");
                return user;
            }
        }

        public Users GetUserByLogin(string name, string password)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                Users user = dbContext.Users.SingleOrDefault<Users>(x => x.Username == name && x.Password == password) ?? throw new Exception("User bestaat niet!");
                return user;
            }
        }

        public Users DeleteUser(Users user)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                var userToDelete = dbContext.Users.FirstOrDefault(u => u.Username == user.Username && u.Email == user.Email);

                if (userToDelete == null)
                {
                    throw new InvalidOperationException("User not found in the database.");
                }

                dbContext.Users.Remove(userToDelete);
                dbContext.SaveChanges();

                return userToDelete;
            }
        }

        public void UpdateUser(Users user)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
            }
        }

        public bool ValidateUser(string username, string password)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Password == password) != null;
            }
        }

        public bool ValidateUserByEmailAndUsername(string username, string email)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Email == email) != null;
            }
        }

        public bool ValidateUserByEmaiUsernameAndPassword(string username, string email, string password)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Email == email && x.Password == password) != null;
            }
        }

        public bool ValidateUserByEmail(string email)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Email == email) != null;
            }
        }

        public Users GetUserByUsernameAndEmail(string username, string email)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Email == email);

            }
        }

        public Users GetUserByEmail(string email)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault<Users>(x => x.Email == email);

            }
        }

        public bool NewUser(string username, string startcondition)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                return dbContext.Users.SingleOrDefault(x => x.Username == username && x.Start_condition == "new") != null;
            }
        }
        public void AddWorkout(Users user, WorkoutSessions workout)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                //user.WorkoutSessions.Add(workout);
                //workout.user = user;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
            }
        }

        public void AddPet(Pets pet)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Pets.Add(pet);
                dbContext.SaveChanges();
            }
        }
    }
}
