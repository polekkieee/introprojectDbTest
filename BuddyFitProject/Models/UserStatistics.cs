namespace BuddyFitProject.Models
{
    public class UserStatistics
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public int Total_minutes { get; set; }
        public int Total_coins { get; set; }
    }
}
