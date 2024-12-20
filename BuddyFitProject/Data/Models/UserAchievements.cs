using EllipticCurve.Utils;

namespace BuddyFitProject.Data.Models
{
    public class UserAchievements
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public bool Unlocked { get; set; }

    }
}
