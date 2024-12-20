using BuddyFitProject.Data.Models;
using BuddyFitProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BuddyFitProject.Components.Services
{
    public class ExerciseService
    {
        private IDbContextFactory<BuddyFitDbContext> DbContextFactory;

        public ExerciseService(IDbContextFactory<BuddyFitDbContext> dbContext)
        {
            DbContextFactory = dbContext;
        }
        public List<Exercises> LoadExercises()
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            { 
                var exercises = dbContext.Exercises.ToList();

                return exercises;
            }
        }

        public Exercises GetExerciseById(int id)
        {
            using (var dbContext = DbContextFactory.CreateDbContext())
            {
                Exercises exercise = dbContext.Exercises.SingleOrDefault<Exercises>(x => x.Id == id);
                return exercise;
            }
        }

        //public void DeleteUser(Users user)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        dbContext.Users.Remove(user);
        //        dbContext.SaveChanges();
        //    }
        //}

        //public void UpdateUser(Users user, string email)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        user.Email = email;
        //        dbContext.Users.Update(user);
        //        dbContext.SaveChanges();
        //    }
        //}

        //public bool ValidateUser(string username, string password)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        return (dbContext.Users.SingleOrDefault<Users>(x => x.Username == username && x.Password == password) != null);
        //    }
        //}

        //public void AddWorkout(Users user, WorkoutSessions workout)
        //{
        //    using (var dbContext = this.DbContextFactory.CreateDbContext())
        //    {
        //        //user.WorkoutSessions.Add(workout);
        //        //workout.user = user;
        //        dbContext.Users.Update(user);
        //        dbContext.SaveChanges();
        //    }
        //}
    }
}
