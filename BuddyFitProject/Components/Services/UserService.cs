using BuddyFitProject.Data;
using BuddyFitProject.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Azure.Identity;

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

        public void DeleteUser(Users user)
        {
            using (var dbContext = this.DbContextFactory.CreateDbContext())
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
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
                return (dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Password == password) != null);
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

    }
}
